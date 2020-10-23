using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P1.Models
{
    public class ProductInStock
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Max { get; set; }
        public Location Store { get; set; }
    }
}
