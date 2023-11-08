using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.PostgresModels
{
    public class WeightedAverage
    {
        public double WeightedAverageForNameId {  get; set; }

        public override string ToString()
        {
            return $"{WeightedAverageForNameId}";
        }
    }
}
