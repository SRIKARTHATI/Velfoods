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
    
    public partial class vel_restro_property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vel_restro_property()
        {
            this.vel_restro_restaurent = new HashSet<vel_restro_restaurent>();
        }
    
        public int property_id { get; set; }
        public string property_name { get; set; }
        public string property_address { get; set; }
        public long property_mobile_no { get; set; }
        public string property_land_mark { get; set; }
        public Nullable<long> property_landline { get; set; }
        public string property_city { get; set; }
        public string property_email { get; set; }
        public string property_state { get; set; }
        public string property_website { get; set; }
        public int property_pincode { get; set; }
        public string property_gst { get; set; }
        public string property_country { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_restaurent> vel_restro_restaurent { get; set; }
    }
}
