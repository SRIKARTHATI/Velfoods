﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VelfoodsApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class velfoodsEntities2 : DbContext
    {
        public velfoodsEntities2()
            : base("name=velfoodsEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<vel_restro_empdepartment> vel_restro_empdepartment { get; set; }
        public virtual DbSet<vel_restro_empregistration> vel_restro_empregistration { get; set; }
        public virtual DbSet<vel_restro_itemcategory> vel_restro_itemcategory { get; set; }
        public virtual DbSet<vel_restro_itemname> vel_restro_itemname { get; set; }
        public virtual DbSet<vel_restro_manger> vel_restro_manger { get; set; }
        public virtual DbSet<vel_restro_miscollection> vel_restro_miscollection { get; set; }
        public virtual DbSet<vel_restro_offers> vel_restro_offers { get; set; }
        public virtual DbSet<vel_restro_order> vel_restro_order { get; set; }
        public virtual DbSet<vel_restro_paidouts> vel_restro_paidouts { get; set; }
        public virtual DbSet<vel_restro_property> vel_restro_property { get; set; }
        public virtual DbSet<vel_restro_restaurent> vel_restro_restaurent { get; set; }
        public virtual DbSet<vel_restro_tablebooking> vel_restro_tablebooking { get; set; }
        public virtual DbSet<vel_restro_tabledefination> vel_restro_tabledefination { get; set; }
        public virtual DbSet<vel_restro_tax> vel_restro_tax { get; set; }
        public virtual DbSet<vel_restro_banks> vel_restro_banks { get; set; }
        public virtual DbSet<vel_restro_wallet> vel_restro_wallet { get; set; }
        public virtual DbSet<vel_restro_billpayment> vel_restro_billpayment { get; set; }
        public virtual DbSet<vel_restro_billstatus> vel_restro_billstatus { get; set; }
        public virtual DbSet<vel_restro_print> vel_restro_print { get; set; }
    }
}
