using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;
using System.Threading;

namespace P0.DAOs
{
    class LocationProductsDAO
    {
        internal static void AddLocationProducts(LocationProducts lp, P0Context DB)
        {
            DB.LocationProducts.Add(lp);
            DB.SaveChanges();
            Thread.Sleep(500);
        }

        internal static void UpdateLocationProducts(LocationProducts lp, P0Context DB)
        {
            DB.LocationProducts.Update(lp);
            DB.SaveChanges();
        }

        internal static void RemoveLocationProducts(LocationProducts lp, P0Context DB)
        {
            DB.LocationProducts.Remove(lp);
            DB.SaveChanges();
        }

        internal static void LoadLocationProductsList(P0Context DB)
        {
            DB.LocationProductsList = DB.LocationProducts.ToList();
        }
    }
}
