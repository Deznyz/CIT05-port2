using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MovieTitles
    {
        public string TitleId { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle {  get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int RuntimeMinutes { get; set; }
        public MovieRatings MovieRatings { get; set; }
        public ICollection<Genres> Genres { get; set; }
        public ICollection<Wi> Wi { get; set; }
        public ICollection<Frontend> Frontend { get; set; }
        //public ICollection<EpisodeBelongsTo> EpisodeBelongsToChild { get; set; }
        //public ICollection<EpisodeBelongsTo> EpisodeBelongsToParent { get; set; }
        //måske en EpisdodeBelongsTo mere
        public ICollection<Principals> Principals { get; set; }
        public ICollection<KnownFor> KnownFor { get; set; }
        public ICollection<UserRatings> UserRatings { get; set; }
        public ICollection<BookmarksTitle> BookmarksTitle { get; set; }
        public ICollection<Aliases> Aliases { get; set; }


        public override string ToString()
        {
            return $"{TitleId}, {TitleType}, {PrimaryTitle}, {OriginalTitle}, {IsAdult}, {StartYear}, {EndYear}, {RuntimeMinutes}";
        }
    }
}
