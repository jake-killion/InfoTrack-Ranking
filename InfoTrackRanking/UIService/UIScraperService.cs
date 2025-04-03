using InfoTrackRanking.Models;
using InfoTrackRanking.Services;

namespace InfoTrackRanking.UIService
{
    public class UIScraperService : IUIScraperService
    {
        IScraperService _scraperService;
        IUIRepositoryService<RankHistoryViewModel> _uIRankHistoryService;
        public UIScraperService(IScraperService scraperService, IUIRepositoryService<RankHistoryViewModel> uIRankHistoryService)
        {
            _scraperService = scraperService;
            _uIRankHistoryService = uIRankHistoryService;
        }

        public async Task<RankingViewModel> Scrape(RankingViewModel request)
        {
            string newUrl = $"{request.Url}/search?num={request.NumberOfSearchResults}&q={request.Keywords.Replace(" ", "+")}";
            List<int> rankings = await _scraperService.Scrape(newUrl);
            request.Url = newUrl;
            request.Rankings = rankings;
            await _uIRankHistoryService.AddAsync(new RankHistoryViewModel
            {
                Ranks = rankings.Count == 0 ? "0 (Not Found)" : string.Join(", ", rankings),
                URL = newUrl,
                Keywords = request.Keywords,
                NumberOfSearchResults = request.NumberOfSearchResults,
                SearchDate = DateTime.Now
            });
            return request;
        }
    }
}
