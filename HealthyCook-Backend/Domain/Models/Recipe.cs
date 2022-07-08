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
        
        public string DateCreated { get; set; }
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
    }

}
