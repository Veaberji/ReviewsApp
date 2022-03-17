using AutoMapper;
using ReviewsApp.Models.AutoMapperProfiles;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.ViewModels.Account;
using ReviewsApp.ViewModels.MainReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Services.PageModelFactories
{
    public class ProfileModelFactory
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationService _paginationService;

        public ProfileModelFactory(IMapper mapper,
            IUnitOfWork unitOfWork,
            PaginationService paginationService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paginationService = paginationService;
        }

        public async Task<ProfileViewModel> CreateProfileModel(User user, int pageIndex)
        {
            var reviews =
                await _unitOfWork.Reviews.GetPreviewsByAuthorIdAsync(user.Id, pageIndex);
            var reviewsViewModels =
                _mapper.Map<IEnumerable<PreviewViewModel>>(reviews);
            int amount = await _unitOfWork.Reviews
                .GetAmountOfReviewsByAuthorAsync(user);
            var pagination = _paginationService.CreatePagination(pageIndex,
                amount, nameof(UserProfile));
            var model = _mapper.Map<ProfileViewModel>(user);
            model.Reviews = reviewsViewModels;
            model.Pagination = pagination;
            return model;
        }
    }
}
