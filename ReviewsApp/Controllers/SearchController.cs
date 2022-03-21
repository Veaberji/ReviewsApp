using Microsoft.AspNetCore.Mvc;
using ReviewsApp.Services;
using System.Threading.Tasks;

namespace ReviewsApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IActionResult> Index(string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return BadRequest();
            var models = await _searchService
                .GetResults(data);

            return View(models);
        }
    }
}
