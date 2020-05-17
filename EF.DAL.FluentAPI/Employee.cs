using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.FluentAPI
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Address Addresses { get; set; }
    }
}
