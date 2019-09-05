using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class BillpaymentController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("Getbillpayemnts")]
        public Responce getbills(vel_restro_billpayment bills)
        {
            var bill = (from c in entity.vel_restro_billpayment 
                        where c.restaurent_id == bills.restaurent_id
                        select new
                        {
                            c.billment_id,
                            c.table_defination_id,
                            c.print_id,
                            c.payment_mode,
                            c.bank_name,
                            c.transaction_id,
                            c.amount,
                            c.bill_amount,
                            c.due_amount,
                            c.payment_status,
                            c.restaurent_id,
                            c.insert_date
                        });
            re.Data = bill;
            re.code = 200;
            re.message = "Data sucess";
            return re; 
        }

        [HttpPost]
        [Route("billsettle")]
        public Responce billsettle(vel_restro_billpayment settle)
        {
            var billsettle = (from c in entity.vel_restro_billpayment
                        where c.restaurent_id == settle.restaurent_id
                       where c.insert_date ==settle.insert_date
                              select new
                        {
                            c.billment_id,
                            c.table_defination_id,
                            c.print_id,
                            c.payment_mode,
                            c.bank_name,
                            c.transaction_id,
                            c.amount,
                            c.bill_amount,
                            c.due_amount,
                            c.payment_status,
                            c.restaurent_id,
                            c.insert_date
                        });
            re.Data = billsettle;
            re.code = 200;
            re.message = "Data sucess";
            return re;
        }
        [HttpPost]
        [Route("billsettleid")]
        public Responce billsettleid(vel_restro_billpayment settle)
        {
            var billsettle = (from c in entity.vel_restro_billpayment
                              join ct in entity.vel_restro_tabledefination on c.table_defination_id equals ct.table_defination_id
                              join cp in entity.vel_restro_print on c.print_id equals cp.print_id
                              where c.restaurent_id == settle.restaurent_id
                              select new
                              {
                                  c.billment_id,
                                  c.table_defination_id,
                                  ct.table_name,
                                  cp.print_id,
                                  cp.total_amount,
                                  cp.discount_amount,
                                  cp.total_after_discount,
                                  c.payment_mode,
                                  c.bank_name,
                                  c.transaction_id,
                                  c.amount,
                                  c.bill_amount,
                                  c.due_amount,
                                  c.payment_status,
                                  c.restaurent_id,
                                  c.insert_date
                              });
            re.Data = billsettle;
            re.code = 200;
            re.message = "Data sucess";
            return re;
        }


        [HttpPost]
        [Route("billinsert")]
        public IHttpActionResult insert(vel_restro_billpayment bills)
        {
            //int cc;
            //using (velfoodsEntities2 en =new velfoodsEntities2())
            //{
            //    List<vel_restro_billpayment> list = new List<vel_restro_billpayment>();
            //    list = en.vel_restro_billpayment.OrderBy(a => a.billment_id).ToList();
            //    cc = list.Count;
            //}

            //vel_restro_billpayment bills = new vel_restro_billpayment();
            //settle.table_defination_id = bills.table_defination_id;
            //settle.print_id = bills.print_id;
            //settle.payment_mode = bills.payment_mode;
            //settle.bank_name = bills.bank_name;
            //settle.transaction_id = bills.transaction_id;
            //settle.amount = bills.amount;
            //settle.bill_amount = bills.bill_amount;
            //settle.due_amount = bills.due_amount;
            //vel_restro_billstatus status = new vel_restro_billstatus();
            //if (settle.payment_status == "pending")
            //{
            //    status.Billstatus = "pending";
            //    settle.name = status.name;
            //    settle.mobile_no = status.mobile_no;
            //    settle.discription = status.discription;
            //    status.billpayment_id = cc + 1;
            //    settle.restaurent_id = status.restaurent_id;
            //    entity.vel_restro_billstatus.Add(status);
            //    entity.SaveChanges();
            //}
            //else if(settle.payment_status == "Complementory")
            //{
            //    status.Billstatus = "Complementory";
            //    settle.name = status.name;
            //    settle.mobile_no = status.mobile_no;
            //    settle.discription = status.discription;
            //    status.billpayment_id = cc + 1;
            //    settle.restaurent_id = status.restaurent_id;
            //    entity.vel_restro_billstatus.Add(status);
            //    entity.SaveChanges();
            //}
            //else
            //{
            //settle.payment_status = bills.payment_status;
            //settle.restaurent_id = bills.restaurent_id;
            //entity.vel_restro_billpayment.Add(bills);
            //entity.SaveChanges();
            // }

            Boolean bb = new billpayment().adding(bills);
            if (bb)
            {

                var ee = (from c in entity.vel_restro_tabledefination
                          where c.table_defination_id == bills.table_defination_id
                          where c.restaurent_id == bills.restaurent_id
                          select c).FirstOrDefault();
                if (ee == null)
                {

                }
                else
                {
                    ee.BACKGROUND_COLOR = "Green";
                    entity.SaveChanges();
                }
                var r = (from c in entity.vel_restro_order
                         where c.table_defination_id == bills.table_defination_id
                         where c.restaurent_id == bills.restaurent_id
                         where c.order_status == "Printed"
                         select c).FirstOrDefault();
                if (r == null)
                {

                }
                else
                {
                    r.order_status = "Close";
                    entity.SaveChanges();
                }
                var rr = (from c in entity.vel_restro_print
                          where c.table_defination_id == bills.table_defination_id
                          where c.restaurent_id == bills.restaurent_id
                          where c.print_status == "Printed"
                          select c).FirstOrDefault();
                if (r == null)
                {

                }
                else
                {
                    rr.print_status = "Close";
                    entity.SaveChanges();
                }
                bills.insert_date = DateTime.Today;
                entity.vel_restro_billpayment.Add(bills);
                entity.SaveChanges();
                re.code = 200;
                re.Data = "inserted sucessfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.Data = "inserted fail";
                return Content(HttpStatusCode.OK, re);
            }
        }
        [HttpPost]
        [Route("getbillitems")]
        public Responce getbillitems(vel_restro_billpayment getitems)
        {
            var res = (from c in entity.vel_restro_order
                       join cc in entity.vel_restro_print on c.kot_id equals cc.kot_id
                       join bb in entity.vel_restro_billpayment on cc.print_id equals bb.print_id
                       where c.restaurent_id == getitems.restaurent_id
                       where bb.billment_id == getitems.billment_id
                       select new
                       {
                           c.order_itemname,
                           c.order_quantity,
                           c.order_rate,
                           order_tax_amount = ((c.order_rate * c.order_quantity) *c.order_tax_amount)/100,
                           c.order_totalamount,
                           bb.billment_id,
                           
                       });
            re.Data = res;
            re.code = 200;
            re.message = "Data Sucess";
            return re;
        }
    }
}
