using ADPORTS.EmployeeManagement.Core.Common;
using ADPORTS.EmployeeManagement.Core.Common.Exceptions;
using ADPORTS.EmployeeManagement.Core.Entities;
using ADPORTS.EmployeeManagement.Core.Repositories;
using ADPORTS.EmployeeManagement.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ADPORTS.EmployeeManagement.Infra.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository EmployeeRepository;
        public EmployeeService(IEmployeeRepository repository)
        {
            EmployeeRepository = repository;
        }

        public async Task<ServiceResult<List<Employee>>> GetAll()
        {
            var serviceResult = new ServiceResult<List<Employee>>(ResultCode.NoContent);
            List<Employee> employees = await EmployeeRepository.GetAll();
            if (employees != null && employees.Count > 0)
            {
                serviceResult.Data = employees;
                serviceResult.Status = ResultCode.Ok;
            }
            return serviceResult;
        }

        public async Task<ServiceResult<Employee>> GetById(int Id)
        {
            var serviceResult = new ServiceResult<Employee>(ResultCode.NotFound);
            Employee employee = await EmployeeRepository.GetById(Id);
            if (employee != null)
            {
                serviceResult.Data = employee;
                serviceResult.Status = ResultCode.Ok;
            }
            return serviceResult;
        }

        public async Task<ServiceResult<Employee>> Create(Employee entity)
        {
            var serviceResult = new ServiceResult<Employee>(ResultCode.BadRequest);

            await EmployeeRepository.Create(entity);

            serviceResult.Data = entity;
            serviceResult.Status = ResultCode.Created;


            return serviceResult;
        }

        public async Task<ServiceResult<Employee>> Update(Employee entity)
        {
            var serviceResult = new ServiceResult<Employee>(ResultCode.BadRequest);
            serviceResult = await GetById(entity.EmployeeId);

            Employee employee = serviceResult.Data;

            if (employee == null)
            {
                serviceResult.Status = ResultCode.NotFound;
                return serviceResult;

            }

            await EmployeeRepository.Update(entity);

            serviceResult.Data = entity;
            serviceResult.Status = ResultCode.Ok;

            return serviceResult;
        }


        public async Task<ServiceResult<Employee>> Delete(int employeeId)
        {
            var serviceResult = new ServiceResult<Employee>(ResultCode.BadRequest);
            serviceResult = await GetById(employeeId);

            Employee employee = serviceResult.Data;

            if(employee == null)
            {
                serviceResult.Status = ResultCode.NotFound;
                return serviceResult;

            }
            employee.IsDeleted = true;

            await EmployeeRepository.Update(employee);

            serviceResult.Data = employee;
            serviceResult.Status = ResultCode.Ok;

            return serviceResult;

        }
    }
}
