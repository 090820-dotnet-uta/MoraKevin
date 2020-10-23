using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class ShippingDAO
    {
        internal static void AddShippingInformation(Shipping info, P1Context DB)
        {
            DB.ShippingInformation.Add(info);
            DB.SaveChanges();
        }

        internal static void UpdateShippingInformation(Shipping info, P1Context DB)
        {
            DB.ShippingInformation.Update(info);
            DB.SaveChanges();
        }

        internal static void RemoveUserShippingInformation(Shipping info, P1Context DB)
        {
            DB.ShippingInformation.Remove(info);
            DB.SaveChanges();
        }

        internal static void LoadShippingInfomrationList(P1Context DB)
        {
            DB.ShippingInformationList = DB.ShippingInformation.ToList();
        }
    }
}
