using ADPORTS.EmployeeManagement.Core.Entities;
using ADPORTS.EmployeeManagement.Core.Services;
using ADPORTS.EmployeeManagement.Core.Common;
using Microsoft.AspNetCore.Mvc;
using ADPORTS.EmployeeManagement.Controllers;
using ADPORTS.EmployeeManagement.Infra.Services;
using ADPORTS.EmployeeManagement.Core.dtos;
using Microsoft.AspNetCore.Authorization;

namespace ADPORTS.EmployeeManagement.API.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    public class AuthController : ControllersBase
    {
        private readonly IAuthService AuthService;
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationUser registrationUser)
        {
            ServiceResult serviceResult = await AuthService.Register(registrationUser.UserName, registrationUser.Password);
            return GetActionResult(serviceResult);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            ServiceResult<string> serviceResult = await AuthService.Login(loginUser.Username, loginUser.Password);
            return GetActionResult(serviceResult);
        }

    }
}