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
    
    public partial class opinion
    {
        public int Id { get; set; }
        public string OpinionText { get; set; }
        public int AttractionId { get; set; }
        public int UserId { get; set; }
        public System.DateTime InsertDate { get; set; }
        public double Grading { get; set; }
    
        public virtual user user { get; set; }
        public virtual attraction attraction { get; set; }
    }
}
