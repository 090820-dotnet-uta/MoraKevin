using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class OrderProductsDAO
    {
        internal static void AddOrderProducts(OrderProducts op, P0Context DB)
        {
            DB.OrderProducts.Add(op);
            DB.SaveChanges();
        }

        internal static void UpdateOrderProducts(OrderProducts op, P0Context DB)
        {
            DB.OrderProducts.Update(op);
            DB.SaveChanges();
        }

        internal static void RemoveOrderProducts(OrderProducts op, P0Context DB)
        {
            DB.OrderProducts.Remove(op);
            DB.SaveChanges();
        }

        internal static void LoadOrderProductsList(P0Context DB)
        {
            DB.OrderProductsList = DB.OrderProducts.ToList();
        }
    }
}
