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
    
    public partial class orderAttraction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orderAttraction()
        {
            this.productToOrders = new HashSet<productToOrder>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public int GlobalPrice { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> AttractionId { get; set; }
    
        public virtual attraction attraction { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productToOrder> productToOrders { get; set; }
    }
}
