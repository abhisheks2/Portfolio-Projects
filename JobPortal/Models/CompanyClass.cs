using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    [MetadataType(typeof(CompanyMetaData))]
    public partial class Company
    {
    }

    public class CompanyMetaData
    {
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
        public Nullable<int> companyContact { get; set; }

        [DisplayName("Company Details")]
        public string companyDetails { get; set; }

        [Required]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Company Email")]
        public string companyEmail { get; set; }
    }
}