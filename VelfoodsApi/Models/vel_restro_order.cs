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
    
    public partial class vel_restro_order
    {
        public int order_id { get; set; }
        public string order_itemname { get; set; }
        public decimal order_rate { get; set; }
        public int order_quantity { get; set; }
        public Nullable<decimal> order_totalamount { get; set; }
        public Nullable<int> restaurent_id { get; set; }
        public int itemname_id { get; set; }
        public Nullable<int> table_defination_id { get; set; }
        public string order_status { get; set; }
        public string insert_by { get; set; }
        public Nullable<System.DateTime> insert_date { get; set; }
        public Nullable<int> kot_id { get; set; }
    
        public virtual vel_restro_itemname vel_restro_itemname { get; set; }
        public virtual vel_restro_restaurent vel_restro_restaurent { get; set; }
        public virtual vel_restro_tabledefination vel_restro_tabledefination { get; set; }
    }
}