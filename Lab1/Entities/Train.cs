using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class Train : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        [Required]
        public int TrainNumber { get; set; }
        
        [Required]
        public String Description { get; set; }
        
        [Required]
        public int SeatNumber { get; set; }

        public List<Route> Routes { get; set; } = new List<Route>();
    }
}