namespace DataLayer.PostgresModels
{
    public class NameSearchResult
    {
        public string NameId { get; set; }
        public string? Name { get; set; }
        public double? Similarity { get; set; }
    }
}
