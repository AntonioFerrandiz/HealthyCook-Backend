using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class RecipesSaved
    {


        public int ID { get; set; }

        public User User { get; set; }
        
        public int UserID { get; set; }

        public int RecipeSavedID { get; set; }
    }
}
