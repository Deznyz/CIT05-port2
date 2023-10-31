using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class BookmarksTitleModel
    {
        public string Url { get; set; }
        public int? UserId { get; set; }
        public string? TitleId { get; set; }
    }
}
