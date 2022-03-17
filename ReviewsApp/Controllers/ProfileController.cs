using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Services;
using ReviewsApp.Services.PageModelFactories;
using ReviewsApp.ViewModels.Profile;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProfileModelFactory _profileFactory;
        private readonly UserService _userService;

        public ProfileController(IUnitOfWork unitOfWork,
            ProfileModelFactory profileFactory,
            UserService userService)
        {
            _unitOfWork = unitOfWork;
            _profileFactory = profileFactory;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string userName, int pageIndex = 1)
        {
            var user = _unitOfWork.Users.Find(u => u.UserName == userName)
                .FirstOrDefault();
            if (user is null || !await _userService.IsAllowedUser(user.Id))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            var model = await _profileFactory.CreateProfileModel(user, pageIndex);

            return View(model);
        }

        public async Task<IActionResult> SetDisplayName()
        {
            string name = await _userService.GetUserDisplayName();
            var model = new UserDataViewModel { DisplayName = name };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetDisplayName(UserDataViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                await _userService.SetDisplayName(model.DisplayName);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(nameof(model.DisplayName), e.Message);
                return View(model);
            }

            var user = await _userService.GetCurrentUser();
            return RedirectToAction("Index", new { userName = user.UserName });
        }
    }
}
