using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class OrderDAO
    {
        internal static void AddOrders(Order o, P1Context DB)
        {
            DB.Orders.Add(o);
            DB.SaveChanges();
        }

        internal static void UpdateOrders(Order o, P1Context DB)
        {
            DB.Orders.Update(o);
            DB.SaveChanges();
        }

        internal static void RemoveOrders(Order o, P1Context DB)
        {
            DB.Orders.Remove(o);
            DB.SaveChanges();
        }

        internal static void LoadOrdersList(P1Context DB)
        {
            DB.OrdersList = DB.Orders.ToList();
        }
    }
}
