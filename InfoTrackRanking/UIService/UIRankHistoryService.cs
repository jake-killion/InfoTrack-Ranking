using InfoTrackRanking.Database;
using InfoTrackRanking.Models;

namespace InfoTrackRanking.UIService
{
    public class UIRankHistoryService : IUIRepositoryService<RankHistoryViewModel>
    {
        private readonly IRepository<RankHistory> _rankHistoryRepository;

        public UIRankHistoryService(IRepository<RankHistory> rankHistoryRepository)
        {
            _rankHistoryRepository = rankHistoryRepository;
        }

        public async Task<List<RankHistoryViewModel>> GetAllAsync()
        {
            List<RankHistory> rankHistories = await _rankHistoryRepository.GetAllAsync();
            return [.. rankHistories.Select(rankHistory => new RankHistoryViewModel
            {
                Id = rankHistory.Id,
                Ranks = rankHistory.Ranks,
                URL = rankHistory.URL,
                Keywords = rankHistory.Keywords,
                NumberOfSearchResults = rankHistory.NumberOfSearchResults,
                SearchDate = rankHistory.SearchDate
            })];
        }

        public async Task<RankHistoryViewModel> GetByIdAsync(int id)
        {
            RankHistory rankHistory = await _rankHistoryRepository.GetByIdAsync(id);
            return new RankHistoryViewModel
            {
                Id = rankHistory.Id,
                Ranks = rankHistory.Ranks,
                URL = rankHistory.URL,
                Keywords = rankHistory.Keywords,
                NumberOfSearchResults = rankHistory.NumberOfSearchResults,
                SearchDate = rankHistory.SearchDate
            };
        }

        public async Task AddAsync(RankHistoryViewModel rankHistoryViewModel)
        {
            RankHistory rankHistory = ToDbModel(rankHistoryViewModel);
            await _rankHistoryRepository.AddAsync(rankHistory);
        }

        public async Task UpdateAsync(RankHistoryViewModel rankHistoryViewModel)
        {
            RankHistory rankHistory = ToDbModel(rankHistoryViewModel);
            await _rankHistoryRepository.UpdateAsync(rankHistory);
        }

        public async Task DeleteAsync(int id)
        {
            await _rankHistoryRepository.DeleteAsync(id);
        }

        private RankHistory ToDbModel(RankHistoryViewModel rankingViewModel)
        {
            return new RankHistory
            {
                Id = rankingViewModel.Id,
                Ranks = rankingViewModel.Ranks,
                URL = rankingViewModel.URL,
                Keywords = rankingViewModel.Keywords,
                NumberOfSearchResults = rankingViewModel.NumberOfSearchResults,
                SearchDate = rankingViewModel.SearchDate
            };
        }
    }
}
