using ADPORTS.EmployeeManagement.Core.Common;
using ADPORTS.EmployeeManagement.Core.Entities;

namespace ADPORTS.EmployeeManagement.Core.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResult<List<Employee>>> GetAll();
        Task<ServiceResult<Employee>> GetById(int Id);
        Task<ServiceResult<Employee>> Create(Employee employee);
        Task<ServiceResult<Employee>> Update(Employee employee);
        Task<ServiceResult<Employee>> Delete(int EmployeeId);


    }
}
