using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class LikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserService _userService;
        private readonly string _authorId;

        public LikeService(IUnitOfWork unitOfWork, UserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _authorId = InitAuthorId();
        }

        public async Task ChangeLike(Review review)
        {
            var like = review.Likes.FirstOrDefault(l => l.AuthorId == _authorId);
            if (like != null)
            {
                _unitOfWork.Likes.Remove(like);
            }
            else
            {
                await _unitOfWork.Likes.AddAsync(CreateLike(review.Id));
            }
            await _unitOfWork.CompleteAsync();
        }

        private string InitAuthorId()
        {
            return _userService.GetCurrentUserId();
        }

        private Like CreateLike(int reviewId)
        {
            return new Like
            {
                AuthorId = _authorId,
                ReviewId = reviewId
            };
        }
    }
}
