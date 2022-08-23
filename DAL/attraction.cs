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
    
    public partial class attraction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public attraction()
        {
            this.equipments = new HashSet<equipment>();
            this.images = new HashSet<image>();
            this.wishes = new HashSet<wish>();
            this.generalTimes = new HashSet<generalTime>();
            this.opinions = new HashSet<opinion>();
            this.productToOrders = new HashSet<productToOrder>();
        }
    
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public int MinParticipant { get; set; }
        public int MaxParticipant { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public int FromAge { get; set; }
        public int TillAge { get; set; }
        public Nullable<bool> status { get; set; }
        public int DaysToCancel { get; set; }
        public System.DateTime date { get; set; }
        public int CategoryId { get; set; }
        public Nullable<int> TimeDuration { get; set; }
        public Nullable<int> AreaId { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual category category { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<equipment> equipments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<image> images { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wish> wishes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<generalTime> generalTimes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<opinion> opinions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productToOrder> productToOrders { get; set; }
    }
}