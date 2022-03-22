using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.Services;
using ReviewsApp.Services.PageModelFactories;
using ReviewsApp.ViewModels.MainReview;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly HomeViewModelFactory _homeFactory;
        private readonly ReviewPageViewModelFactory _reviewFactory;
        private readonly ReviewService _reviewService;

        public ReviewController(IUnitOfWork unitOfWork,
            IMapper mapper,
            UserService userService,
            HomeViewModelFactory homeFactory,
            ReviewService reviewService,
            ReviewPageViewModelFactory reviewFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _homeFactory = homeFactory;
            _reviewService = reviewService;
            _reviewFactory = reviewFactory;
        }

        [AllowAnonymous]
        public async Task<IActionResult> LastReviews(int pageIndex = 1)
        {
            if (pageIndex < 1) pageIndex = 1;
            var model = await _homeFactory.CreateLastReviewsModel(pageIndex);

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ReviewsWithTag(string tagText, int pageIndex = 1)
        {
            if (pageIndex < 1) pageIndex = 1;
            var model = await _homeFactory
                .CreateReviewsWithTagModel(tagText, pageIndex);

            return View(nameof(LastReviews), model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SingleReview(int id)
        {
            var review = await _unitOfWork.Reviews.GetNoCommentsFullReviewByIdAsync(id);
            if (review is null) return NotFound();
            var model = await _reviewFactory.CreateReviewPageModel(review);

            return View(model);
        }

        public async Task<IActionResult> CreateReview(string userName = null)
        {
            var user = _userService.GetUserByUserName(userName);
            if (user is null || !await _userService.IsAllowedUser(user.Id))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            var model = new CreateReviewViewModel
            {
                UserName = userName,
                ProductTypes = ReviewService.GetProductTypes()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(string userName,
            CreateReviewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = _userService.GetUserByUserName(userName);
            if (user is null) return NotFound();
            var review = _mapper.Map<Review>(model);
            await _reviewService.CreateReview(review, user.Id);

            return RedirectToReviewPage(review.Id);
        }

        public async Task<IActionResult> Details(int id)
        {
            var review = await _unitOfWork.Reviews
                .GetNoCommentsFullReviewByIdAsync(id);
            if (review is null) return NotFound();
            if (!await _userService.IsAllowedUser(review.AuthorId))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var model = _mapper.Map<ReviewDetailsViewModel>(review);
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var review = await _unitOfWork.Reviews
                .GetNoCommentsFullReviewByIdAsync(id);
            if (review is null) return NotFound();
            if (!await _userService.IsAllowedUser(review.AuthorId))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var model = _mapper.Map<ReviewEditViewModel>(review);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var updatedReview = await _unitOfWork.Reviews
                .GetNoCommentsFullReviewByIdAsync(id);
            if (updatedReview is null) return NotFound();
            var values = _mapper.Map<Review>(model);
            await _reviewService.UpdateReview(updatedReview, values,
                model.ImagesToDelete);

            return RedirectToAction("Details", new { id = updatedReview.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var review = await _unitOfWork.Reviews.GetNoCommentsFullReviewByIdAsync(id);
            if (review is null) return NotFound();
            if (!await _userService.IsAllowedUser(review.AuthorId))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var model = _mapper.Map<PreviewViewModel>(review);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            if (review is null) return NotFound();
            await _reviewService.DeleteReview(review);

            return RedirectToAction("Index", "Profile",
                new { userName = review.Author.UserName });
        }

        private IActionResult RedirectToReviewPage(int id)
        {
            return RedirectToAction("SingleReview", new { id });
        }
    }
}
