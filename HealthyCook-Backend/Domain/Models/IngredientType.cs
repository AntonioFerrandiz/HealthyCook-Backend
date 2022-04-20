using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class IngredientType
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int RecipeDetailsID { get; set; }
        public RecipeDetails RecipeDetails { get; set; }

        public List<Ingredient> ingredientsList { get; set; }
    }
}
