using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortal.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public class UserMetaData
    {
        [Required]
        [System.Web.Mvc.Remote("IsUserNameAvailable", "Admin", "Admin", ErrorMessage = "UserName already in use.")]
        [DisplayName("User Name")]
        public string username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [DisplayName("Role")]
        public string role { get; set; }
    }
}