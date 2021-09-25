using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneToOneEmployeeAddress
{
    public class OneToOneEmployeeAddressDbContext : DbContext
    {
        public OneToOneEmployeeAddressDbContext()
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-79AOHR2;Database=EmployeeAddressing;Integrated Security=true");
            }
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}
