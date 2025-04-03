namespace InfoTrackRanking.Services
{
    public interface IScraperService
    {
        Task<List<int>> Scrape(string url);
    }
}
