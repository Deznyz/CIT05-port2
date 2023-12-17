

namespace DataLayer.Models
{
    public class Principals
    {
        public int PrincipalsId { get; set; }
        public string TitleId { get; set; }
        public int Ordering {  get; set; }
        public string NameId { get; set; }
        public string JobCategory {  get; set; }
        public string Job {  get; set; }
        public string Role {  get; set; }
        public override string ToString()
        {
            return $"{PrincipalsId}, {TitleId}, {Ordering}, {NameId}, {JobCategory}, {Job}, {Role}";
        }
    }
}
