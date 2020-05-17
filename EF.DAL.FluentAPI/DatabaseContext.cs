using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.FluentAPI
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Employee
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Employee>().Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);
            modelBuilder.Entity<Employee>().Property(e => e.Address).HasMaxLength(500).IsUnicode(false).IsOptional();
            modelBuilder.Entity<Employee>().Property(e => e.ContactNumber).IsRequired();

            //1-* 1-many relationship
            modelBuilder.Entity<Employee>().HasRequired(e => e.Department).WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId);

            //1-1 mapping between Emplyee and Address
            modelBuilder.Entity<Employee>().HasOptional(e => e.Addresses).WithRequired(ad => ad.Employee);

            //Department
            modelBuilder.Entity<Department>().HasKey(e => e.DepartmentId);
            modelBuilder.Entity<Department>().Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
