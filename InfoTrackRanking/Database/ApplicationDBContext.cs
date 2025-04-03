using Microsoft.EntityFrameworkCore;

namespace InfoTrackRanking.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<RankHistory> RankHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the table name to be singular 'RankHistory instead of 'RankHistories'
            modelBuilder.Entity<RankHistory>().ToTable("RankHistory");
        }
    }
}
