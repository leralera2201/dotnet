using System.Collections.Generic;
using Lab1.Interfaces;

namespace Lab1.Entities
{
    public partial class ProductsTag : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
