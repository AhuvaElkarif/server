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
    
    public partial class report
    {
        public int Id { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> OpinionId { get; set; }
        public Nullable<int> ReportId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual kindReport kindReport { get; set; }
        public virtual opinion opinion { get; set; }
        public virtual user user { get; set; }
        public virtual attraction attraction { get; set; }
    }
}
