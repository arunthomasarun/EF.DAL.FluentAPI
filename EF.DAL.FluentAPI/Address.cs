using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.FluentAPI
{
    public class Address
    {
        [ForeignKey("Employee")]   //By this way, AddressId column will refer to EmployeeId column in Employee table. This column also acts as Pkey in this table
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
