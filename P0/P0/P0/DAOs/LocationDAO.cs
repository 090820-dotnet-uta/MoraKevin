using System;
using System.Collections.Generic;
using System.Text;
using P0.Models;
using System.Linq;

namespace P0.DAOs
{
    class LocationDAO
    {
        internal static void AddLocation(Location l, P0Context DB)
        {
            DB.Locations.Add(l);
            DB.SaveChanges();
        }

        internal static void UpdateLocation(Location l, P0Context DB)
        {
            DB.Locations.Update(l);
            DB.SaveChanges();
        }

        internal static void RemoveLocation(Location l, P0Context DB)
        {
            DB.Locations.Remove(l);
            DB.SaveChanges();
        }

        internal static void LoadLocationsList(P0Context DB)
        {
            DB.LocationList = DB.Locations.ToList();
        }
    }
}
