using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PostgresModels
{
    public class AssociatedWords
    {
        public string titleId { get; set; }

        public string associatedWord { get; set; }

        public int Num { get; set; }
    }
}
