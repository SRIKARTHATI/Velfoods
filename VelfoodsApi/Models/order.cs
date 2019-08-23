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
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_order.OrderBy(a => a.order_id).ToList();
                int coun = list.Count;
                for (int i = 0; i < coun; i++)
                {
                    id = list[i].order_id;
                    status = list[i].order_status;
                    resid = Convert.ToInt32(list[i].restaurent_id);
                    tableid = Convert.ToInt32(list[i].table_defination_id);
                    if (status.Equals(orde.order_status) && resid.Equals(orde.restaurent_id) && tableid.Equals(orde.table_defination_id))
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
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_order.OrderBy(a => a.order_id).ToList();
                int coun = list.Count;
                for (int i = 0; i < coun; i++)
                {
                    id = list[i].order_id;
                    status = list[i].order_status;
                    resid = Convert.ToInt32(list[i].restaurent_id);
                    tableid = Convert.ToInt32(list[i].table_defination_id);
                    if (status.Equals(orde.order_status) && resid.Equals(orde.restaurent_id) && tableid.Equals(orde.table_defination_id))
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
                    using (velfoodsEntities2 ent = new velfoodsEntities2())
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
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_order.OrderBy(a => a.order_id).ToList();
                int coun = list.Count;
                for (int i = 0; i < coun; i++)
                {
                    id = list[i].order_id;
                    status = list[i].order_status;
                    resid = Convert.ToInt32(list[i].restaurent_id);
                    tableid = Convert.ToInt32(list[i].table_defination_id);
                    if (status.Equals(delete.order_status) && resid.Equals(delete.restaurent_id) && tableid.Equals(delete.table_defination_id))
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
                    using (velfoodsEntities2 ent = new velfoodsEntities2())
                    {
                        vel_restro_order orders = (from c in ent.vel_restro_order
                                                   where c.order_status == "Close"
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

public class restroorder
{
    public int order_id { get; set; }
    public string order_itemname { get; set; }
    public decimal order_rate { get; set; }
    public int order_quantity { get; set; }
    public Nullable<decimal> order_totalamount { get; set; }
    public Nullable<int> restaurent_id { get; set; }
    public string itemnameid { get; set; }
    public Nullable<int> table_defination_id { get; set; }
    public string order_status { get; set; }
    public string insert_by { get; set; }
    public Nullable<System.DateTime> insert_date { get; set; }
    public Nullable<int> kot_id { get; set; }

    public string itemnames { get; set; }
    public string Rate { get; set; }
    public string quantity { get; set; }

    public string order_captain { get; set; }
    public  string tax { get; set; }
    public string total { get; set; }

    public string BACKGROUND_COLOR { get; set; }
    
    public string discount { get; set; }
    public string plan { get; set; }
    public decimal amount { get; set; }
    public decimal parecel { get; set; }
    public decimal t_total { get; set; }

}