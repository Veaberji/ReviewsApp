using AutoMapper;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services.PageModelFactories
{
    public class ReviewPageViewModelFactory
    {
        private readonly UserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ReviewService _reviewService;

        public ReviewPageViewModelFactory(UserService userService,
            IUnitOfWork unitOfWork, IMapper mapper, ReviewService reviewService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _reviewService = reviewService;
        }

        public async Task<ReviewPageViewModel> CreateReviewPageModel(Review review)
        {
            var userId = _userService.GetCurrentUserId();
            var model = new ReviewPageViewModel
            {
                Review = InitReview(review),
                Comments = await InitComments(review.Id),
                StarRating = InitStarRating(review, userId)
            };

            model.Review.IsLikedByCurrentUser = _reviewService
                .IsLikedByUser(review, userId);
            return model;
        }

        private ReviewViewModel InitReview(Review review)
        {
            return _mapper.Map<ReviewViewModel>(review);
        }

        private async Task<IEnumerable<CommentViewModel>> InitComments(int reviewId)
        {
            IEnumerable<Comment> comments = new List<Comment>();
            if (_userService.IsUserAuthenticated())
            {
                comments = await _unitOfWork.Comments
                    .GetReviewCommentsWithAuthorsAsync(reviewId);
            }

            return _mapper.Map<IEnumerable<CommentViewModel>>(comments);
        }

        private StarRatingViewModel InitStarRating(Review review, string userId)
        {
            if (!_userService.IsUserAuthenticated()) return null;
            var starRating = _mapper.Map<StarRatingViewModel>(review);
            starRating.CurrentUserRating =
                review.Product.Grades.FirstOrDefault(
                    g => g.UserId == userId)?.Grade;

            return starRating;
        }
    }
}
