using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes_CodeFirstApproach
{
    public class Recipe
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

        public TimeSpan CookingTime { get; set; }

        public ICollection<Ingredients> Ingredients { get; set; }
    }
}
