using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting;
using System.Text;

namespace P1.Models
{
    public class UserAccount
    {

        [Key]
        //[Remote(action: "VerifyUsername", controller: "Input")]
        public string Username { get; set; }
        public string Password { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}