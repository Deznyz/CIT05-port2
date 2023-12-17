namespace DataLayer.Models
{
    public class SearchHistory
    {
        public int SearchHistoryId { get; set; }
        public int UserId { get; set; }
        public string Searched {  get; set; }

        public override string ToString()
        {
            return $"{SearchHistoryId}, {UserId}, {Searched}";
        }
    }
}
