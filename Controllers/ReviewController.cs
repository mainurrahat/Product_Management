using Microsoft.AspNetCore.Mvc;
using productManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace productManagement.Controllers
{
    public class ReviewController : Controller
    {
        private const int PageSize = 6;

        public IActionResult Index(int page = 1)
        {
            var reviews = GenerateReviews();

            var pagedReviews = reviews
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling((double)reviews.Count / PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedReviews);
        }

        private List<Review> GenerateReviews()
        {
            var reviews = new List<Review>();
            var rnd = new Random();

            string[] names = { "Awesome Product", "Great Experience", "Good Service", "Highly Recommend", "Satisfied Customer" };
            string[] reviewers = { "Alice", "Bob", "Charlie", "David", "Eva", "Fiona", "George", "Helen", "Ian", "Jane" };
            string[] descriptions = {
                "Really liked it, highly recommend!",
                "Excellent service and quality.",
                "Could be better but overall good.",
                "Fast delivery and great support.",
                "Will buy again!",
                "Not what I expected.",
                "Amazing value for money.",
                "Five stars from me!",
                "Product arrived damaged, but support helped.",
                "Very happy with this purchase."
            };
            string[] addresses = {
                "123 Street, City", "456 Avenue, City", "789 Road, Town",
                "101 Parkway, Metropolis", "202 Boulevard, Capital"
            };
            string[] images = {
                "/images/review1.jpg", "/images/review2.jpg", "/images/review3.jpg",
                "/images/review4.jpg", "/images/review5.jpg"
            };

            for (int i = 1; i <= 30; i++)
            {
                reviews.Add(new Review
                {
                    Id = i,
                    Name = names[rnd.Next(names.Length)],
                    ImagePath = images[rnd.Next(images.Length)],
                    Address = addresses[rnd.Next(addresses.Length)],
                    Rating = rnd.Next(1, 6),
                    Description = descriptions[rnd.Next(descriptions.Length)],
                    ReviewerName = reviewers[rnd.Next(reviewers.Length)],
                    ReviewDate = DateTime.Now.AddDays(-rnd.Next(1, 60))
                });
            }

            return reviews;
        }
    }
}
