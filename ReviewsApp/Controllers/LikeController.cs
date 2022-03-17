using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Services;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class LikeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LikeService _likeService;

        public LikeController(IUnitOfWork unitOfWork, LikeService likeService)
        {
            _unitOfWork = unitOfWork;
            _likeService = likeService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeLike(int reviewId)
        {
            var review = await _unitOfWork.Reviews
                .GetNoCommentsFullReviewByIdAsync(reviewId);
            if (review is null) return NotFound();
            await _likeService.ChangeLike(review);

            return Json(review.Likes.Count);
        }
    }
}
