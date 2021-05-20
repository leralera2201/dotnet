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
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

       // public int ClientId { get; set; }
       // public Client Client { get; set; }

    }
}