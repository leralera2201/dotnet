using System;

namespace Lab1.DTOs.StoppageDTOs
{
    public class StoppageRequestDto
    {
        public int OrderNumber { get; set; }
        
        public DateTime ArrivalTime { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public int StationId { get; set; }

        public int RouteId { get; set; }
    }
}