//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VelfoodsApi.Models
{
    using System;
    using System.Collections.Generic;
    public partial class vel_restro_tax
    {
        public int tax_id { get; set; }
        public string tax_name { get; set; }
        public int tax_percentage { get; set; }
        public System.DateTime tax_Active_from { get; set; }
        public string tax_status { get; set; }
        public int restaurent_id { get; set; }
        public string tax_employeename { get; set; }
        public virtual vel_restro_restaurent vel_restro_restaurent { get; set; }
    }
}