using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class NameWorkedAs
    {
        public string NameId { get; set; }
        public string Profession { get; set; }
        //public Names Names { get; set; }


        public override string ToString()
        {
            return $"{NameId}, {Profession}";
        }
    }
}
