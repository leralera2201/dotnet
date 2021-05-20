namespace Lab1.DTOs.OrderDTOs
{
    public class OrderRequestDto
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool IsPaid { get; set; }
    }
}