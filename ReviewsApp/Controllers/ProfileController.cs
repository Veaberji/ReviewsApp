﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProfileViewModelFactory _profileFactory;
        private readonly UserService _userService;

        public ProfileController(IUnitOfWork unitOfWork,
            ProfileViewModelFactory profileFactory,
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

            var model = await _profileFactory.Create(user, pageIndex);

            return View(model);
        }
    }
}
