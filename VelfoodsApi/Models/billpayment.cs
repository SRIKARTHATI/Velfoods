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
                using (velfoodsEntities2 en = new velfoodsEntities2())
                {
                    var ee = (from c in en.vel_restro_tabledefination
                              where c.table_defination_id == bills.table_defination_id
                              where c.restaurent_id == bills.restaurent_id
                              select c).FirstOrDefault();
                    if (ee == null)
                    {

                    }
                    else
                    {
                        ee.BACKGROUND_COLOR = "Green";
                        en.SaveChanges();
                    }

                    var rs = (from c in en.vel_restro_order
                              where c.table_defination_id == bills.table_defination_id
                              where c.restaurent_id == bills.restaurent_id
                              select c).FirstOrDefault();
                    if (rs == null)
                    {

                    }
                    else
                    {

                        rs.order_status = "Close";
                        rs.Statusorder = 1;
                        en.SaveChanges();
                    }
                    var rr = (from c in en.vel_restro_print
                              where c.table_defination_id == bills.table_defination_id
                              where c.restaurent_id == bills.restaurent_id
                              where c.print_status == "Printed"
                              select c).FirstOrDefault();
                    if (rr == null)
                    {

                    }
                    else
                    {
                        rr.print_status = "Close";
                        en.SaveChanges();
                    }
                }
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
}