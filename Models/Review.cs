//using System;
//using System.ComponentModel.DataAnnotations;

//namespace productManagement.Models
//{
//    public class Review
//    {
//        [Key]
//        public int Id { get; set; }

//        public int UserId { get; set; }
//        public int ProductId { get; set; }

//        [Required]
//        public string Comment { get; set; }

//        [Range(1, 5)]
//        public int Rating { get; set; }

//        public DateTime ReviewDate { get; set; }

//        // Optional: Navigation properties
//        public User User { get; set; }
//        public Product Product { get; set; }
//    }
//}
//----
// Models/Review.cs
namespace productManagement.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
