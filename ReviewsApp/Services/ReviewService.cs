using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.Components.Constrains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class ReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ImageStoreService _imageStoreService;

        public ReviewService(IUnitOfWork unitOfWork,
            ImageStoreService imageStoreService)
        {
            _unitOfWork = unitOfWork;
            _imageStoreService = imageStoreService;
        }

        public async Task UpdateImages(Review updatedReview,
            List<Image> newImages,
            string imagesUrlsToDelete)
        {
            await DeleteImagesAsync(updatedReview, imagesUrlsToDelete);
            updatedReview.Images.AddRange(newImages);
        }

        private async Task DeleteImagesAsync(Review updatedReview, string imagesUrlsToDelete)
        {
            if (string.IsNullOrWhiteSpace(imagesUrlsToDelete)) return;
            var urlsToDelete = imagesUrlsToDelete
                .Split(ImageViewModelConstrains.ImagesSeparator);
            var imagesToDelete = updatedReview.Images
                .Where(i => urlsToDelete.Contains(i.Url)).ToList();
            await _imageStoreService
                .DeleteImagesAsync(urlsToDelete);
            _unitOfWork.Images.RemoveRange(imagesToDelete);
        }
    }
}
