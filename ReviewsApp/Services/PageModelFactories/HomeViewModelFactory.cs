using AutoMapper;
using ReviewsApp.Controllers;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.Home;
using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services.PageModelFactories
{
    public class HomeViewModelFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PaginationService _paginationService;

        public HomeViewModelFactory(IUnitOfWork unitOfWork,
            IMapper mapper,
            PaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<HomeViewModel> CreateLastReviewsModel(int pageIndex)
        {
            var reviews =
                await _unitOfWork.Reviews.GetPreviewsAsync(pageIndex);
            var amount = await _unitOfWork.Reviews.GetAmountOfReviewsAsync();
            return await Create(reviews, pageIndex, amount,
                nameof(ReviewController.LastReviews));
        }

        public async Task<HomeViewModel> CreateReviewsWithTagModel(
            string tagText, int pageIndex)
        {
            var tag = await _unitOfWork.Tags.GetByTextAsync(tagText);
            var reviews =
                await _unitOfWork.Reviews.GetPreviewsWithTagAsync(tag, pageIndex);
            var amount = await _unitOfWork.Reviews.GetAmountOfReviewsWithTagAsync(tag);
            return await Create(reviews, pageIndex, amount,
                nameof(ReviewController.ReviewsWithTag));
        }

        private async Task<HomeViewModel> Create(IEnumerable<Review> reviews,
            int pageIndex,
            int amountReviews,
            string actionMethod)
        {
            var model = new HomeViewModel
            {
                Reviews = InitReviews(reviews),
                TagCloud = InitTagCloud(),
                Pagination = InitPagination(pageIndex, amountReviews, actionMethod),
                TopRatedReviews = await InitTopRatedReviews()
            };
            return model;
        }

        private IEnumerable<PreviewViewModel> InitReviews(IEnumerable<Review> reviews)
        {
            return _mapper.Map<IEnumerable<PreviewViewModel>>(reviews);
        }

        private List<TagCloudViewModel> InitTagCloud()
        {
            var tags = _unitOfWork.Tags.GetTopTags();
            return tags.Select(tag =>
                _mapper.Map<TagCloudViewModel>(tag)).ToList();
        }

        private PaginationViewModel InitPagination(int pageIndex, int amountReviews,
            string actionMethod)
        {
            return _paginationService.CreatePagination(pageIndex,
                amountReviews, actionMethod);
        }

        private async Task<IEnumerable<TopRatedReviewViewModel>> InitTopRatedReviews()
        {
            var topReviews = await _unitOfWork.Reviews
                .GetTopRatedReviewsHeadersAsync();
            return _mapper.Map<IEnumerable<TopRatedReviewViewModel>>(topReviews);
        }
    }
}
