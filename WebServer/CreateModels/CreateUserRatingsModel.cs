namespace WebServer.Models
{
    public class CreateUserRatingsModel
    {
        public int UserId { get; set; }
        public int UserRating {  get; set; }
        public string TitleId { get; set; }
    }
}
