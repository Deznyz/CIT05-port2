namespace WebServer.Models
{
    public class MovieRatingsModel
    {
        public string Url { get; set; }
        public string? TitleId { get; set; }
        public float? AverageRating { get; set; }
        public int? NumVotes { get; set; }
        
    }
}
