namespace DataLayer.Models
{
    public class NameWorkedAs
    {
        public string NameId { get; set; }
        public string Profession { get; set; }

        public override string ToString()
        {
            return $"{NameId}, {Profession}";
        }
    }
}
