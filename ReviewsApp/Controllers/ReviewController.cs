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
                 await _unitOfWork.Reviews.GetPreviewsAsync(pageIndex);
            var amount = await _unitOfWork.Reviews.GetAmountOfReviewsAsync();
            var model = await CreateHomePageViewModel(
                pageIndex, amount, reviews, nameof(LastReviews));
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ReviewsWithTag(string tagText, int pageIndex = 1)
        {
            if (pageIndex < 1) pageIndex = 1;
            var tag = await _unitOfWork.Tags.GetByTextAsync(tagText);
            var reviews =
                await _unitOfWork.Reviews.GetPreviewsWithTagAsync(tag, pageIndex);
            var amount = await _unitOfWork.Reviews.GetAmountOfReviewsWithTagAsync(tag);
            var model = await CreateHomePageViewModel(
                pageIndex, amount, reviews, nameof(ReviewsWithTag));
            return View(nameof(LastReviews), model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> SingleReview(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var isUserAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            IEnumerable<Comment> comments = new List<Comment>();
            StarRatingViewModel starRating = null;
            if (isUserAuthenticated)
            {
                comments = await _unitOfWork.Comments
                    .GetReviewCommentsWithAuthorsAsync(review.Id);
                starRating = _mapper.Map<StarRatingViewModel>(review);
                starRating.CurrentUserRating =
                    review.Product.Grades.FirstOrDefault(
                        g => g.UserId == userId)?.Grade;
            }
            var model = new SingleReviewViewModel
            {
                Review = _mapper.Map<ReviewViewModel>(review),
                Comments = _mapper.Map<IEnumerable<CommentViewModel>>(comments),
                StarRating = starRating
            };
            model.Review.IsLikedByCurrentUser = review.Likes
                .FirstOrDefault(l => l.AuthorId == userId) != null;
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
                return RedirectToReviewPage(review.Id);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToReviewPage(model.ReviewId);
            }
            var review = await _unitOfWork.Reviews.GetByIdAsync(model.ReviewId);

            var authorId = _userManager.GetUserId(HttpContext.User);
            var comment = _mapper.Map<Comment>(model);
            comment.AuthorId = authorId;
            comment.ReviewId = review.Id;
            await _unitOfWork.Comments.AddAsync(comment);

            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                return RedirectToReviewPage(review.Id);
            }

            return RedirectToReviewPage(model.ReviewId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ChangeLike(int reviewId)
        {
            var authorId = _userManager.GetUserId(HttpContext.User);
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(reviewId);
            var like = review.Likes.FirstOrDefault(l => l.AuthorId == authorId);
            if (like != null)
            {
                _unitOfWork.Likes.Remove(like);
            }
            else
            {
                like = new Like
                {
                    AuthorId = authorId,
                    ReviewId = review.Id
                };
                await _unitOfWork.Likes.AddAsync(like);
            }
            await _unitOfWork.CompleteAsync();

            return Json(review.Likes.Count);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GradeReview(GradeViewModel model)
        {
            var reviewId = model.ReviewId;
            var authorId = _userManager.GetUserId(HttpContext.User);
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(reviewId);
            var userGrade = review.Product.Grades
                .FirstOrDefault(g => g.UserId == authorId);

            if (userGrade != null)
            {
                userGrade.Grade = model.Grade;
            }
            else
            {
                userGrade = new UserGrade
                {
                    UserId = authorId,
                    ProductId = review.ProductId,
                    Grade = model.Grade
                };
                await _unitOfWork.UserGrades.AddAsync(userGrade);
            }
            await _unitOfWork.CompleteAsync();
            var response = _mapper.Map<GradeResponseViewModel>(review);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> RemoveGrade(int reviewId)
        {
            var authorId = _userManager.GetUserId(HttpContext.User);
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(reviewId);
            var userGrade = review.Product.Grades
                .FirstOrDefault(g => g.UserId == authorId);
            if (userGrade != null)
            {
                _unitOfWork.UserGrades.Remove(userGrade);
                await _unitOfWork.CompleteAsync();
            }
            var response = _mapper.Map<GradeResponseViewModel>(review);
            return Json(response);
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










        public async Task<IActionResult> Details(int id)
        {
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            //map view model and return view
            return Ok();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            //map view model and return view
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateReviewViewModel model)
        {
            //m/b use EditViewModel
            //changeData for review and redirect to view
            return Ok();
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id.Value);
            if (review == null)
            {
                return NotFound();
            }
            //map view model and return view
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            //delete review

            return RedirectToAction("UserProfile", "Account",
                new { userName = review.Author.UserName });
        }










        private async Task<HomePageViewModel> CreateHomePageViewModel(int pageIndex,
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

        private IActionResult RedirectToReviewPage(int id)
        {
            return RedirectToAction("SingleReview", new { id });
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
