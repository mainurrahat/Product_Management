using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult HandleErrorCode(int statusCode)
    {
        Response.StatusCode = statusCode;  // Set the response status code

        if (statusCode == 404 || statusCode == 500)
        {
            return View("Error404");
        }

        // You can add more status codes here (500, 403, etc.)

        return View("Error"); // generic error view
    }

    [Route("Error")]
    public IActionResult Error()
    {
        return View("Error");
    }
}
