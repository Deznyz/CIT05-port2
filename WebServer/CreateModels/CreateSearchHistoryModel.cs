using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class CreateSearchHistoryModel
    {
        public int SearchHistoryId { get; set; }
        public int UserId { get; set; }
        public string Searched {  get; set; }
    }
}
