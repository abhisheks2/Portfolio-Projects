using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class DynamicActionLink
    {
        public string LinkName { get; set; }
        public string LinkAction { get; set; }
        public string LinkController { get; set; }
        public string LinkSearchBy { get; set; }
        public string LinkSearchValue { get; set; }
    }
}