﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class discoverIsraelEntities : DbContext
    {
        public discoverIsraelEntities()
            : base("name=discoverIsraelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<productToOrder> productToOrders { get; set; }
        public virtual DbSet<equipment> equipments { get; set; }
        public virtual DbSet<image> images { get; set; }
        public virtual DbSet<opinion> opinions { get; set; }
        public virtual DbSet<wish> wishes { get; set; }
        public virtual DbSet<generalTime> generalTimes { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<attraction> attractions { get; set; }
        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<period> periods { get; set; }
        public virtual DbSet<season> seasons { get; set; }
        public virtual DbSet<kindReport> kindReports { get; set; }
        public virtual DbSet<orderAttraction> orderAttractions { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<report> reports { get; set; }
    }
}
