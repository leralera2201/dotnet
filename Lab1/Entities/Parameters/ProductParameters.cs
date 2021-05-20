namespace Lab1.Entities.Parameters
{
    public class ProductParameters : QueryStringParameters
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Name { get; set; }
    }
}