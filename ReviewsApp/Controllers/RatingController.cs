using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Services;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        private readonly GradeService _gradeService;

        public RatingController(GradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GradeReview(GradeViewModel model)
        {
            if (model is null) return BadRequest();
            var response = await _gradeService.GradeReview(model);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> RemoveGrade(int reviewId)
        {
            var response = await _gradeService.RemoveGrade(reviewId);
            return Json(response);
        }
    }
}
