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
    
    public partial class vel_restro_billpayment
    {
        public int billment_id { get; set; }
        public int table_defination_id { get; set; }
        public int print_id { get; set; }
        public string payment_mode { get; set; }
        public string bank_name { get; set; }
        public string transaction_id { get; set; }
        public decimal amount { get; set; }
        public decimal bill_amount { get; set; }
        public decimal due_amount { get; set; }
        public string payment_status { get; set; }
        public int restaurent_id { get; set; }
        public string name { get; set; }
        public Nullable<long> mobile_no { get; set; }
        public string reference { get; set; }
    
        public virtual vel_restro_print vel_restro_print { get; set; }
        public virtual vel_restro_restaurent vel_restro_restaurent { get; set; }
        public virtual vel_restro_tabledefination vel_restro_tabledefination { get; set; }
    }
}
