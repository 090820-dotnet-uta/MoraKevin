using System;
using System.Collections.Generic;
using System.Text;

namespace P1.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public int AddressNum { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public int AddressZipCode { get; set; }
        public string Description { get; set; }
        public LocationProducts LocationProducts { get; set; }
        public Order Order { get; set; }
        public DefaultLocation DefaultLocation { get; set; }
    }
}
