//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobTitle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobTitle()
        {
            this.JobPosts = new HashSet<JobPost>();
        }
    
        public int jobtitleId { get; set; }
        public string jobtitleName { get; set; }
        public Nullable<int> jobtitleAreaID { get; set; }
        public Nullable<int> jobtitleCategoryId { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPost> JobPosts { get; set; }
    }
}
