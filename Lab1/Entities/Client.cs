using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public partial class Client : IBaseEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
