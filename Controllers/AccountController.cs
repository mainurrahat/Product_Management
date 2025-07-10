using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using productManagement.Data;
using productManagement.Models;
using System.Linq;

namespace productManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===== Register (GET) =====
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ===== Register (POST) =====
        [HttpPost]
        public IActionResult Register(string Name, string Email, string Password, string ConfirmPassword)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                ViewBag.Error = "Name and Email are required.";
                return View();
            }

            if (Password != ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View();
            }

            if (_context.Users.Any(u => u.Email == Email))
            {
                ViewBag.Error = "Email already exists.";
                return View();
            }

            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password // Plain password for now (not recommended in production)
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["Success"] = "Registration successful!";
            return View();
            //return RedirectToAction("Login");


        }

        // ===== Login (GET) =====
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // ===== Login (POST) =====
       
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }

            // Set session values
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            // Set cookie with user email for 1 day (adjust Secure flag if using HTTPS)
            Response.Cookies.Append("UserEmail", user.Email, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1),
                HttpOnly = true,
                Secure = false, // Set to true if using HTTPS
                IsEssential = true
            });

            Console.WriteLine($"✅ Login success. UserEmail stored in cookie: {user.Email}");

            // Redirect based on role
            if (user.Role == "Admin")
            {
                TempData["Success"] = "🎉 You’re in Admin! Now act like you know what you're doing!";
                return RedirectToAction("Index", "Admin");  // Admin area
            }
            else
            {
                //return RedirectToAction("Index", "Home");   // Normal user homepage
                TempData["Success"] = "Welcome back! May your products never be out of stock.";
                return RedirectToAction("Index", "Home");
            }
        }

        // ===== Logout =====
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("UserEmail");

            TempData["LogoutSuccess"] = "👋 You’ve logged out. Come back soon!";

            return RedirectToAction("Login");
        }


    }
}
