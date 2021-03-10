using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class Station : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        [Required]
        public String Name { get; set; }

        public List<Stoppage> Stoppages { get; set; } = new List<Stoppage>();
    }
}