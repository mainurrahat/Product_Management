using Microsoft.AspNetCore.Mvc;
using productManagement.Models;
using System;
using System.Collections.Generic;

namespace productManagement.Controllers
{
    public class MyOrderController : Controller
    {
        public IActionResult Index()
        {
            // Manually create 10 sample orders
            var orders = new List<Order>
            {
                new Order { Id = 1, ProductId = 1, Quantity = 2, OrderDate = DateTime.Parse("2025-07-01"), Product = new Product { Name = "Laptop" } },
                new Order { Id = 2, ProductId = 2, Quantity = 1, OrderDate = DateTime.Parse("2025-07-02"), Product = new Product { Name = "Mouse" } },
                new Order { Id = 3, ProductId = 3, Quantity = 4, OrderDate = DateTime.Parse("2025-07-03"), Product = new Product { Name = "Keyboard" } },
                new Order { Id = 4, ProductId = 4, Quantity = 1, OrderDate = DateTime.Parse("2025-07-04"), Product = new Product { Name = "Monitor" } },
                new Order { Id = 5, ProductId = 5, Quantity = 3, OrderDate = DateTime.Parse("2025-07-05"), Product = new Product { Name = "Printer" } },
                new Order { Id = 6, ProductId = 6, Quantity = 2, OrderDate = DateTime.Parse("2025-07-06"), Product = new Product { Name = "Desk" } },
                new Order { Id = 7, ProductId = 7, Quantity = 1, OrderDate = DateTime.Parse("2025-07-07"), Product = new Product { Name = "Chair" } },
                new Order { Id = 8, ProductId = 8, Quantity = 5, OrderDate = DateTime.Parse("2025-07-08"), Product = new Product { Name = "USB Drive" } },
                new Order { Id = 9, ProductId = 9, Quantity = 2, OrderDate = DateTime.Parse("2025-07-09"), Product = new Product { Name = "Webcam" } },
                new Order { Id = 10, ProductId = 10, Quantity = 1, OrderDate = DateTime.Parse("2025-07-10"), Product = new Product { Name = "Headphones" } }
            };

            return View(orders);
        }
    }
}
