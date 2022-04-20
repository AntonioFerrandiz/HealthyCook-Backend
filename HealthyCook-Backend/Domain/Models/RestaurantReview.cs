using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class RestaurantReview
    {
        public int ID { get; set; }
        
        [Required]
        public string Commentary { get; set; }

        [Required]
        public int Calification { get; set; }

        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
