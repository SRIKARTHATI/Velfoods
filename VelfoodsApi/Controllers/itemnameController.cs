using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class itemnameController : ApiController
    {

        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();


        [HttpPost]
        [Route("getitemnames")]
        public Responce get(vel_restro_itemname iname)
        {
            var cc = (from c in entity.vel_restro_itemname
                      where c.restaurent_id == iname.restaurent_id
                      select new
                      {
                          c.itemname_id,
                          c.itemname_item_name,
                          c.itemname_description,
                          c.itemname_reportingname,
                          c.itemname_active_from,
                          c.itemname_status,
                          c.item_dinein_amount,
                          c.item_dinein_tax,
                          c.item_takeaway_amount,
                          c.item_takeaway_tax,
                          c.item_homedelivary_amount,
                          c.item_homedelivary_tax,
                          c.item_homedelivery_deliverycharges,
                          c.itemcategory_id
                      });
            re.Data = cc;
            re.message = "Data success";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("itemnameinsert")]
        public IHttpActionResult insert(vel_restro_itemname name)
        {
            Boolean b = new itemnameClass().adding(name);
            if (b)
            {
                entity.vel_restro_itemname.Add(name);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Data inserted Successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "inserted fail please check the values ";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("itemnameupdate")]
        public IHttpActionResult update(vel_restro_itemname name)
        {
            Boolean b = new itemnameClass().update(name);
            if (b)
            {
                re.code = 200;
                re.message = "Data updated Successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "updated fail please check the values ";
                return Content(HttpStatusCode.OK, re);
            }
        }

    }
}
