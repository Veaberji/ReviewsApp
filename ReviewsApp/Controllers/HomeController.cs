using Microsoft.AspNetCore.Mvc;

namespace ReviewsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
