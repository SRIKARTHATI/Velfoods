using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class RestaurantController : ApiController
    {
        velfoodsEntities2 ve = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("gettingrestaurant")]
        public Responce gettingrestaurant(vel_restro_restaurent vres)
        {
            var ee = (from c in ve.vel_restro_restaurent
                      where c.property_id == vres.property_id
                      select new
                      {
                          c.restaurent_id,
                          c.restaurent_name,
                          c.restaurent_mobile_no,
                          c.restaurent_address,
                          c.restrent_manger,
                          c.restaruent_status
                      });

            re.Data = ee;
            re.message = "getting details successfully";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("addingrestaurant")]
        public IHttpActionResult addingrestaurant(vel_restro_restaurent vradd)
        {
            Boolean b = new RestaurantClass().AddingRestaurant(vradd);
            if (b)
            {
                vradd.property_id = 1;
                ve.vel_restro_restaurent.Add(vradd);
                ve.SaveChanges();
                re.code = 200;
                re.message = "succesfully data has inserted";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "failed to insert data";
                return Content(HttpStatusCode.OK, re);
            }
        }
        [HttpPost]
        [Route("updatingrestaurant")]
        public IHttpActionResult updatingrestaurant(vel_restro_restaurent vrr)
        {
            Boolean b = new RestaurantClass().UpdatingRestaurant(vrr);
            if (b)
            {
                re.code = 200;
                re.message = "data Updated succesfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "failed to update data";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
