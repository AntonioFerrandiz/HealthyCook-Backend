using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class Receipt
    {
        public int ID { get; set; }

        [Required]
        public string Details { get; set; }
        [Required]
        public DateTime IssueDate { get; set; } 
    }
}
