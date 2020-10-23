using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P1.Models;

namespace P1.DAOs
{
    class ProductDAO
    {
        internal static void AddProduct(Product p, P1Context DB)
        {
            DB.Products.Add(p);
            DB.SaveChanges();
        }

        internal static void UpdateProduct(Product p, P1Context DB)
        {
            DB.Products.Update(p);
            DB.SaveChanges();
        }

        internal static void RemoveProduct(Product p, P1Context DB)
        {
            DB.Products.Remove(p);
            DB.SaveChanges();
        }

        internal static void LoadProductsList(P1Context DB)
        {
            DB.ProductsList = DB.Products.ToList();
        }
    }
}
