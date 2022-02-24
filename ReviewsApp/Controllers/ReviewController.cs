using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.ViewModels;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> LastReviews(int pageIndex = 1)
        {
            var reviews =
                 await _unitOfWork.Reviews.GetReviewsWithAuthorsAsync(pageIndex);
            //todo: add pagination
            return View(reviews);
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var review = _mapper.Map<Review>(model);
            review.AuthorId = _userManager.GetUserId(HttpContext.User);
            await _unitOfWork.Reviews.AddAsync(review);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                //todo: redirect to created review
                return RedirectToCreateReviewPage();
            }

            return View(model);
        }

        //todo: add Review(int id)

        private IActionResult RedirectToCreateReviewPage()
        {
            return RedirectToAction("CreateReview");
        }

    }
}
