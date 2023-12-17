namespace DataLayer.Models
{
    public class MovieRatings
    {
        public string TitleId { get; set; }
        public float? AverageRating { get; set; }
        public int NumVotes { get; set; }
        public MovieTitles MovieTitles { get; set; }


        public override string ToString()
        {
            return $"{TitleId}, {AverageRating}, {NumVotes}";
        }
    }
}
