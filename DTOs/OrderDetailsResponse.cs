using QuardIntel.Models;

namespace QuardIntel.DTOs
{
    public class OrderDetailsResponse
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<OrderItemDetails> Items { get; set; }
    }
}
