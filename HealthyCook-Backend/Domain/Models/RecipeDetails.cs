﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class RecipeDetails
    {
        public int ID { get; set; }

        public DateTime DateCreated { get; set; }

        public int Active { get; set; }

        [Required]
        public int PreparationTime { get; set; }
        
        [Required]
        public int Portions { get; set; }
        
        public List<Ingredient> ingredientsList { get; set; }

        
    }
}