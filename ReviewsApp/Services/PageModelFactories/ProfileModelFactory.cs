using AutoMapper;
using ReviewsApp.Controllers;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.Profile;
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
                amount, nameof(ProfileController.Index));
            var model = new ProfileViewModel
            {
                Names = _mapper.Map<UserNamesViewModel>(user),
                Reviews = reviewsViewModels,
                Pagination = pagination
            };
            return model;
        }
    }
}
