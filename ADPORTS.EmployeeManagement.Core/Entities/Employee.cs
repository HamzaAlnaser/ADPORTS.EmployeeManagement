using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPORTS.EmployeeManagement.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public int EmployeeSalary { get; set; }

        public int EmployeeAge { get; set; }

        public bool IsDeleted { get; set; }


    }
}
