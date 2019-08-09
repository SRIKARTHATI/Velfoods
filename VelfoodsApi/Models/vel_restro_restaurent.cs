//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class vel_restro_restaurent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vel_restro_restaurent()
        {
            this.vel_restro_empdepartment = new HashSet<vel_restro_empdepartment>();
            this.vel_restro_empregistration = new HashSet<vel_restro_empregistration>();
            this.vel_restro_itemcategory = new HashSet<vel_restro_itemcategory>();
            this.vel_restro_itemname = new HashSet<vel_restro_itemname>();
            this.vel_restro_manger = new HashSet<vel_restro_manger>();
            this.vel_restro_miscollection = new HashSet<vel_restro_miscollection>();
            this.vel_restro_offers = new HashSet<vel_restro_offers>();
            this.vel_restro_order = new HashSet<vel_restro_order>();
            this.vel_restro_paidouts = new HashSet<vel_restro_paidouts>();
            this.vel_restro_tax = new HashSet<vel_restro_tax>();
            this.vel_restro_tabledefination = new HashSet<vel_restro_tabledefination>();
            this.vel_restro_tablebooking = new HashSet<vel_restro_tablebooking>();
            this.vel_restro_banks = new HashSet<vel_restro_banks>();
            this.vel_restro_wallet = new HashSet<vel_restro_wallet>();
        }
    
        public int restaurent_id { get; set; }
        public string restaurent_name { get; set; }
        public string restaurent_address { get; set; }
        public long restaurent_mobile_no { get; set; }
        public string restaruent_status { get; set; }
        public string restrent_manger { get; set; }
        public int property_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_empdepartment> vel_restro_empdepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_empregistration> vel_restro_empregistration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_itemcategory> vel_restro_itemcategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_itemname> vel_restro_itemname { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_manger> vel_restro_manger { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_miscollection> vel_restro_miscollection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_offers> vel_restro_offers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_order> vel_restro_order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_paidouts> vel_restro_paidouts { get; set; }
        public virtual vel_restro_property vel_restro_property { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_tax> vel_restro_tax { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_tabledefination> vel_restro_tabledefination { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_tablebooking> vel_restro_tablebooking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_banks> vel_restro_banks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_wallet> vel_restro_wallet { get; set; }
    }
}
