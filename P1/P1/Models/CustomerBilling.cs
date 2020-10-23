using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class CustomerBilling
    {
        public int CustomerBillingID { get; set; }
        public int CustomerID{ get; set; }
        public int BillingID { get; set; }
        public string Main { get; set; }
        public Customer Customer { get; set; }
        public Billing Billing { get; set; }
    }
}
