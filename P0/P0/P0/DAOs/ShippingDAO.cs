using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class ShippingDAO
    {
        internal static void AddShippingInformation(Shipping info, P0Context DB)
        {
            DB.ShippingInformation.Add(info);
            DB.SaveChanges();
        }

        internal static void UpdateShippingInformation(Shipping info, P0Context DB)
        {
            DB.ShippingInformation.Update(info);
            DB.SaveChanges();
        }

        internal static void RemoveUserShippingInformation(Shipping info, P0Context DB)
        {
            DB.ShippingInformation.Remove(info);
            DB.SaveChanges();
        }

        internal static void LoadShippingInfomrationList(P0Context DB)
        {
            DB.ShippingInformationList = DB.ShippingInformation.ToList();
        }
    }
}
