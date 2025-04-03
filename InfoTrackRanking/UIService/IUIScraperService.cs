using InfoTrackRanking.Models;

namespace InfoTrackRanking.UIService
{
    public interface IUIScraperService
    {
        Task<RankingViewModel> Scrape(RankingViewModel request);
    }
}
