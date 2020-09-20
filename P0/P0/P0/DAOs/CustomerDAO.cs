using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P0.Models;

namespace P0.DAOs
{
    class CustomerDAO
    {
        internal static void AddCustomer(Customer c, P0Context DB)
        {
            DB.Customers.Add(c);
            DB.SaveChanges();
        }

        internal static void UpdateCustomer(Customer c, P0Context DB)
        {
            DB.Customers.Update(c);
            DB.SaveChanges();
        }

        internal static void RemoveCustomer(Customer c, P0Context DB)
        {
            DB.Customers.Remove(c);
            DB.SaveChanges();
        }

        internal static void LoadCustomersList(P0Context DB)
        {
            DB.CustomersList = DB.Customers.ToList();
        }
    }
}
