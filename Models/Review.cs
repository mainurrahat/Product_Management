using System;
using System.ComponentModel.DataAnnotations;

namespace productManagement.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime ReviewDate { get; set; }

        // Optional: Navigation properties
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
