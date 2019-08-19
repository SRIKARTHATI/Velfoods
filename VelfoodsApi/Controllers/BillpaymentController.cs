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
                            c.restaurent_id
                        });
            re.Data = bill;
            re.code = 200;
            re.message = "Data sucess";
            return re; 
        }
    }
}
