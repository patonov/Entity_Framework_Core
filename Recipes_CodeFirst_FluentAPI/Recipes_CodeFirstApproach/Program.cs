using System;
using System.Linq;

namespace Recipes_CodeFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RecipeDBcontext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Recipes.Add(new Recipe { Title = "Musaka", Description = "Traditional BG/TR meal", CookingTime = new TimeSpan(2, 11, 41)});

            db.SaveChanges();

            


            
        }
    }
}
