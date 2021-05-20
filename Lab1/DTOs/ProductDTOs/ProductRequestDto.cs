
namespace Lab1.DTOs.ProductDTOs
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}