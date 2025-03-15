namespace Entities.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product product { get; set; } = new();
        public int Quantity { get; set; }
    }
}