//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class period
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public period()
        {
            this.generalTimes = new HashSet<generalTime>();
        }
    
        public int Id { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime TillDate { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<bool> IsOpen { get; set; }
        public Nullable<int> SeasonId { get; set; }
    
        public virtual season season { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<generalTime> generalTimes { get; set; }
        public virtual attraction attraction { get; set; }

       
    }
}
