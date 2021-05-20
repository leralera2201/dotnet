using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public partial class Category : IBaseEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
