using System;

namespace Lab1.DTOs.TrainDTOs
{
    public class TrainRequestDto
    {
        public int TrainNumber { get; set; }
        
        public String Description { get; set; }
        
        public int SeatNumber { get; set; }
    }
}