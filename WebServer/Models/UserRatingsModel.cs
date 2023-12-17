namespace WebServer.Models
{
    public class UserRatingsModel
    {
        public string Url { get; set; }
        public int? UserId { get; set; }
        public int? UserRating {  get; set; }
        public string? TitleId { get; set; }
    }
}
