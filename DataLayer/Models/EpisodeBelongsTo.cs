namespace DataLayer.Models
{
    public class EpisodeBelongsTo
    {
        public string EpisodeTitleId { get; set; }
        public string ParentTvShowTitleId { get; set; }
        public string SeasonNumber { get; set; }
        public string EpisodeNumber { get; set;}

        public override string ToString()
        {
            return $"{EpisodeTitleId}, {ParentTvShowTitleId}, {SeasonNumber}, {EpisodeNumber}";
        }
    }
}
