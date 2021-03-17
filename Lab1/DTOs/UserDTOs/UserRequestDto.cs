using System;

namespace Lab1.DTOs.UserDTOs
{
    public class UserRequestDto
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }
        
        public String Email { get; set; }
        
        public String Password { get; set; }
    }
}