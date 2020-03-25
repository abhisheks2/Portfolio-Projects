using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    [MetadataType(typeof(AreaMetaData))]
    public partial class Area
    {
    }

    public class AreaMetaData
    {
        [Required]
        [DisplayName("Industry")]
        public Nullable<int> category_id { get; set; }

        [Required]
        [DisplayName("Area")]
        public string area_name { get; set; }
    }
}