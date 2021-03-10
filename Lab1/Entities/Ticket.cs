using System;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class Ticket : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        [Required]
        public String PassengerFirstName { get; set; }
        
        [Required]
        public String PassengerLastName { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }
        
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}