using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class DefaultLocation
    {
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
    }
}
