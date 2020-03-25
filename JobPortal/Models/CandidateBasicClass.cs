using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    [MetadataType(typeof(CandidateBasicMetaData))]
    public partial class CandidateBasic
    {
    }

    public class CandidateBasicMetaData
    {
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dob { get; set; }

        [DisplayName("Address")]
        public string candidateAddr { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        public Nullable<int> contactNo { get; set; }

        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string emailId { get; set; }

        [Required]
        [DisplayName("City")]
        public string city { get; set; }
    }
}