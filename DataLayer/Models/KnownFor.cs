namespace DataLayer.Models
{
    public class KnownFor
    {
        public string NameId { get; set; }
        public string TitleId { get; set; }
        public Names Names { get; set; }
        public MovieTitles MovieTitles { get; set; }


        public override string ToString()
        {
            return $"{NameId}, {TitleId}";
        }
    }
}
