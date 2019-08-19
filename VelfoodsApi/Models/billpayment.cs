using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class billpayment
    {
        int billpaymentid, tableid, printid, count;
        public Boolean adding (vel_restro_billpayment bills)
        {
            List<vel_restro_billpayment> list = new List<vel_restro_billpayment>();
            int cc = list.Count;
            for(int i =0; i<cc; i++)
            {
                billpaymentid = list[i].billment_id;
                tableid = list[i].table_defination_id;
                printid = list[i].print_id;

                if (billpaymentid.Equals(bills.billment_id) && tableid.Equals(bills.table_defination_id) && printid.Equals(bills.print_id))
                {
                    count = 1;
                    break;
                }
                else
                {
                    count = 0;
                }
            }
            if(count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}