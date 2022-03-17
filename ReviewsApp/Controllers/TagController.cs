using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Services;

namespace ReviewsApp.Controllers
{
    public class TagController : Controller
    {
        private readonly TagsService _tagsService;

        public TagController(TagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AutoCompleteTag(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix)) BadRequest();
            var tagsViewModels = _tagsService.GetSameTags(prefix);

            return Json(tagsViewModels);
        }
    }
}
