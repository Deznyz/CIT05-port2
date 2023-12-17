namespace DataLayer.Models
{
    public class Aliases
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public bool IsOriginalTitle { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public MovieTitles MovieTitles { get; set; }

        public override string ToString()
        {
            return $"{TitleId}, {Ordering}, {Title}, {Region}, {Language}, {IsOriginalTitle}, {Types}, {Attributes}";
        }
    }
}

