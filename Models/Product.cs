using System.ComponentModel.DataAnnotations;

namespace productManagement.Models  // Replace 'YourNamespace' with your actual project namespace
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100)]
        public required string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }
    }
}