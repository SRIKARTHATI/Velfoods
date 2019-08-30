using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class tabletransferController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("gettransfertables")]
        public Responce gettabletransfer(vel_restro_table_transfer trans)
        {
            var get = (from c in entity.vel_restro_table_transfer
                       where c.restaurent_id == trans.restaurent_id
                       select new
                       {
                           c.table_transfer_id,
                           c.table_t_itemname,
                           c.table_t_rate,
                           c.table_t_quantity,
                           c.table_t_totalamount,
                           c.table_t_tax_amount,
                           c.table_t_status,
                           c.table_t_captain,
                           c.kot_id,
                           c.table_defination_id,
                           c.restaurent_id
                       });
            re.Data = get;
            re.code = 200;
            re.message = "Data sucess";
            return re;
        } 

        [HttpPost]
        [Route("tabletransfer")]
        public IHttpActionResult transfer(vel_restro_table_transfer trans)
        {
            int tblid, resid;
            var ord = (from c in entity.vel_restro_order
                       where c.restaurent_id == trans.restaurent_id
                       where c.table_defination_id == trans.table_defination_id
                       where c.order_status == "Running"
                       select c).ToList();
            int count = ord.Count;
            if (ord.Count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    trans.table_t_itemname = ord[i].order_itemname;
                    trans.table_t_rate = ord[i].order_rate;
                    trans.table_t_quantity = ord[i].order_quantity;
                    trans.table_t_totalamount = Convert.ToDecimal(ord[i].order_totalamount);
                    trans.table_t_status = "Transfer";
                    trans.kot_id = Convert.ToInt32(ord[i].kot_id);
                    trans.table_t_captain = ord[i].order_captain;
                    trans.table_t_tax_amount = Convert.ToDecimal(ord[i].order_tax_amount);
                    trans.restaurent_id = Convert.ToInt32(ord[i].restaurent_id);
                    trans.itemname_id = ord[i].itemname_id;
                    trans.table_defination_id = trans.tid;
                    entity.vel_restro_table_transfer.Add(trans);
                    entity.SaveChanges();
                }

                for (int i = 0; i < count; i++)
                {
                    tblid = Convert.ToInt32(ord[i].table_defination_id);
                    resid = Convert.ToInt32(ord[i].restaurent_id);

                    vel_restro_order order = (from c in entity.vel_restro_order
                                              where c.table_defination_id == tblid
                                              where c.restaurent_id == resid
                                              where c.order_status == "Running"
                                              select c).FirstOrDefault();
                    order.order_status = "Settled";
                    entity.SaveChanges();
                    vel_restro_tabledefination tbled = (from cc in entity.vel_restro_tabledefination
                                                        where cc.restaurent_id == resid
                                                        where cc.table_defination_id == tblid
                                                        select cc).FirstOrDefault();
                    tbled.BACKGROUND_COLOR = "Green";
                    entity.SaveChanges();
                }
                for (int i = 0; i < count; i++)
                {
                    vel_restro_order orderr = new vel_restro_order();
                    orderr.order_itemname = ord[i].order_itemname;
                    trans.table_t_itemname = ord[i].order_itemname;
                    orderr.order_rate = ord[i].order_rate;
                    trans.table_t_rate = ord[i].order_rate;
                    orderr.order_quantity = ord[i].order_quantity;
                    trans.table_t_quantity = ord[i].order_quantity;
                    orderr.order_totalamount = ord[i].order_totalamount;
                    trans.table_t_totalamount = Convert.ToDecimal(ord[i].order_totalamount);
                    orderr.order_status = "Running";
                    trans.table_t_status = "Transfer";
                    orderr.kot_id = ord[i].kot_id;
                    trans.kot_id = Convert.ToInt32(ord[i].kot_id);
                    orderr.order_captain = ord[i].order_captain;
                    trans.table_t_captain = ord[i].order_captain;
                    orderr.order_tax_amount = ord[i].order_tax_amount;
                    trans.table_t_tax_amount = Convert.ToDecimal(ord[i].order_tax_amount);
                    orderr.restaurent_id = ord[i].restaurent_id;
                    trans.restaurent_id = Convert.ToInt32(ord[i].restaurent_id);
                    orderr.itemname_id = ord[i].itemname_id;
                    trans.itemname_id = ord[i].itemname_id;
                    orderr.table_defination_id = trans.tid;
                    trans.table_defination_id = trans.tid;
                    entity.vel_restro_table_transfer.Add(trans);
                    entity.vel_restro_order.Add(orderr);
                    entity.SaveChanges();
                    vel_restro_tabledefination tbled = (from cc in entity.vel_restro_tabledefination
                                                        where cc.restaurent_id == trans.restaurent_id
                                                        where cc.table_defination_id == trans.tid
                                                        select cc).FirstOrDefault();
                    tbled.BACKGROUND_COLOR = "Orange";
                    entity.SaveChanges();
                }
                re.code = 200;
                re.message = "Table transfered successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Table transfer fail";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("occupied")]
        public Responce occupied(vel_restro_tabledefination def)
        {
            var ee = (from c in entity.vel_restro_tabledefination
                      where c.BACKGROUND_COLOR == "Orange"
                      where c.restaurent_id == def.restaurent_id
                      select new
                      {
                          c.table_name
                      });
            re.Data = ee;
            re.code = 200;
            re.message = "Data success";
            return re;
        }
        [HttpPost]
        [Route("vacant")]
        public Responce vacant(vel_restro_tabledefination def)
        {
            var ee = (from c in entity.vel_restro_tabledefination
                      where c.BACKGROUND_COLOR == "Green"
                      where c.restaurent_id == def.restaurent_id
                      select new
                      {
                          c.table_name
                      });
            re.Data = ee;
            re.code = 200;
            re.message = "Data success";
            return re;
        }

        [HttpPost]
        [Route("tableswap")]
        public IHttpActionResult swap(vel_restro_table_transfer tswap)
        {
            var sw = (from c in entity.vel_restro_order
                      where c.restaurent_id == tswap.restaurent_id
                      where c.table_defination_id == tswap.table_defination_id
                      where c.order_status == "Running"
                      select c).ToList();
            var swp = (from c in entity.vel_restro_order
                       where c.restaurent_id == tswap.restaurent_id
                       where c.table_defination_id == tswap.tid
                       where c.order_status == "Running"
                       select c).ToList();

            int cnt = sw.Count;
            int cntt = swp.Count;
            if (cnt>0 && cntt>0)
            {
                if(cnt > 0)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        vel_restro_order orderr = new vel_restro_order();
                        orderr.order_itemname = sw[i].order_itemname;
                        tswap.table_t_itemname = sw[i].order_itemname;
                        orderr.order_rate = sw[i].order_rate;
                        tswap.table_t_rate = sw[i].order_rate;
                        orderr.order_quantity = sw[i].order_quantity;
                        tswap.table_t_quantity = sw[i].order_quantity;
                        orderr.order_totalamount = sw[i].order_totalamount;
                        tswap.table_t_totalamount = Convert.ToDecimal(sw[i].order_totalamount);
                        orderr.order_status = "Running";
                        tswap.table_t_status = "Swap";
                        orderr.kot_id = sw[i].kot_id;
                        tswap.kot_id = Convert.ToInt32(sw[i].kot_id);
                        orderr.order_captain = sw[i].order_captain;
                        tswap.table_t_captain = sw[i].order_captain;
                        orderr.order_tax_amount = sw[i].order_tax_amount;
                        tswap.table_t_tax_amount = Convert.ToDecimal(sw[i].order_tax_amount);
                        orderr.restaurent_id = sw[i].restaurent_id;
                        tswap.restaurent_id = Convert.ToInt32(sw[i].restaurent_id);
                        orderr.itemname_id = sw[i].itemname_id;
                        tswap.itemname_id = sw[i].itemname_id;
                        orderr.table_defination_id = tswap.tid;
                        tswap.table_defination_id = tswap.tid;
                        entity.vel_restro_table_transfer.Add(tswap);
                        entity.vel_restro_order.Add(orderr);
                        entity.SaveChanges();
                    }
                }
                else
                {

                }
                if(cntt > 0)
                {
                    for (int i = 0; i < cntt; i++)
                    {
                        vel_restro_order orderr = new vel_restro_order();
                        orderr.order_itemname = swp[i].order_itemname;
                        tswap.table_t_itemname = swp[i].order_itemname;
                        orderr.order_rate = swp[i].order_rate;
                        tswap.table_t_rate = swp[i].order_rate;
                        orderr.order_quantity = swp[i].order_quantity;
                        tswap.table_t_quantity = swp[i].order_quantity;
                        orderr.order_totalamount = swp[i].order_totalamount;
                        tswap.table_t_totalamount = Convert.ToDecimal(swp[i].order_totalamount);
                        orderr.order_status = "Running";
                        tswap.table_t_status = "Swap";
                        orderr.kot_id = swp[i].kot_id;
                        tswap.kot_id = Convert.ToInt32(swp[i].kot_id);
                        orderr.order_captain = swp[i].order_captain;
                        tswap.table_t_captain = swp[i].order_captain;
                        orderr.order_tax_amount = swp[i].order_tax_amount;
                        tswap.table_t_tax_amount = Convert.ToDecimal(swp[i].order_tax_amount);
                        orderr.restaurent_id = swp[i].restaurent_id;
                        tswap.restaurent_id = Convert.ToInt32(swp[i].restaurent_id);
                        orderr.itemname_id = swp[i].itemname_id;
                        tswap.itemname_id = swp[i].itemname_id;
                        orderr.table_defination_id = tswap.table_defination_id;
                        tswap.table_defination_id = tswap.table_defination_id;
                        entity.vel_restro_table_transfer.Add(tswap);
                        entity.vel_restro_order.Add(orderr);
                        entity.SaveChanges();
                    }
                }
                else
                {

                }
                re.code = 200;
                re.message = "Table swaped successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Table swap failed please check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
