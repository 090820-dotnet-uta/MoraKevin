using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class DefaultLocationDAO
    {
        internal static void AddDefaultLocation(DefaultLocation dl, P1Context DB)
        {
            DB.DefaultLocations.Add(dl);
            DB.SaveChanges();
        }

        internal static void UpdateDefaultLocation(DefaultLocation dl, P1Context DB)
        {
            DB.DefaultLocations.Update(dl);
            DB.SaveChanges();
        }

        internal static void RemoveDefaultLocation(DefaultLocation dl, P1Context DB)
        {
            DB.DefaultLocations.Remove(dl);
            DB.SaveChanges();
        }

        internal static void LoadDefaultLocationsList(P1Context DB)
        {
            DB.DefaultLocationList = DB.DefaultLocations.ToList();
        }
    }
}
