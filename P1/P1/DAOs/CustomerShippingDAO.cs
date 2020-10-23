using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class CustomerShippingDAO
    {
        internal static void AddCustomerShipping(CustomerShipping cs, P1Context DB)
        {
            DB.CustomersShipping.Add(cs);
            DB.SaveChanges();
        }

        internal static void UpdateCustomersShipping(CustomerShipping cs, P1Context DB)
        {
            DB.CustomersShipping.Update(cs);
            DB.SaveChanges();
        }

        internal static void RemoveCustomersShipping(CustomerShipping cs, P1Context DB)
        {
            DB.CustomersShipping.Remove(cs);
            DB.SaveChanges();
        }

        internal static void LoadCustomersShippingList(P1Context DB)
        {
            DB.CustomerShippingList = DB.CustomersShipping.ToList();
        }
    }
}
