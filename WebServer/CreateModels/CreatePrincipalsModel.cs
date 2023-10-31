using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class CreatePrincipalsModel
    {
        public int PrincipalsId { get; set; }
        public string TitleId { get; set; }
        public int Ordering {  get; set; }
        public string NameId { get; set; }
        public string JobCategory {  get; set; }
        public string Job {  get; set; }
        public string Role {  get; set; }
        
    }
}
