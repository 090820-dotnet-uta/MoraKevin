using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;
using System.Threading;

namespace P1.DAOs
{
    class LocationProductsDAO
    {
        internal static void AddLocationProducts(LocationProducts lp, P1Context DB)
        {
            DB.LocationProducts.Add(lp);
            DB.SaveChanges();
            Thread.Sleep(500);
        }

        internal static void UpdateLocationProducts(LocationProducts lp, P1Context DB)
        {
            DB.LocationProducts.Update(lp);
            DB.SaveChanges();
        }

        internal static void RemoveLocationProducts(LocationProducts lp, P1Context DB)
        {
            DB.LocationProducts.Remove(lp);
            DB.SaveChanges();
        }

        internal static void LoadLocationProductsList(P1Context DB)
        {
            DB.LocationProductsList = DB.LocationProducts.ToList();
        }
    }
}
