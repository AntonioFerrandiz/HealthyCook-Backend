using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
        public int IngredientTypeID { get; set; }
        public IngredientType IngredientType { get; set; }
    }
}
