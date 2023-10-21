using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer
{
    public class OrderDetails
    {
        public int UnitPrice {  get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }


        public override string ToString()
        {
            return $"{UnitPrice}, {Quantity}, {Discount}, {OrderId}, {ProductId}";
        }
    }
}
