using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Firstname { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Lastname { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
