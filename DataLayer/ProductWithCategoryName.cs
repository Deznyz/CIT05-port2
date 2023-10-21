﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer
{
    public class ProductWithCategoryName
    {
        public Product Product { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return $"{Product}, {Name}, {ProductName}, {CategoryName}";
        }
    }
}