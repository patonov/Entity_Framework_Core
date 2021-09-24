using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes_CodeFirstApproach
{
    public class RecipeDBcontext : DbContext
    {
        public RecipeDBcontext()
        { 
        
        }

        public RecipeDBcontext(DbContextOptions<RecipeDBcontext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().Property(x => x.Title).HasColumnName("Yadene").HasMaxLength(20).IsRequired();

            modelBuilder.Entity<Recipe>().HasKey(x => x.Id);

            modelBuilder.Entity<Recipe>().HasMany(x => x.Ingredients).WithOne(x => x.Recipe).OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-79AOHR2;Database=Recipes;Integrated Security=true");
            }
        }

        public DbSet<Recipe> Recipes { get; set; } 

    }
}
