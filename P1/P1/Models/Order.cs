using System;
using System.Collections.Generic;
using System.Text;

namespace P1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public string OrderTime { get; set; }
        public int BillingID { get; set; }
        public int ShippingID { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public Billing Billing { get; set; }
        public Shipping Shipping { get; set; }
        public List<ProductInStock> ShoppingCart { get; set; }
    }
}
