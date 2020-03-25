using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    [MetadataType(typeof(CandidateEducationMetadata))]
    public partial class CandidateEducation
    {
    }

    public class CandidateEducationMetadata
    {
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
    }
}