using System.ComponentModel.DataAnnotations;

namespace plants.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string FirstName { get; set; } = string.Empty; // Значение по умолчанию для избежания `NULL`

        public string LastName { get; set; } = string.Empty; // Значение по умолчанию для избежания `NULL`

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } // Поле допускает `NULL`

        public string? Address { get; set; } // Поле допускает `NULL`

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Связь с Reviews
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
