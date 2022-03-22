using ReviewsApp.Core.Utils;
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
        private readonly TagsService _tagsService;

        public ReviewService(IUnitOfWork unitOfWork,
            ImageStoreService imageStoreService,
            TagsService tagsService)
        {
            _unitOfWork = unitOfWork;
            _imageStoreService = imageStoreService;
            _tagsService = tagsService;
        }

        public async Task CreateReview(Review review, string userId)
        {
            review.AuthorId = userId;
            review.RowVersion = 1;
            _tagsService.SetTags(review);
            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateReview(Review updatedReview, Review values,
            string imagesToDelete)
        {
            updatedReview.Title = values.Title;
            updatedReview.Body = values.Body;
            updatedReview.AuthorGrade = values.AuthorGrade;
            _tagsService.UpdateTags(updatedReview, values.Tags);
            await UpdateImages(
                updatedReview, values.Images, imagesToDelete);
            updatedReview.RowVersion++;
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteReview(Review review)
        {
            var imagesUrls = review.Images.Select(image => image.Url).ToList();
            _unitOfWork.Products.Remove(review.Product);
            _tagsService.DeleteTags(review.Tags);
            await _imageStoreService.DeleteImagesAsync(imagesUrls);
            _unitOfWork.Comments.RemoveRange(review.Comments);
            _unitOfWork.Likes.RemoveRange(review.Likes);
            _unitOfWork.Reviews.Remove(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateImages(Review updatedReview,
            List<Image> newImages,
            string imagesUrlsToDelete)
        {
            await DeleteImagesAsync(updatedReview, imagesUrlsToDelete);
            updatedReview.Images.AddRange(newImages);
        }

        public bool IsLikedByUser(Review review, string userId)
        {
            return review.Likes
                .FirstOrDefault(l => l.AuthorId == userId) != null;
        }

        public static IEnumerable<ProductType> GetProductTypes()
        {
            return EnumUtils.GetValues<ProductType>();
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
