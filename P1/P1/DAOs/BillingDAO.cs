using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class BillingDAO
    {
        internal static void AddBilling(Billing b, P1Context DB)
        {
            DB.BillingInformation.Add(b);
            DB.SaveChanges();
        }

        internal static void UpdateBilling(Billing b, P1Context DB)
        {
            DB.BillingInformation.Update(b);
            DB.SaveChanges();
        }

        internal static void RemoveBilling(Billing b, P1Context DB)
        {
            DB.BillingInformation.Remove(b);
            DB.SaveChanges();
        }

        internal static void LoadBillingList(P1Context DB)
        {
            DB.BillingInformationList = DB.BillingInformation.ToList();
        }
    }
}
