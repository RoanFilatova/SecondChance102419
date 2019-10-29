using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondChanceWeb.Models
{
    public class RegistrationModel
    {
        public string Message { get; set; }
        [Required(ErrorMessage = "Please enter a UserName." )]
        [StringLength(30, MinimumLength = 7)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an address")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [StringLength(MuhConstants.MaxPasswordLength,
           ErrorMessage = "The {0} must be between {2} and {1} characters long.",
           MinimumLength = MuhConstants.MinPasswordLength)]
        [RegularExpression(MuhConstants.PasswordRequirements,
           ErrorMessage = MuhConstants.PasswordRequirementsMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password Again")]
        public string PasswordAgain { get; set; }
        [Required(ErrorMessage = "Please enter an Email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    
    }
}