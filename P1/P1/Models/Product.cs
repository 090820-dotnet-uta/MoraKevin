using System;
using System.Collections.Generic;
using System.Text;

namespace P1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public OrderProducts OrderProducts { get; set; }
        public LocationProducts LocationProducts { get; set; }
    }
}
