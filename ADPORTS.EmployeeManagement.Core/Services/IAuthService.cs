using ADPORTS.EmployeeManagement.Core.Common;
using ADPORTS.EmployeeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPORTS.EmployeeManagement.Core.Services
{
    public interface IAuthService
    {
        Task<ServiceResult> Register(string username , string password);
        Task<ServiceResult<bool>> UserExists(string userName);
        Task<ServiceResult<string>> Login(string username, string password);

    }
}
