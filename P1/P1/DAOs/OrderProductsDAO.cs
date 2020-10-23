using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class OrderProductsDAO
    {
        internal static void AddOrderProducts(OrderProducts op, P1Context DB)
        {
            DB.OrderProducts.Add(op);
            DB.SaveChanges();
        }

        internal static void UpdateOrderProducts(OrderProducts op, P1Context DB)
        {
            DB.OrderProducts.Update(op);
            DB.SaveChanges();
        }

        internal static void RemoveOrderProducts(OrderProducts op, P1Context DB)
        {
            DB.OrderProducts.Remove(op);
            DB.SaveChanges();
        }

        internal static void LoadOrderProductsList(P1Context DB)
        {
            DB.OrderProductsList = DB.OrderProducts.ToList();
        }
    }
}
