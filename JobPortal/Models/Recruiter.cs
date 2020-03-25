using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    public class Recruiter
    {
        
        [Required]
        [System.Web.Mvc.Remote("IsUserNameAvailable", "Home", ErrorMessage = "UserName already in use.")]
        [DisplayName("User Name")]
        public string username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string password { get; set; }

        [Compare("password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Secret Question")]
        public int Question { get; set; }
        
        [Required]
        public string Answer { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string companyName { get; set; }

        [Required]
        [DisplayName("Company Address")]
        public string companyAddr { get; set; }

        [Required]
        [DisplayName("Contact Person")]
        public string contactPerson { get; set; }

        [Required]
        [DisplayName("Company Contact")]
        public int companyContact { get; set; }

        [Required]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Compare("Email")]
        [DisplayName("Confirm Email")]
        public string ConfirmEmail { get; set; }

        [DisplayName("Company Details")]
        public string companyDetails { get; set; }
    }
}