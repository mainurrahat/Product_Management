using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productManagement.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        
        public string? UserId { get; set; } = string.Empty; // You can use this as Email or unique user identifier
        //public string ProductName { get; set; }

    }
}
