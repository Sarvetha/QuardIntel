namespace QuardIntel.DTOs
{
    public class CreateOrderRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } // List of Product IDs in the order
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
