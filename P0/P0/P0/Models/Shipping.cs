using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Shipping
    {
        public int ShippingID { get; set; }
        public int AddressNum { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipCode { get; set; }
        public CustomerShipping CustomerShipping { get; set; }
    }
}
