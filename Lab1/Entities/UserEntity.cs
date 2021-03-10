using System;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public class UserEntity : IBaseEntity<int>
    {
        public int Id { get; set; }
        
        public String FirstName { get; set; }
        
        public String LastName { get; set; }
        
        public String Email { get; set; }
        
        public String Password { get; set; } 
    }
}