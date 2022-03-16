using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
using ReviewsApp.ViewModels.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize(Roles = AppRoles.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var usersModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            var model = new AdminViewModel { Users = usersModel };
            return View(model);
        }
    }
}
