using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required, MinLength(1), MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MinLength(1), MaxLength(20)]
        public string LastName { get; set; }
        public Order Order { get; set; }
        public CustomerBilling CustomerBilling { get; set; }
        public CustomerShipping CustomerShipping { get; set; }
        public DefaultLocation DefaultLocation { get; set; }

    }
}
