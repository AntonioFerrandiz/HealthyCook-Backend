using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class ExcludedIngredients
    {
        public int ID { get; set; }
        [Required]
        public string IngredientName { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
