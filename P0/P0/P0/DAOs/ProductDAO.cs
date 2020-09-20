using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P0.Models;

namespace P0.DAOs
{
    class ProductDAO
    {
        internal static void AddProduct(Product p, P0Context DB)
        {
            DB.Products.Add(p);
            DB.SaveChanges();
        }

        internal static void UpdateProduct(Product p, P0Context DB)
        {
            DB.Products.Update(p);
            DB.SaveChanges();
        }

        internal static void RemoveProduct(Product p, P0Context DB)
        {
            DB.Products.Remove(p);
            DB.SaveChanges();
        }

        internal static void LoadProductsList(P0Context DB)
        {
            DB.ProductsList = DB.Products.ToList();
        }
    }
}
