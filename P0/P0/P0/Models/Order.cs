using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public string OrderTime { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
    }
}
