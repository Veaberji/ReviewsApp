using Microsoft.AspNetCore.Mvc;

namespace ReviewsApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode != null)
                HttpContext.Response.StatusCode = statusCode.Value;
            if (statusCode is 403)
            {
                return View("Error403");
            }

            return View("Error");
        }
    }
}
