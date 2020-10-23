using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class LocationProducts
    {
        public int LocationProductsID { get; set; }
        public int LocationID { get; set; }
        public int ProductID { get; set; }
        public int Inventory { get; set; }
        public Location Location { get; set; }
        public Product Product { get; set; }
    }
}
