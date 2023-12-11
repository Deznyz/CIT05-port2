using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public ICollection<BookmarksName> BookmarksName { get; set; }
        //public ICollection<UserRatings> UserRatings { get; set; }
        //public ICollection<BookmarksTitle> BookmarksTitles { get; set; }
        //public ICollection<SearchHistory> SearchHistory { get; set; }


        public override string ToString()
        {
            return $"{UserId}, {UserName}, {Password}";
        }
    }
}
