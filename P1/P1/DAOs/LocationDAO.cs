using System;
using System.Collections.Generic;
using System.Text;
using P1.Models;
using System.Linq;

namespace P1.DAOs
{
    class LocationDAO
    {
        internal static void AddLocation(Location l, P1Context DB)
        {
            DB.Locations.Add(l);
            DB.SaveChanges();
        }

        internal static void UpdateLocation(Location l, P1Context DB)
        {
            DB.Locations.Update(l);
            DB.SaveChanges();
        }

        internal static void RemoveLocation(Location l, P1Context DB)
        {
            DB.Locations.Remove(l);
            DB.SaveChanges();
        }

        internal static void LoadLocationsList(P1Context DB)
        {
            DB.LocationList = DB.Locations.ToList();
        }
    }
}
