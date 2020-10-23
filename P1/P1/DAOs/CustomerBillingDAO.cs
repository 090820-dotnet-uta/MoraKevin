using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class CustomerBillingDAO
    {
        internal static void AddCustomerBilling(CustomerBilling cb, P1Context DB)
        {
            DB.CustomersBilling.Add(cb);
            DB.SaveChanges();
        }

        internal static void UpdateCustomerBilling(CustomerBilling cb, P1Context DB)
        {
            DB.CustomersBilling.Update(cb);
            DB.SaveChanges();
        }

        internal static void RemoveCustomerBilling(CustomerBilling cb, P1Context DB)
        {
            DB.CustomersBilling.Remove(cb);
            DB.SaveChanges();
        }

        internal static void LoadCustomersBillingList(P1Context DB)
        {
            DB.CustomerBillingList = DB.CustomersBilling.ToList();
        }
    }
}
