using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class CustomerShipping
    {
        public int CustomerShippingID { get; set; }
        public int CustomerID { get; set; }
        public int ShippingID { get; set; }
        public string Main { get; set; }
        public Customer Customer { get; set; }
        public Shipping Shipping { get; set; }
    }
}
