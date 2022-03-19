using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Services;
using ReviewsApp.ViewModels.MainReview.Components.Constrains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly ImageStoreService _imageStoreService;

        public ImageController(ImageStoreService imageStoreService)
        {
            _imageStoreService = imageStoreService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImages()
        {
            List<string> imageUrls;
            try
            {
                //IEnumerable<IFormFile> from parameter won't work
                var files = HttpContext.Request.Form.Files;
                imageUrls = await _imageStoreService
                    .UploadImagesAsync(files);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Json(imageUrls);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DeleteImages(string urls)
        {
            if (string.IsNullOrWhiteSpace(urls)) return;
            var files = urls.Split(ImageViewModelConstrains.ImagesSeparator);
            await _imageStoreService
                .DeleteImagesAsync(files);
        }

    }
}
