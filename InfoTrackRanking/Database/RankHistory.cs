namespace InfoTrackRanking.Database
{
    public class RankHistory
    {
        public int Id { get; set; }
        public string Ranks { get; set; }
        public string URL { get; set; }
        public string Keywords { get; set; }
        public int NumberOfSearchResults { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
