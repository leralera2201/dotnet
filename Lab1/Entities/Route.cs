using System.Collections.Generic;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class Route : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        public int TrainId { get; set; }
        public Train Train { get; set; }
        
        public List<Stoppage> Stoppages { get; set; } = new List<Stoppage>();
        
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}