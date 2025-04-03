using InfoTrackRanking.Models;
using InfoTrackRanking.UIService;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackRanking.Controllers
{
    public class RankHistoryController : Controller
    {
        private readonly IUIRepositoryService<RankHistoryViewModel> _rankHistoryService;

        public RankHistoryController(IUIRepositoryService<RankHistoryViewModel> rankHistoryService)
        {
            _rankHistoryService = rankHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var rankHistories = await _rankHistoryService.GetAllAsync();
            return View(rankHistories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RankHistoryViewModel model)
        {
            await _rankHistoryService.AddAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RankHistoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _rankHistoryService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            var rankHistories = await _rankHistoryService.GetAllAsync();
            return View("Index", rankHistories);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _rankHistoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
