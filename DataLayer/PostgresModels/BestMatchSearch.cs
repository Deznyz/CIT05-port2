using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PostgresModels
{
    public class BestMatchSearch
    {
        public string? TitleId { get; set; }
        public string? Title { get; set; }
        public int? NumberOfMatches { get; set; }
    }
}
