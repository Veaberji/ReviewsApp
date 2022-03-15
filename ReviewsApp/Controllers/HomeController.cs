using Microsoft.AspNetCore.Mvc;

namespace ReviewsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
