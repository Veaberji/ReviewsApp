using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.ViewModels;
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


        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> LastReviews(int pageIndex = 1)
        {
            var reviews =
                 await _unitOfWork.Reviews.GetReviewsWithAllInclusions(pageIndex);
            var tags = _unitOfWork.Tags.GetTopTags();
            var tagViewModels = tags.Select(tag =>
                _mapper.Map<TagCloudViewModel>(tag)).ToList();
            //todo: add pagination
            var model = new HomePageViewModel
            {
                Reviews = reviews,
                Tags = tagViewModels
            };
            return View(model);
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var review = _mapper.Map<Review>(model);
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

        //todo: add Review(int id)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AutoCompleteTag(string prefix)
        {
            var tags = _unitOfWork.Tags.GetTagsStartWith(prefix);
            var tagsViewModels = tags.Select(tag =>
                _mapper.Map<TagAutoCompeteViewModel>(tag)).ToList();

            return Json(tagsViewModels);
        }

        private IActionResult RedirectToCreateReviewPage()
        {
            return RedirectToAction("CreateReview");
        }

        //todo: change
        private async Task ChangeTags(Review review)
        {
            var tempTags = new List<Tag>();
            foreach (var tag in review.Tags)
            {
                if (tag.Text.Length == 0)
                {
                    continue;
                }
                var tagInDb = await _unitOfWork.Tags.GetByTextAsync(tag.Text);
                if (tagInDb != null && tagInDb.Text == tag.Text)
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
    }
}
