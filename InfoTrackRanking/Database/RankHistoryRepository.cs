
using Microsoft.EntityFrameworkCore;

namespace InfoTrackRanking.Database
{
    public class RankHistoryRepository : IRepository<RankHistory>
    {
        private readonly ApplicationDbContext _context;

        public RankHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RankHistory>> GetAllAsync()
        {
            return await _context.RankHistories.ToListAsync();
        }

        public async Task<RankHistory> GetByIdAsync(int id)
        {
            return await _context.RankHistories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(RankHistory rankHistory)
        {
            _context.RankHistories.Add(rankHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RankHistory rankHistory)
        {
            _context.RankHistories.Update(rankHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rankHistory = await _context.RankHistories.FirstOrDefaultAsync(x => x.Id == id);
            if (rankHistory != null)
            {
                _context.RankHistories.Remove(rankHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
