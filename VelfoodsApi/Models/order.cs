using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class order
    {
        string status;
        int count,resid,tableid,id;
       public static int kotid;
        public Boolean adding(vel_restro_order orde)
        {
            List<vel_restro_order> list = new List<vel_restro_order>();
            using (velfoodsEntities1 en = new velfoodsEntities1())
            {
                list = en.vel_restro_order.OrderBy(a => a.order_id).ToList();
                int coun = list.Count;
                for (int i = 0; i < coun; i++)
                {
                    id = list[i].order_id;
                    status = list[i].order_status;
                    resid =Convert.ToInt32(list[i].restaurent_id);
                    tableid =Convert.ToInt32(list[i].table_defination_id);
                    if(orde.order_status.Equals(status) && orde.restaurent_id.Equals(resid) && orde.table_defination_id.Equals(tableid))
                    {
                        count = 1;
                        var aa = (from c in en.vel_restro_order
                                  where c.order_status == "Running"
                                  where c.restaurent_id == resid
                                  where c.table_defination_id == tableid
                                  where c.order_id == id
                                  select new
                                  {
                                      c.kot_id,
                                      kotid =c.kot_id
                                  });
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
}