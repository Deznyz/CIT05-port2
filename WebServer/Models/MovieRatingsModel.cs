using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class MovieRatingsModel
    {
        public string Url { get; set; }
        public string? TitleId { get; set; }
        public float? AverageRating { get; set; }
        public int? NumVotes { get; set; }
        
    }
}
