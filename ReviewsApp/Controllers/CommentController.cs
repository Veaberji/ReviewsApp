using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.Services;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public CommentController(IUnitOfWork unitOfWork,
            IMapper mapper, UserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToReviewPage(model.ReviewId);
            }
            var comment = _mapper.Map<Comment>(model);
            comment.AuthorId = _userService.GetCurrentUserId();
            comment.RowVersion = 1;
            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.CompleteAsync();
            return RedirectToReviewPage(model.ReviewId);
        }

        private IActionResult RedirectToReviewPage(int id)
        {
            return RedirectToAction("SingleReview", "Review", new { id });
        }
    }
}
