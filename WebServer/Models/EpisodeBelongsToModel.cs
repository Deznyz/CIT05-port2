namespace WebServer.Models
{
    public class EpisodeBelongsToModel
    {
        public string Url { get; set; }
        public string? EpisodeTitleId { get; set; }
        public string? ParentTvShowTitleId { get; set; }
        public string? SeasonNumber { get; set; }
        public string? EpisodeNumber { get; set;}
        
    }
}
