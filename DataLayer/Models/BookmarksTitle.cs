using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BookmarksTitle
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public MovieTitles MovieTitles { get; set; }
        public Users Users { get; set; }


        public override string ToString()
        {
            return $"{UserId}, {TitleId}";
        }
    }
}
