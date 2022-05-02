using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class RecipeRating
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
