using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes_CodeFirstApproach
{
    public class Ingredients
    {
        public Ingredients()
        {
            this.Recipe = new HashSet<RecipeIngredient>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipe { get; set; }

    }
}
