using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class User : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }
        
        [Required]
        public String Email { get; set; }
        
        [Required]
        public String Password { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}