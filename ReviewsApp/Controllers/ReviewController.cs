using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models.Common;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.Services;
using ReviewsApp.ViewModels.Home;
using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ImageManager _imageManager;
        private readonly PaginationService _paginationService;

        public ReviewController(IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<User> userManager,
            ImageManager imageManager,
            PaginationService paginationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _imageManager = imageManager;
            _paginationService = paginationService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> LastReviews(int pageIndex = 1)
        {
            if (pageIndex < 1) pageIndex = 1;
            var reviews =
                 await _unitOfWork.Reviews.GetReviewsForPreviews(pageIndex);
            var tags = _unitOfWork.Tags.GetTopTags();
            var tagViewModels = tags.Select(tag =>
                _mapper.Map<TagCloudViewModel>(tag)).ToList();
            var reviewsViewModels =
                _mapper.Map<IEnumerable<PreviewViewModel>>(reviews);
            var model = await CreateHomePageViewModel(pageIndex, reviewsViewModels, tagViewModels);
            return View(model);
        }

        //todo: add ReviewsWithTag(int tagId)

        [AllowAnonymous]
        public async Task<IActionResult> SingleReview(int id)
        {
            var isUserAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            var review = await _unitOfWork.Reviews.GetByIdAsync(id);
            IEnumerable<Comment> comments = new List<Comment>();
            if (isUserAuthenticated)
            {
                comments = await _unitOfWork.Comments
                    .GetReviewCommentsWithAuthorsAsync(review.Id);
            }

            var model = new SingleReviewViewModel
            {
                Review = _mapper.Map<PreviewViewModel>(review),
                Comments = _mapper.Map<IEnumerable<CommentViewModel>>(comments)
            };

            return View(model);
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(CreateReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var review = _mapper.Map<Review>(model);
            if (!string.IsNullOrEmpty(model.ImagesUrls))
            {
                var imageUrls = model.ImagesUrls.Split(",");
                review.Images = MapImages(imageUrls);
            }

            review.AuthorId = _userManager.GetUserId(HttpContext.User);
            await ChangeTags(review);
            await _unitOfWork.Reviews.AddAsync(review);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                //todo: redirect to created review
                return RedirectToCreateReviewPage();
            }

            return View(model);
        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var review = await _unitOfWork.Reviews.GetByIdAsync(model.ReviewId);
            var author = await _unitOfWork.Users.GetByIdAsync(model.AuthorId);
            var comment = _mapper.Map<Comment>(model);
            await _unitOfWork.Comments.AddAsync(comment);
            review.Comments.Add(comment);
            author.Comments.Add(comment);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                //todo: redirect to created review
                return RedirectToCreateReviewPage();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AutoCompleteTag(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                return Json(new TagAutoCompeteViewModel());
            }
            var tags = _unitOfWork.Tags.GetTagsStartWith(prefix);
            var tagsViewModels = tags.Select(tag =>
                _mapper.Map<TagAutoCompeteViewModel>(tag)).ToList();

            return Json(tagsViewModels);
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
                imageUrls = await _imageManager
                    .UploadImagesAsync(files);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("CreateReview");
            }

            return Json(imageUrls);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task DeleteImages(string urls)
        {
            if (string.IsNullOrWhiteSpace(urls))
            {
                return;
            }
            var files = urls.Split(",");
            await _imageManager
                .DeleteImagesAsync(files);
        }

        private async Task<HomePageViewModel> CreateHomePageViewModel(int pageIndex,
            IEnumerable<PreviewViewModel> reviewsViewModels,
            List<TagCloudViewModel> tagViewModels)
        {
            var pagesAmount = await _paginationService.GetPagesAmount();
            return new HomePageViewModel
            {
                Reviews = reviewsViewModels,
                Tags = tagViewModels,
                Pagination = new PaginationViewModel
                {
                    PageIndex = pageIndex,
                    PagesAmount = pagesAmount,
                    PreviousPage = _paginationService.GetPreviousPage(pageIndex),
                    NextPage = _paginationService.GetNextPage(pageIndex, pagesAmount)
                }
            };
        }

        private IActionResult RedirectToCreateReviewPage()
        {
            return RedirectToAction("CreateReview");
        }

        private async Task ChangeTags(Review review)
        {
            var tempTags = new List<Tag>();
            foreach (var tag in review.Tags)
            {
                if (tag.Text.Length == 0)
                {
                    continue;
                }
                var tagInDb = await _unitOfWork.Tags.GetByIdAsync(tag.Id);
                var isExistingTag = tagInDb is { Id: > 0 };
                if (isExistingTag)
                {
                    tagInDb.Count++;
                    tempTags.Add(tagInDb);
                }
                else
                {
                    tempTags.Add(tag);
                }
            }
            review.Tags = tempTags;
        }

        private IList<Image> MapImages(IEnumerable<string> imageUrls)
        {
            return _mapper.Map<IEnumerable<string>, List<Image>>(imageUrls);
        }
    }
}
