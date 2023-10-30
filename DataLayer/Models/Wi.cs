using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Wi
    {
        public string TitleId { get; set; }
        public string Word {  get; set; }
        public string Field { get; set; }
        public string Lexeme { get; set; }
        public MovieTitles MovieTitles { get; set; }


        public override string ToString()
        {
            return $"{TitleId}, {Word}, {Field}, {Lexeme}";
        }
    }
}
