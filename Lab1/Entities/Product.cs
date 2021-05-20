using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public partial class Product : IBaseEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public Category Category { get; set; }
    }
}
