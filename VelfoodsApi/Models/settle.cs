using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class settle
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
        public int billstatus_id { get; set; }
        public string Billstatus { get; set; }
        public string name { get; set; }
        public long mobile_no { get; set; }
        public string discription { get; set; }
    }
}