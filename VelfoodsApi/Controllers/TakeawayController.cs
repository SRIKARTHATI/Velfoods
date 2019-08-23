using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class TakeawayController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        public Responce gettakeaway(vel_restro_order take)
        {
            var away = (from c in entity.vel_restro_order
                        where c.restaurent_id == take.restaurent_id
                        where c.ordering_type == "TakeAway"
                        select new
                        {
                            c.order_id,
                            c.order_itemname,
                            c.order_rate,
                            c.order_quantity,
                            c.order_totalamount,
                            c.restaurent_id,
                            c.table_defination_id,
                            c.order_status,
                            c.kot_id,
                            c.order_captain
                        });
            re.Data = away;
            re.code = 200;
            re.message = "Data success";
            return re;
        }

        string t_itemid, t_itemnames, t_rate, t_quantity, t_tax, t_total;
        public static int kot;

        [HttpPost]
        [Route("takeaway")]
        public IHttpActionResult insert(restroorder takeaway)
        {
            t_itemid = takeaway.itemnameid;
            t_itemnames = takeaway.itemnames;
            t_rate = takeaway.Rate;
            t_quantity = takeaway.quantity;
            t_tax = takeaway.tax;
            t_total = takeaway.total;
            string[] item = t_itemnames.Split(new char[] { ',' });
            int c = item.Length;
            string[] rate = t_rate.Split(new char[] { ',' });
            string[] quan = t_quantity.Split(new char[] { ',' });
            string[] taxx = t_tax.Split(new char[] { ',' });
            string[] totalamount = t_total.Split(new char[] { ',' });
            string[] id = t_itemid.Split(new char[] { ',' });
            List<vel_restro_order> list = new List<vel_restro_order>();
            using (velfoodsEntities2 ent = new velfoodsEntities2())
            {
                list = ent.vel_restro_order.OrderBy(a => a.order_id).ToList();
                int cc = list.Count;
                vel_restro_order order = new vel_restro_order();
                for (int i = 0; i < c; i++)
                {

                    order.order_itemname = item[i];
                    order.order_rate = Convert.ToDecimal(rate[i]);
                    order.order_quantity = Convert.ToInt32(quan[i]);
                    order.order_tax_amount = Convert.ToDecimal(taxx[i]);
                    order.order_totalamount = Convert.ToDecimal(totalamount[i]);
                    if (i == 0)
                    {
                        order.kot_id = cc + 1;
                        kot = cc + 1;
                    }
                    else
                    {
                        order.kot_id = kot;
                    }
                    order.itemname_id = Convert.ToInt32(id[i]);
                    order.restaurent_id = takeaway.restaurent_id;
                    order.order_status = "Settled";
                    order.ordering_type = "TakeAway";
                    order.insert_by = "srikar";
                    order.insert_date = DateTime.Now.Date;
                    ent.vel_restro_order.Add(order);
                    ent.SaveChanges();

                    //take away
                    vel_restro_takeaway taway = new vel_restro_takeaway();
                    taway.kot_id = kot;
                    taway.takeaway_discount = takeaway.discount;
                    taway.takeaway_plan = takeaway.plan;
                    taway.takeaway_amount = takeaway.amount;
                    taway.takeaway_parecel = takeaway.parecel;
                    taway.takeaway_total = takeaway.t_total;
                    taway.insert_by = "srikar";
                    taway.insert_date = DateTime.Now.Date;
                    ent.vel_restro_takeaway.Add(taway);
                    ent.SaveChanges();
                }
                re.code = 200;
                re.message = "items added sucessfully";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
