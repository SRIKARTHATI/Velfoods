using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class ItemcategoryController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();
        [HttpPost]
        [Route("getcategories")]
        public Responce getvalues(vel_restro_itemcategory itemc)
        {
            var res = (from c in entity.vel_restro_itemcategory
                       where c.restaurent_id == itemc.restaurent_id
                       select new
                       {
                           c.itemcategory_id,
                           c.item_name,
                           c.item_description,
                           c.item_active_from,
                           c.item_status,
                           c.item_reporting_name,
                           c.restaurent_id
                       });
            re.Data = res;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("itemcinsert")]
        public IHttpActionResult insert(vel_restro_itemcategory itemc)
        {
            Boolean b = new itemcategoryclass().adding(itemc);
            if (b)
            {
                entity.vel_restro_itemcategory.Add(itemc);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Data inserted successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "insert fail check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("itemcatupdate")]
        public IHttpActionResult update(vel_restro_itemcategory itcate)
        {
            Boolean b = new itemcategoryclass().update(itcate);
            if (b)
            {
                re.code = 200;
                re.message = "Data updated successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "update fail check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
