namespace DataLayer.Models
{
    public class Names
    {
        public string NameId { get; set; }
        public string? Name { get; set; }
        public string? BirthYear { get; set; }
        public string? DeathYear { get; set; }
        public float? AvgNameRating { get; set; }

        public override string ToString()
        {
            return $"{NameId}, {Name}, {BirthYear}, {DeathYear}, {AvgNameRating}";
        }
    }
}
