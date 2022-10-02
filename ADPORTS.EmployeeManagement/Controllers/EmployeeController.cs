using ADPORTS.EmployeeManagement.Core.Entities;
using ADPORTS.EmployeeManagement.Core.Services;
using ADPORTS.EmployeeManagement.Core.Common;
using Microsoft.AspNetCore.Mvc;
using ADPORTS.EmployeeManagement.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace ADPORTS.EmployeeManagement.API.Controllers
{
    [Authorize]
    [Route("api/employees")]
    public class EmployeeController : ControllersBase
    {
        private readonly IEmployeeService EmployeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ServiceResult<List<Employee>> serviceResult = await EmployeeService.GetAll();
            return GetActionResult(serviceResult);
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetById(int employeeId)
        {
            ServiceResult<Employee> serviceResult = await EmployeeService.GetById(employeeId);
            return GetActionResult(serviceResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            ServiceResult<Employee> serviceResult = await EmployeeService.Create(employee);
            return GetActionResult(serviceResult);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            ServiceResult<Employee> serviceResult = await EmployeeService.Update(employee);
            return GetActionResult(serviceResult);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int employeeId)
        {
            ServiceResult<Employee> serviceResult = await EmployeeService.Delete(employeeId);
            return GetActionResult(serviceResult);
        }
    }
}