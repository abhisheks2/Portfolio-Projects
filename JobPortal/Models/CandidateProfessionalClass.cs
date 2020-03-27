using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    [MetadataType(typeof(CandidateProfessionalMetaData))]
    public partial class CandidateProfessional
    {

    }
    public class CandidateProfessionalMetaData
    {
        [DisplayName("Candidate Id")]
        public Nullable<int> candidateId { get; set; }

        [DisplayName("Company")]
        public string company { get; set; }

        [DisplayName("Industry")]
        public string industry { get; set; }

        [DisplayName("Area")]
        [DataType(DataType.Text)]
        public Nullable<int> areaId { get; set; }

        [DisplayName("Role/Designation")]
        public string industryRole { get; set; }

        [DisplayName("Experience Years")]
        public Nullable<int> experienceYears { get; set; }

        [DisplayName("Experience Months")]
        public Nullable<int> experienceMonth { get; set; }

        [DisplayName("Salary")]
        [DataType(DataType.Currency)]
        public Nullable<int> salary { get; set; }

        [Required]
        [DisplayName("Skills")]
        public string skills { get; set; }
    }
}