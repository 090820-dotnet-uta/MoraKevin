using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class OrderDAO
    {
        internal static void AddOrders(Order o, P0Context DB)
        {
            DB.Orders.Add(o);
            DB.SaveChanges();
        }

        internal static void UpdateOrders(Order o, P0Context DB)
        {
            DB.Orders.Update(o);
            DB.SaveChanges();
        }

        internal static void RemoveOrders(Order o, P0Context DB)
        {
            DB.Orders.Remove(o);
            DB.SaveChanges();
        }

        internal static void LoadOrdersList(P0Context DB)
        {
            DB.OrdersList = DB.Orders.ToList();
        }
    }
}
