using ADPORTS.EmployeeManagement.Core.Common;
using ADPORTS.EmployeeManagement.Core.Entities;
using ADPORTS.EmployeeManagement.Core.Repositories;
using ADPORTS.EmployeeManagement.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADPORTS.EmployeeManagement.Infra.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository AuthRepository;
        private readonly string TokenKey = "Hamza Alnaser Token Key Sample";
        public AuthService(IAuthRepository repository )
        {
            AuthRepository = repository;
        }

        public async Task<ServiceResult<string>> Login(string username, string password)
        {
            var serviceResult = new ServiceResult<string>();
            User user =await AuthRepository.Login(username.ToLower(), password.ToLower());
            if(user == null)
            {
                serviceResult.Status = ResultCode.Unauthorized;
                return serviceResult;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name , user.UserName )
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            serviceResult.Data = tokenHandler.WriteToken(token);
            serviceResult.Status = ResultCode.Ok;
            return serviceResult;

        }

        public async Task<ServiceResult> Register(string username, string password)
        {
            var serviceResult = new ServiceResult();
            var userExistsResult = new ServiceResult<bool>();
            username = username.ToLower();

            if(username == null || password == null || username.Length  == 0 || password.Length == 0)
            {
                serviceResult.Status = ResultCode.BadRequest;
                return serviceResult;
            }
            userExistsResult = await UserExists(username);

            if (userExistsResult.Data) {
                serviceResult.Status = ResultCode.BadRequest;
                return serviceResult;
            }

            User usertoCreate = new User { UserName = username };
            var createdUser = await AuthRepository.Register(usertoCreate, password.ToLower());

            serviceResult.Status = ResultCode.Created;
            return serviceResult;

        }

        public async Task<ServiceResult<bool>> UserExists(string userName)
        {
            var serviceResult = new ServiceResult<Boolean>();
            bool employeeExists = await AuthRepository.UserExists(userName);
            serviceResult.Data = employeeExists;
            return serviceResult;
        }

    }
}
