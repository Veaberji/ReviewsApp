using AutoMapper;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class GradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly string _authorId;

        public GradeService(IUnitOfWork unitOfWork, IMapper mapper,
            UserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _authorId = InitAuthorId();
        }

        public async Task<GradeResponseViewModel> GradeReview(GradeViewModel model)
        {
            var review = await GetReview(model.ReviewId);
            var userGrade = GetGrade(review);
            if (userGrade is not null)
            {
                ChangeGrade(model, userGrade);
            }
            else
            {
                await CreateUserGrade(model, review);
            }
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<GradeResponseViewModel>(review);
        }

        public async Task<GradeResponseViewModel> RemoveGrade(int reviewId)
        {
            var review = await GetReview(reviewId);
            var userGrade = GetGrade(review);
            if (userGrade is null) return null;
            _unitOfWork.UserGrades.Remove(userGrade);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<GradeResponseViewModel>(review);
        }

        private async Task<Review> GetReview(int reviewId)
        {
            return await _unitOfWork.Reviews
                .GetNoCommentsFullReviewByIdAsync(reviewId);
        }

        private UserGrade GetGrade(Review review)
        {
            return review.Product.Grades
                .FirstOrDefault(g => g.UserId == _authorId);
        }

        private async Task CreateUserGrade(GradeViewModel model, Review review)
        {
            var grade = new UserGrade
            {
                UserId = _authorId,
                ProductId = review.ProductId,
                Grade = model.Grade
            };
            await _unitOfWork.UserGrades.AddAsync(grade);
        }

        private string InitAuthorId()
        {
            return _userService.GetCurrentUserId();
        }

        private static void ChangeGrade(GradeViewModel model, UserGrade userGrade)
        {
            userGrade.Grade = model.Grade;
        }
    }
}
