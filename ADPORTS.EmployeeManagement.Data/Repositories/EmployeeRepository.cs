using ADPORTS.EmployeeManagement.Core.Entities;
using ADPORTS.EmployeeManagement.Core.Repositories;
using ADPORTS.EmployeeManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ADPORTS.EmployeeManagement.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly DataContext Context;

        public EmployeeRepository(DataContext context)
        {
            Context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await Context.Employees.Where(x=>x.IsDeleted==false).ToListAsync();

        }

        public async Task<Employee> GetById(int Id)
        {
            return await Context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == Id && x.IsDeleted == false);
        }

        public async Task Create(Employee employee)
        {
            Context.Employees.Add(employee);
            await Context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            Context.Employees.Update(employee);
            await Context.SaveChangesAsync();
        }

    }
}
