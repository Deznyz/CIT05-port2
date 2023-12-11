using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Names
    {
        public string NameId { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public float AvgNameRating { get; set; }
        //public ICollection<NameWorkedAs> NameWorkedAs { get; set; }
        //public ICollection<Principals> Principals { get; set; }
        //public ICollection<KnownFor> KnownFor { get; set; }
        //public ICollection<BookmarksName> BookmarksName { get; set; }



        public override string ToString()
        {
            return $"{NameId}, {Name}, {BirthYear}, {DeathYear}, {AvgNameRating}";
        }
    }
}
