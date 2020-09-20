using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class DefaultLocationDAO
    {
        internal static void AddDefaultLocation(DefaultLocation dl, P0Context DB)
        {
            DB.DefaultLocations.Add(dl);
            DB.SaveChanges();
        }

        internal static void UpdateDefaultLocation(DefaultLocation dl, P0Context DB)
        {
            DB.DefaultLocations.Update(dl);
            DB.SaveChanges();
        }

        internal static void RemoveDefaultLocation(DefaultLocation dl, P0Context DB)
        {
            DB.DefaultLocations.Remove(dl);
            DB.SaveChanges();
        }

        internal static void LoadDefaultLocationsList(P0Context DB)
        {
            DB.DefaultLocationList = DB.DefaultLocations.ToList();
        }
    }
}
