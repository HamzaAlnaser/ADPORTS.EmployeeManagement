using ADPORTS.EmployeeManagement.Core.Entities;

namespace ADPORTS.EmployeeManagement.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int Id);
        Task Create(Employee employee);

        Task Update(Employee employee);

    }
}
