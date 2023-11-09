using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class EpisodeBelongsTo
    {
        public string EpisodeTitleId { get; set; }
        public string ParentTvShowTitleId { get; set; }
        public string SeasonNumber { get; set; }
        public string EpisodeNumber { get; set;}
        //public MovieTitles MovieTitlesChild { get; set; }
        //public MovieTitles MovieTitlesParent { get; set; }
        //måske en MovieTitles mere


        public override string ToString()
        {
            return $"{EpisodeTitleId}, {ParentTvShowTitleId}, {SeasonNumber}, {EpisodeNumber}";
        }
    }
}
