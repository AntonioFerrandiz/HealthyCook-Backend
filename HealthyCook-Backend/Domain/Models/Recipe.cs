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
<<<<<<< HEAD
        
        
        public string DateCreated { get; set; }

=======
>>>>>>> 138143c744ae189bcd0c5ac37d02630f6c1f166a
        public int Active { get; set; }

        public int Published { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Preparation { get; set;}

        public int UserID { get; set; }
        public User User { get; set; }


        //public int RecipeDetailsID { get; set; }
        //public RecipeDetails RecipeDetails{ get; set; }

        //public List<RecipeSteps> recipeStepsList { get; set; }
    }

}
