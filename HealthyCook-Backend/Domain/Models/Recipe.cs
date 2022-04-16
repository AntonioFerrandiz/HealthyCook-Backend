using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int RecipeDetailsID { get; set; }
        public RecipeDetails RecipeDetails { get; set; }

        public List<RecipeSteps> recipeStepsList { get; set; }
    }

}
