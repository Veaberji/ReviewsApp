using AutoMapper;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.Home;
using ReviewsApp.ViewModels.MainReview;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class HomePageViewModelFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PaginationService _paginationService;

        public HomePageViewModelFactory(IUnitOfWork unitOfWork,
            IMapper mapper,
            PaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<HomePageViewModel> Create(int pageIndex,
            int amountReviews,
            IEnumerable<Review> reviews,
            string actionMethod)
        {
            var tags = _unitOfWork.Tags.GetTopTags();
            var tagViewModels = tags.Select(tag =>
                _mapper.Map<TagCloudViewModel>(tag)).ToList();
            var reviewsViewModels =
                _mapper.Map<IEnumerable<PreviewViewModel>>(reviews);
            var topReviews = await _unitOfWork.Reviews
                .GetTopRatedReviewsHeadersAsync();
            var topReviewsViewModels =
                _mapper.Map<IEnumerable<TopRatedReviewViewModel>>(topReviews);
            var model = new HomePageViewModel
            {
                Reviews = reviewsViewModels,
                TagCloud = tagViewModels,
                Pagination = _paginationService.CreatePagination(pageIndex,
                    amountReviews, actionMethod),
                TopRatedReviews = topReviewsViewModels
            };
            return model;
        }
    }
}
