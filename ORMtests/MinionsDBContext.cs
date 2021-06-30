using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMtests
{
    class MinionsDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-79AOHR2;Database=MinionsExtractedDB;Integrated Security=true;");
        }

        public DbSet<Minions> minions { get; set; }

        public DbSet<Villains> villains { get; set; }
    }
}
