using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly UserService _userService;


        public ReviewController(IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<User> userManager,
            ImageManager imageManager,
            PaginationService paginationService,
            UserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _imageManager = imageManager;
            _paginationService = paginationService;
            _userService = userService;
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
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            var isUserAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false;
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
            review.Images = MapImages(model.ImagesUrls);
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
            if (!await IsAllowedUser(review))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var model = _mapper.Map<ReviewDetailsViewModel>(review);
            return View(model);
        }









        public async Task<IActionResult> Edit(int id)
        {
            var review = await _unitOfWork.Reviews.GetFullReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            if (!await IsAllowedUser(review))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var model = _mapper.Map<ReviewEditViewModel>(review);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReviewEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //todo: test it
            var updatedReview = await _unitOfWork.Reviews.GetFullReviewByIdAsync(model?.Id ?? 0);
            if (model == null && updatedReview == null)
            {
                return NotFound();
            }
            if (!await IsAllowedUser(updatedReview))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            var values = _mapper.Map<Review>(model);
            updatedReview.Title = values.Title;
            updatedReview.Body = values.Body;
            updatedReview.AuthorGrade = values.AuthorGrade;
            var oldImages = MapImages(model.OldImagesUrls);
            var newImages = MapImages(model.ImagesUrls);
            await UpdateTags(updatedReview, values.Tags);

            await DeleteImagesAsync(updatedReview, oldImages);
            foreach (var image in newImages)
            {
                updatedReview.Images.Add(image);
            }

            await _unitOfWork.CompleteAsync();
            return RedirectToReviewPage(updatedReview.Id);
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








        private async Task<bool> IsAllowedUser(Review review)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (await _userService.IsAllowedUser(review.Author.UserName, user))
            {
                return true;
            }

            return false;
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

        private async Task UpdateTags(Review updatedReview, IList<Tag> tags)
        {
            DeleteTags(updatedReview, tags);
            await AddNewTagsAsync(updatedReview, tags);
        }

        private void DeleteTags(Review updatedReview, IList<Tag> tags)
        {
            var tagsToDelete =
                updatedReview.Tags.Where(t => !tags.Contains(t)).ToList();
            foreach (var tag in tagsToDelete)
            {
                updatedReview.Tags.Remove(tag);
                if (tag.Count > 1)
                {
                    tag.Count--;
                }
                else
                {
                    _unitOfWork.Tags.Remove(tag);
                }
            }
        }

        private async Task AddNewTagsAsync(Review updatedReview, IList<Tag> tags)
        {
            var newTags = tags.Where(t => IsNewTag(updatedReview, t)).ToList();
            var updatedNewTags = await GetTagsWithCounts(newTags);
            foreach (var tag in updatedNewTags)
            {
                updatedReview.Tags.Add(tag);
            }
        }


        //private async Task UpdateImages(Review updatedReview, IList<Image> images)
        //{
        //    await DeleteImages(updatedReview, images);
        //    await AddNewImages(updatedReview, tags);
        //}

        private async Task DeleteImagesAsync(Review updatedReview, IList<Image> images)
        {
            var imagesToDelete =
                updatedReview.Images.Where(i => !images.Contains(i)).ToList();
            await _imageManager
                .DeleteImagesAsync(imagesToDelete.Select(i => i.Url).ToArray());
            _unitOfWork.Images.RemoveRange(imagesToDelete);
        }

        private async Task ChangeTags(Review review)
        {
            review.Tags = await GetTagsWithCounts(review.Tags);
        }

        private async Task<List<Tag>> GetTagsWithCounts(IList<Tag> tags)
        {
            var tempTags = new List<Tag>();
            foreach (var tag in tags)
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
            return tempTags;
        }

        private static bool IsNewTag(Review updatedReview, Tag tag)
        {
            return !updatedReview.Tags.Select(t => t.Text).Contains(tag.Text);
        }

        private IList<Image> MapImages(string imageUrls)
        {
            if (string.IsNullOrEmpty(imageUrls))
            {
                return new List<Image>();
            }
            var images = imageUrls.Split(",");
            return _mapper.Map<IEnumerable<string>, List<Image>>(images) ?? new List<Image>();
        }
    }
}
