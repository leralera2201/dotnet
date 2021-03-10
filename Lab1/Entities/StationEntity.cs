using System;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class StationEntity : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        public String Name { get; set; }
    }
}