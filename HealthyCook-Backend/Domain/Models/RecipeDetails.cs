using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class RecipeDetails
    {
        public int ID { get; set; }


        [Required]
        public string Difficulty { get; set; }

        [Required]
        public int PreparationTime { get; set; }

        [Required]
        public string TimePeriod { get; set; }


        [Required]
        public int Calories { get; set; }

        [Required]
        public int Servings { get; set; }

        public string RecipeVideoURL { get; set; }

        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }

        public List<IngredientType> ingredientTypes { get; set; }


    }
}
