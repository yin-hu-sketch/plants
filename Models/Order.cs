namespace plants.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
