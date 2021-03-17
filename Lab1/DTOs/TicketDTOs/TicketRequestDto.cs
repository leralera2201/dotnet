using System;

namespace Lab1.DTOs.TicketDTOs
{
    public class TicketRequestDto
    {
        public String PassengerFirstName { get; set; }
        
        public String PassengerLastName { get; set; }

        public int RouteId { get; set; }
    }
}