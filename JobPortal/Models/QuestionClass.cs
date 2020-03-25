using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    [MetadataType(typeof(QuestionMetaData))]
    public partial class Question
    {
    }

    public class QuestionMetaData
    {
        [Required]
        [DisplayName("Question")]
        public string ques { get; set; }
    }
}