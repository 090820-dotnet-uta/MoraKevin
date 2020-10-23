using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class DefaultLocation
    {
        public int DefaultLocationID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
    }
}
