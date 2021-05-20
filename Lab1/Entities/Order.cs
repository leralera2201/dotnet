using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public partial class Order : IBaseEntity<int>
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }

        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsPaid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
