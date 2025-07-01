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
                Password = Password // For now plain password (NOT recommended in production)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
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

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserId", user.Email); // ✅ Moved inside the if block
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password.";
            return View(); // ❌ Do not access user.Email here — user is null
        }


        // ===== Logout =====
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
