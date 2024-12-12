using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace plants.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Связь с OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }

        // Связь с Reviews
        public ICollection<Review> Reviews { get; set; }

    }
}
