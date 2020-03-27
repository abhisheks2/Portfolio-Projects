using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    [MetadataType(typeof(JobPostMetaData))]
    public partial class JobPost
    {

    }

    public class JobPostMetaData
    {
        [Required]
        [DisplayName("Industry")]
        [DataType(DataType.Text)]
        public Nullable<int> categoryId { get; set; }

        [Required]
        [DisplayName("Area")]
        [DataType(DataType.Text)]
        public Nullable<int> areaid { get; set; }

        [Required]
        [DisplayName("Job Title")]
        [DataType(DataType.Text)]
        public Nullable<int> jobTitleId { get; set; }

        [Required]
        [DisplayName("Job Type")]
        public string type { get; set; }

        [Required]
        [DisplayName("Job Location")]
        public string location { get; set; }

        [Required]
        [DisplayName("Skills Required")]
        public string skillsReq { get; set; }

        [DisplayName("Qualification Required")]
        public string educationReq { get; set; }

        [Required]
        [DisplayName("Job Description")]
        public string description { get; set; }

        [Required]
        [DisplayName("Contact Email")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string contactEmail { get; set; }

        [Required]
        [DisplayName("Salary/Rate")]
        [DataType(DataType.Currency)]
        public Nullable<int> salary { get; set; }

        [DisplayName("Job still available")]
        public Nullable<bool> isAvailable { get; set; }

        [DisplayName("Job Posted on")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> postedDate { get; set; }
    }
}