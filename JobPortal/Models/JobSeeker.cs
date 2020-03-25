using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    public class JobSeeker
    {
        //Login fields
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

        //Basic(personal) info fields
        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Address")]
        public string candidateAddr { get; set; }

        [Required]
        [DisplayName("City")]
        public string city { get; set; }

        [DisplayName("Gender")]
        public string gender { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dob { get; set; }

        [DisplayName("Contact no.")]
        public Nullable<int> contactNo { get; set; }

        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string emailId { get; set; }

        [Compare("emailId")]
        [DisplayName("Confirm Email")]
        public string ConfirmEmail { get; set; }

        //Education info fields
        [DisplayName("A Level Subject 1")]
        public string aLevelSubject1 { get; set; }

        [DisplayName("A Level Subject 2")]
        public string aLevelSubject2 { get; set; }

        [DisplayName("A Level Subject 3")]
        public string aLevelSubject3 { get; set; }

        [DisplayName("A Level Subject 1 Grade")]
        [Range(1,9)]
        public Nullable<int> aLevelGrade1 { get; set; }

        [Range(1, 9)]
        [DisplayName("A Level Subject 2 Grade")]
        public Nullable<int> aLevelGrade2 { get; set; }

        [Range(1, 9)]
        [DisplayName("A Level Subject 3 Grade")]
        public Nullable<int> aLevelGrade3 { get; set; }

        [DisplayName("Graduation")]
        public string graduation { get; set; }

        [DisplayName("Graduation Insutitute/University")]
        public string instituteGrad { get; set; }

        [DisplayName("Graduation Percentage")]
        public Nullable<decimal> percentageGrad { get; set; }

        [DisplayName("Post Graduation")]
        public string postGrad { get; set; }

        [DisplayName("Post Graduation Institute/Unoversity")]
        public string institutePostGrad { get; set; }

        [DisplayName("Post Graduation Percenrage")]
        public Nullable<decimal> percentagePostGrad { get; set; }

        [DisplayName("Certifications")]
        public string certification { get; set; }

        //Professional experience info fields
        [DisplayName("Current Company")]
        public string company { get; set; }

        [DisplayName("Industry")]
        public string industry { get; set; }

        public string Area { get; set; }

        [DisplayName("Current Role/Designation")]
        public string industryRole { get; set; }

        [DisplayName("Years")]
        public Nullable<int> experienceYears { get; set; }

        [DisplayName("Months")]
        public Nullable<int> experienceMonth { get; set; }

        [DisplayName("Current Salary")]
        public Nullable<int> salary { get; set; }

        [Required]
        [DisplayName("Skills")]
        public string skills { get; set; }
    }
}