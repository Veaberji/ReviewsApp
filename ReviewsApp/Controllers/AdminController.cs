using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Settings;

namespace ReviewsApp.Controllers
{
    [Authorize(Roles = AppRoles.AdminRole)]
    public class AdminController : Controller
    {
        public IActionResult Profile(string userName)
        {

            return RedirectToAction("UserProfile", "Account",
                new { userName });
        }
    }
}
