namespace MovieSearch.Server.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public required string SearchTerm { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
