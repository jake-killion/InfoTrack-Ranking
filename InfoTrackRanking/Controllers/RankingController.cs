using InfoTrackRanking.Models;
using InfoTrackRanking.UIService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfoTrackRanking.Controllers
{
    public class RankingController : Controller
    {
        private readonly ILogger<RankingController> _logger;
        private readonly IUIScraperService _uiScraperService;

        public RankingController(ILogger<RankingController> logger, IUIScraperService uiScraperService)
        {
            _logger = logger;
            _uiScraperService = uiScraperService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RankingViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Keywords) || string.IsNullOrWhiteSpace(request.Url) || request.NumberOfSearchResults == 0)
            {
                ModelState.AddModelError("", "The keyword(s), URL, and Number Of Search Results fields are required.");
                return View();
            }

            var response = await _uiScraperService.Scrape(request);
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
