using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPORTS.EmployeeManagement.Core.dtos
{
    public class RegistrationUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
