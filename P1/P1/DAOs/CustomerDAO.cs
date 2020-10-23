using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P1.Models;

namespace P1.DAOs
{
    public class CustomerDAO
    {
        public static void AddCustomer(Customer c, P1Context DB)
        {
            DB.Customers.Add(c);
            DB.SaveChanges();
        }

        internal static void UpdateCustomer(Customer c, P1Context DB)
        {
            DB.Customers.Update(c);
            DB.SaveChanges();
        }

        internal static void RemoveCustomer(Customer c, P1Context DB)
        {
            DB.Customers.Remove(c);
            DB.SaveChanges();
        }

        public static void LoadCustomersList(P1Context DB)
        {
            DB.CustomersList = DB.Customers.ToList();
        }
    }
}
