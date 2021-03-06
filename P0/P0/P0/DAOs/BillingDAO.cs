﻿using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class BillingDAO
    {
        internal static void AddBilling(Billing b, P0Context DB)
        {
            DB.BillingInformation.Add(b);
            DB.SaveChanges();
        }

        internal static void UpdateBilling(Billing b, P0Context DB)
        {
            DB.BillingInformation.Update(b);
            DB.SaveChanges();
        }

        internal static void RemoveBilling(Billing b, P0Context DB)
        {
            DB.BillingInformation.Remove(b);
            DB.SaveChanges();
        }

        internal static void LoadBillingList(P0Context DB)
        {
            DB.BillingInformationList = DB.BillingInformation.ToList();
        }
    }
}
