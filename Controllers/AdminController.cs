using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using productManagement.Data;
using productManagement.Models; // Your User model namespace
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Admin/Index?page=1
    public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
    {
        var userRole = HttpContext.Session.GetString("UserRole");
        if (string.IsNullOrEmpty(userRole) || userRole != "Admin")
        {
            return RedirectToAction("Login", "Account");
        }

        var totalUsers = await _context.Users.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

        var users = await _context.Users
            .OrderBy(u => u.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewData["users"] = totalUsers;
        ViewData["PageSize"] = pageSize;
        ViewData["CurrentPage"] = page;
        ViewData["TotalPages"] = totalPages;

        return View(users); // This is List<User>
    }

    public IActionResult ManageUsers() => Content("Manage Users Page (Coming Soon)");
    public IActionResult Settings() => Content("Settings Page (Coming Soon)");
}
