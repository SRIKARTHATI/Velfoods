using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class order
    {
        string status;
        int count, resid, tableid, id;
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
                    resid = Convert.ToInt32(list[i].restaurent_id);
                    tableid = Convert.ToInt32(list[i].table_defination_id);
                    if (orde.order_status.Equals(status) && orde.restaurent_id.Equals(resid) && orde.table_defination_id.Equals(tableid))
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
                                      kotid = c.kot_id
                                  });
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public Boolean update(vel_restro_order orde)
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
                    resid = Convert.ToInt32(list[i].restaurent_id);
                    tableid = Convert.ToInt32(list[i].table_defination_id);
                    if (orde.order_status.Equals(status) && orde.restaurent_id.Equals(resid) && orde.table_defination_id.Equals(tableid))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count == 1)
                {
                    using (velfoodsEntities1 ent = new velfoodsEntities1())
                    {
                        vel_restro_order orders = (from c in ent.vel_restro_order
                                                   where c.order_status == "Running"
                                                   where c.restaurent_id == orde.restaurent_id
                                                   where c.table_defination_id == orde.table_defination_id
                                                   select c).FirstOrDefault();
                        orders.order_itemname = orde.order_itemname;
                        orders.order_rate = orde.order_rate;
                        orders.order_quantity = orde.order_quantity;
                        orders.order_totalamount = orde.order_totalamount;
                        ent.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public Boolean Delete(vel_restro_order delete)
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
                    resid = Convert.ToInt32(list[i].restaurent_id);
                    tableid = Convert.ToInt32(list[i].table_defination_id);
                    if (delete.order_status.Equals(status) && delete.restaurent_id.Equals(resid) && delete.table_defination_id.Equals(tableid))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count == 1)
                {
                    using (velfoodsEntities1 ent = new velfoodsEntities1())
                    {
                        vel_restro_order orders = (from c in ent.vel_restro_order
                                                   where c.order_status == "Running"
                                                   where c.restaurent_id == delete.restaurent_id
                                                   where c.table_defination_id == delete.table_defination_id
                                                   select c).FirstOrDefault();
                        orders.order_status = "delete";
                        ent.SaveChanges();
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
}