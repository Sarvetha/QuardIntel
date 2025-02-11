namespace QuardIntel.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; } // List of Product IDs in the order
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public User User { get; set; } // Reference to User
        public ICollection<OrderItem> OrderItems { get; set; } // For many-to-many relationship with Product
    }
}
