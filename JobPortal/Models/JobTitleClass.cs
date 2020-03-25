using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    [MetadataType(typeof(JobTitleMetaData))]
    public partial class JobTitle
    {
    }

    public class JobTitleMetaData
    {
        [DisplayName("Job Title")]
        [Required]
        public string jobtitleName { get; set; }

        [Required]
        [DisplayName("Area")]
        [DataType(DataType.Text)]
        public Nullable<int> jobtitleAreaID { get; set; }

        [Required]
        [DisplayName("Industry")]
        [DataType(DataType.Text)]
        public Nullable<int> jobtitleCategoryId { get; set; }
    }
}