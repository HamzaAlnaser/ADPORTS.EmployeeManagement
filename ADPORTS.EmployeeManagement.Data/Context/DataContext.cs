using ADPORTS.EmployeeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ADPORTS.EmployeeManagement.Data.Context
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
