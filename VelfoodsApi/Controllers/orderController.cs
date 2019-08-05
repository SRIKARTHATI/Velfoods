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
        velfoodsEntities1 entity = new velfoodsEntities1();
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
                             c.order_status
                         });
            re.Data = order;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("Orderinsert")]
        public IHttpActionResult insert(vel_restro_order ord)
        {

            Boolean b = new order().adding(ord);
            if (b)
            {
                ord.restaurent_id = 1;
                ord.insert_date = DateTime.Today.Date;
                entity.vel_restro_order.Add(ord);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Item added successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                ord.restaurent_id = 1;
                ord.insert_date = DateTime.Today.Date;
                ord.order_status = "Running";
                ord.kot_id = order.kotid;

                re.code = 200;
                re.message = "Item added successfully";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("orderupdate")]
        public IHttpActionResult update(vel_restro_order order)
        {
            Boolean b = new order().update(order);
            if (b)
            {
                re.code = 200;
                re.message = "Item updated successfully";
                return Content(HttpStatusCode.OK, re);

            }
            else
            {
                re.code = 100;
                re.message = "Item update fail please check the values";
                return Content(HttpStatusCode.OK, re);

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
    }
}
