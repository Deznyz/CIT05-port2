namespace DataLayer.Models
{
    public class BookmarksName
    {
        public int UserId { get; set; }
        public string NameId { get; set; }
        public Names Names { get; set; }
        public Users Users { get; set; }


        public override string ToString()
        {
            return $"{UserId}, {NameId}";
        }
    }
}
