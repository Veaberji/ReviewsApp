using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Settings;

namespace ReviewsApp.Controllers
{
    [Authorize(Roles = AppRoles.AdminRole)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Profile(string userName, int pageIndex = 1)
        {

            return RedirectToAction("UserProfile", "Account",
                new { userName, pageIndex });
        }
    }
}
