using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class billpayment
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        int billpaymentid, tableid, printid, count;
        public Boolean adding (vel_restro_billpayment bills)
        {
            List<vel_restro_billpayment> list = new List<vel_restro_billpayment>();
            int cc = list.Count;
            for(int i =0; i<cc; i++)
            {
                billpaymentid = list[i].billment_id;
                tableid =Convert.ToInt32(list[i].table_defination_id);
                printid =Convert.ToInt32(list[i].print_id);

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
                var ee = (from c in entity.vel_restro_tabledefination
                          where c.table_defination_id == bills.table_defination_id
                          where c.restaurent_id == bills.restaurent_id
                          select c).FirstOrDefault();
                ee.BACKGROUND_COLOR = "Green";
                entity.SaveChanges();
                var r = (from c in entity.vel_restro_order
                          where c.table_defination_id == bills.table_defination_id
                          where c.restaurent_id == bills.restaurent_id
                          select c).FirstOrDefault();
                r.order_status = "Settled";
                entity.SaveChanges();
                var p = (from c in entity.vel_restro_print
                         where c.table_defination_id == bills.table_defination_id
                         where c.restaurent_id == bills.restaurent_id
                         select c).FirstOrDefault();
                p.print_status = "Settled";
                entity.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}