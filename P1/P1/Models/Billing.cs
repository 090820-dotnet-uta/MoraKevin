using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P1.Models
{
    public class Billing
    {
        public int BillingID { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        [Required, MinLength(16), MaxLength(16)]
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        [Required]
        public int SecurityCode { get; set; }
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
        public CustomerBilling CustomerBilling { get; set; }
    }
}
