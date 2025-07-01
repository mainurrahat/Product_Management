//using System;
//using System.ComponentModel.DataAnnotations;

//namespace productManagement.Models
//{
//    public class Order
//    {
//        [Key]
//        public int Id { get; set; }

//        public int UserId { get; set; }
//        public int ProductId { get; set; }

//        public int Quantity { get; set; }

//        public DateTime OrderDate { get; set; }

//        // Optional: Navigation properties
//        public User User { get; set; }
//        public Product Product { get; set; }
//    }
//}

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

        [Required]
        public string UserId { get; set; } = string.Empty; // You can use this as Email or unique user identifier
    }
}
