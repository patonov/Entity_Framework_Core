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

            Recipe recipe = new Recipe
            {
                Title = "Musaka",
                Description = "Traditional BG/TR meal",
                CookingTime = new TimeSpan(2, 11, 41),
                Ingredients = 
                {
            new RecipeIngredient {
                Ingredient = new Ingredients { Name = "potatto" },
                Qantity = 2000 
                },
            new RecipeIngredient {
                Ingredient = new Ingredients { Name = "meat" },
                Qantity = 1000 
                }
                }
            };

            db.Recipes.Add(recipe);

            db.SaveChanges();

            


            
        }
    }
}
