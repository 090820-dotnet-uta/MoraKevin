using System;
using System.Collections.Generic;
using System.Text;

namespace P0.Models
{
    public class Billing
    {
        public int BillingID { get; set; }
        public string NameOnCard { get; set; }
        public int CardNumber { get; set; }
        public int ExpirationMonth { get; set;  }
        public int ExpirationYear { get; set; }
        public int SecurityCode { get; set; }
        public int AddressNum { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public int AddressZipCode { get; set; }
        public CustomerBilling CustomerBilling { get; set; }
    }
}
