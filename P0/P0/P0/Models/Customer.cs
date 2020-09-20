using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Order Order { get; set; }
        public CustomerBilling CustomerBilling { get; set; }
        public CustomerShipping CustomerShipping { get; set; }
        public DefaultLocation DefaultLocation { get; set; }

    }
}
