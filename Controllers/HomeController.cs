using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using productManagement.Models;

namespace productManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(string name, string email, string subject, string message)
    {
        // You can add email sending or DB saving logic here
        TempData["Success"] = "Thank you! Your message has been received.";
        return RedirectToAction("Contact");
    }

}
