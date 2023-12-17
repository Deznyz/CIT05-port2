
namespace DataLayer.Models
{
    public class MovieTitles
    {
        public string TitleId { get; set; }
        public string? TitleType { get; set; }
        public string? PrimaryTitle {  get; set; }
        public string? OriginalTitle { get; set; }
        public bool? IsAdult { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public int? RuntimeMinutes { get; set; }
        public MovieRatings MovieRatings { get; set; }
        public ICollection<Genres> Genres { get; set; }
        public ICollection<Wi> Wi { get; set; }
        public ICollection<Frontend> Frontend { get; set; }
      
        public override string ToString()
        {
            return $"{TitleId}, {TitleType}, {PrimaryTitle}, {OriginalTitle}, {IsAdult}, {StartYear}, {EndYear}, {RuntimeMinutes}";
        }
    }
}
