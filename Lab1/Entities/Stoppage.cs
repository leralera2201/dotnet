using System;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class Stoppage : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        [Required]
        public int OrderNumber { get; set; }
        
        [Required]
        public DateTime ArrivalTime { get; set; }
        
        [Required]
        public DateTime DepartureTime { get; set; }
        
        public int RouteId { get; set; }
        public Route Route { get; set; }
        
        public int StationId { get; set; }
        public Station Station { get; set; }
    }
}