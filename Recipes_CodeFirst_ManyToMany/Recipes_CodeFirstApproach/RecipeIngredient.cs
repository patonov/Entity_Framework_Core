using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recipes_CodeFirstApproach
{
    public class RecipeIngredient
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        [ForeignKey("Ingredients")]
        public int IngredientId { get; set; }
        
        public Recipe Recipe { get; set; }

        public Ingredients Ingredient { get; set; } 

        public decimal Qantity { get; set; }
    }
}
