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
    
    public partial class vel_restro_manger
    {
        public int manger_id { get; set; }
        public string manger_name { get; set; }
        public long manger_mobile_no { get; set; }
        public Nullable<long> manger_contact_no { get; set; }
        public string manger_id_proof { get; set; }
        public string manger_id_no { get; set; }
        public int restaurent_id { get; set; }
        public string manger_status { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    
        public virtual vel_restro_restaurent vel_restro_restaurent { get; set; }
    }
}
