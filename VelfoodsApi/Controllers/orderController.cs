using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class orderController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("Getorders")]
        public Responce getvalues(vel_restro_order ord)
        {
            var order = (from c in entity.vel_restro_order
                         where c.restaurent_id == ord.restaurent_id
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
            re.Data = order;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }
        [HttpPost]
        [Route("getorderitems")]
        public Responce getitems(vel_restro_order ord)
        {
            var order = (from c in entity.vel_restro_order
                         join cc in entity.vel_restro_tabledefination on c.table_defination_id equals cc.table_defination_id
                         join r in entity.vel_restro_restaurent on c.restaurent_id equals r.restaurent_id
                         where c.table_defination_id == ord.table_defination_id
                         where c.restaurent_id == ord.restaurent_id
                         where c.order_status =="Running"
                         select new
                         {
                             c.order_id,
                             c.order_itemname,
                             c.order_rate,
                             c.order_quantity,
                             c.order_totalamount,
                             c.order_tax_amount,
                             c.restaurent_id,
                             c.table_defination_id,
                             c.order_status,
                             c.kot_id,
                             c.order_captain,
                             cc.table_pax,
                             r.restaurent_name

                         });
            re.Data = order;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }



        String itemnames,Rate,quantity,tax,total,itemid;
        String quant,tot;
        public static int kot;
        [HttpPost]
        [Route("Orderinsert")]
        public IHttpActionResult insert(restroorder ord)
        {
            itemid = ord.itemnameid;
            itemnames = ord.itemnames;
            Rate =ord.Rate;
            quantity = ord.quantity;
            tax = ord.tax;
            total = ord.total;
            string[] item = itemnames.Split(new char[] { ',' });
            int c = item.Length;
            string[] rate = Rate.Split(new char[] { ',' });
            string[] quan = quantity.Split(new char[] { ',' });
            string[] taxx = tax.Split(new char[] { ',' });
            string[] totalamount = total.Split(new char[] { ',' });
            string[] id = itemid.Split(new char[] { ',' });
            List<vel_restro_order> list = new List<vel_restro_order>();
            using (velfoodsEntities2 ent =new velfoodsEntities2())
            {
                list = ent.vel_restro_order.OrderBy(a => a.order_id).ToList();
                int cc = list.Count;
                vel_restro_order order = new vel_restro_order();
                vel_restro_tabledefination tbl = new vel_restro_tabledefination();
                for(int i =0; i<c; i++)
                {

                    order.order_itemname = item[i];
                    order.order_rate =Convert.ToDecimal(rate[i]);
                    order.order_quantity =Convert.ToInt32(quan[i]);
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
                    order.table_defination_id = ord.table_defination_id;
                    var tbls = (from c1 in ent.vel_restro_tabledefination
                                where c1.table_defination_id == order.table_defination_id
                                select c1).FirstOrDefault();
                    tbls.BACKGROUND_COLOR = "Orange";
                    order.order_captain = ord.order_captain;
                    order.restaurent_id = ord.restaurent_id;
                    order.order_status = ord.order_status;
                    order.insert_by = "srikar";
                    order.insert_date = DateTime.Now.Date;
                    ent.vel_restro_order.Add(order);
                    ent.SaveChanges();
                   
                }
                re.code = 200;
                re.message = "items added sucessfully";
                return Content(HttpStatusCode.OK, re);
                
            }
        }
        int count;
        [HttpPost]
        [Route("orderupdate")]
        public IHttpActionResult update(restroorder order)
        {
            quant = order.quantity;
            tot = order.total;
            string[] quan = quant.Split(new char[] { ',' });
            string[] totalamount = tot.Split(new char[] { ',' });
            using (velfoodsEntities2 ent = new velfoodsEntities2())
            {
                var ee = (from oitm in ent.vel_restro_order
                          where oitm.order_status == "Running"
                          where oitm.table_defination_id == order.table_defination_id
                          where oitm.restaurent_id == order.restaurent_id
                          select oitm).ToList();
                int cou = ee.Count; 
                if (ee.Count <= 0)
                {
                    count = 0;
                }
                else
                {
                    for (int i = 0; i < cou; i++)
                    {
                        int ordid = ee[i].order_id;

                        vel_restro_order orders = (from cit in ent.vel_restro_order
                                                   where cit.order_status == "Running"
                                                   where cit.restaurent_id == order.restaurent_id
                                                   where cit.table_defination_id == order.table_defination_id
                                                   where cit.order_id == ordid
                                                   select cit).FirstOrDefault();
                        
                        orders.order_quantity = Convert.ToInt32(quan[i]);
                        orders.order_totalamount = Convert.ToDecimal(totalamount[i]);
                        ent.SaveChanges();
                    }
                    count = 1;
                }
                if(count == 0)
                {
                    re.code = 100;
                    re.message = "updated fail";
                    return Content(HttpStatusCode.OK, re);
                }
                else
                {
                    re.code = 200;
                    re.message = "updated sucessfully";
                    quant = "";
                    tot = "";
                    return Content(HttpStatusCode.OK, re);
                   
                }
            }
           
        } 

        [HttpPost]
        [Route("orderDelete")]
        public IHttpActionResult delete(vel_restro_order order)
        {
            Boolean b = new order().update(order);
            if (b)
            {
                re.code = 200;
                re.message = "Item deleted successfully";
                return Content(HttpStatusCode.OK, re);

            }
            else
            {
                re.code = 100;
                re.message = "Item delete fail please check the values";
                return Content(HttpStatusCode.OK, re);

            }
        }
        [HttpPost]
        [Route("ordinsert")]
        public IHttpActionResult ordinsert(vel_restro_order ord)
        {
            int tablid, residd,itemidd; string staus;
            var change = (from c in entity.vel_restro_order
                          where c.table_defination_id == ord.table_defination_id
                          where c.restaurent_id == ord.restaurent_id
                          where c.order_status == "Running"
                          select c).ToList();
            int co = change.Count;
            for(int i=0; i<co; i++)
            {
                tablid =Convert.ToInt32(change[i].table_defination_id);
                residd = Convert.ToInt32(change[i].restaurent_id);
                
                staus = "Running";
                if (tablid.Equals(ord.table_defination_id) && residd.Equals(ord.restaurent_id) && staus.Equals(ord.order_status))
                {
                    count = 1;
                }
                else
                {
                    count = 0;
                    entity.vel_restro_order.Add(ord);
                    entity.SaveChanges();
                }
            }
            if(count == 0)
            {
                re.code = 200;
                re.message = "Item added successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "item added fail please check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
