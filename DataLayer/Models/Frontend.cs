using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Frontend
    {
        public string TitleId { get; set; }
        public string Poster {  get; set; }
        public string Plot { get; set; }
        public MovieTitles MovieTitles { get; set; }


        public override string ToString()
        {
            return $"{TitleId}, {Poster}, {Plot}";
        }
    }
}
