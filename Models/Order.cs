using System;
using System.ComponentModel.DataAnnotations;

namespace productManagement.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        // Optional: Navigation properties
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
