namespace InfoTrackRanking.Models
{
    public class RankingViewModel
    {
        public string Keywords { get; set; }
        public string Url { get; set; } = "https://www.google.co.uk";
        public int NumberOfSearchResults { get; set; }
        public List<int> Rankings { get; set; }
    }
}
