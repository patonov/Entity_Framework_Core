using System;
using System.Linq;

namespace Recipes_CodeFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RecipeDBcontext();

            db.Database.EnsureCreated();

            db.Recipes.Add(new Recipe { Title = "Musaka, be maina"});
            db.SaveChanges();

            foreach (Recipe r in db.Recipes)
            {
                Console.WriteLine(r.Title);
            }
        }
    }
}
