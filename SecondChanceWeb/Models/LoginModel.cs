using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondChanceWeb.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string message { get; set; }
        public string ReturnURL { get; set; }
        //[Display(Name = "Remember Me")]
        //public bool RememberMe { get; set; }
    }
}