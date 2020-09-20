using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class CustomerShippingDAO
    {
        internal static void AddCustomerShipping(CustomerShipping cs, P0Context DB)
        {
            DB.CustomersShipping.Add(cs);
            DB.SaveChanges();
        }

        internal static void UpdateCustomersShipping(CustomerShipping cs, P0Context DB)
        {
            DB.CustomersShipping.Update(cs);
            DB.SaveChanges();
        }

        internal static void RemoveCustomersShipping(CustomerShipping cs, P0Context DB)
        {
            DB.CustomersShipping.Remove(cs);
            DB.SaveChanges();
        }

        internal static void LoadCustomersShippingList(P0Context DB)
        {
            DB.CustomerShippingList = DB.CustomersShipping.ToList();
        }
    }
}
