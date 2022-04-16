using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class RecipeSteps
    {
        public int ID { get; set; }

        [Required]
        public int StepNumber { get; set; }
        [Required]
        public string Step { get; set; }

        public int RecipeID{ get; set; }
        public Recipe Recipe { get; set; }
    }
}
