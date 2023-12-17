namespace WebServer.Models
{
    public class CreateMovieRatingsModel
    {
        public string TitleId { get; set; }
        public float AverageRating { get; set; }
        public int NumVotes { get; set; }
    }
}
