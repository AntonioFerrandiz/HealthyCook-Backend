using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public int Active { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string BusinessType { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        public string Address { get; set; }

        public int RestaurantOwnerID { get; set; }
        public RestaurantOwner RestaurantOwner { get; set; }

        
    }
}
