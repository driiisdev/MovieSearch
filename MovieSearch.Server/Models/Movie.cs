namespace MovieSearch.Server.Models
{
    public class Movie
    {
        public required string Title { get; set; }
        public required string Year { get; set; }
        public required string imdbID { get; set; }
        public required string Type { get; set; }
        public required string Poster { get; set; }
        public required string Plot { get; set; }
        public required string imdbRating { get; set; }
    }
}
