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
    
    public partial class wish
    {
        public int Id { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual user user { get; set; }
        public virtual attraction attraction { get; set; }
    }
}
