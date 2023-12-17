namespace WebServer.Models
{
    public class CreateMovieTitlesModel
    {
        public string TitleId { get; set; }
        public string? TitleType { get; set; }
        public string? PrimaryTitle {  get; set; }
        public string? OriginalTitle { get; set; }
        public bool? IsAdult { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public int? RuntimeMinutes { get; set; }
        
    }
}
