using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class Shipping
    {
        public int ShippingID { get; set; }
        [Required]
        public int AddressNum { get; set; }
        [Required]
        public string AddressStreet { get; set; }
        [Required]
        public string AddressCity { get; set; }
        [Required]
        public string AddressState { get; set; }
        [Required]
        public string AddressZipCode { get; set; }
        public CustomerShipping CustomerShipping { get; set; }
    }
}
