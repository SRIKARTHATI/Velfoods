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
    
    public partial class vel_restro_offers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vel_restro_offers()
        {
            this.vel_restro_print = new HashSet<vel_restro_print>();
        }
        public int offers_id { get; set; }
        public string promo_code_name { get; set; }
        public string promo_code { get; set; }
        public string promo_code_description { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string Active_dare_status { get; set; }
        public string from_time { get; set; }
        public string to_time { get; set; }
        public string Active_time_status { get; set; }
        public string Day_type { get; set; }
        public string Days { get; set; }
        public string Day_status { get; set; }
        public int percentage { get; set; }
        public Nullable<decimal> minbill_amount { get; set; }
        public string minbill_status { get; set; }
        public Nullable<decimal> maximum_bill_amount { get; set; }
        public string maximum_bill_status { get; set; }
        public int restaurent_id { get; set; }
    
        public virtual vel_restro_restaurent vel_restro_restaurent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vel_restro_print> vel_restro_print { get; set; }
    }
}
