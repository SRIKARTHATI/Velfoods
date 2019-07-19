using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class TableBookingController : ApiController
    {
        velfoodsEntities1 ve = new velfoodsEntities1();
        Responce re = new Responce();

        [HttpPost]
        [Route("gettablebooking")]
        public Responce gettablebooking(vel_restro_tablebooking tbl)
        {
            var a = (from s in ve.vel_restro_tablebooking
                     where s.restaurent_id == tbl.restaurent_id
                     select new
                     {
                         s.table_booking_id,
                         s.tablebookingf_name,
                         s.tablebooking_pax,
                         s.tablebooking_mobile_no,
                         s.tablebooking_advance,
                         s.tablebooking_time,
                         s.tablebooking_splinstructions,
                         s.restaurent_id,
                         s.tablebooking_date
                     });
            re.Data = a;
            re.message = "getting details successfully";
            re.code = 200;
            return re;
        }
        [HttpPost]
        [Route("addtablebooking")]
        public IHttpActionResult AddTableBooking(vel_restro_tablebooking vradd)
        {
            Boolean b = new TableBookingClass().AddTableBooking(vradd);
            if (b)
            {
                ve.vel_restro_tablebooking.Add(vradd);
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
        [Route("updatetablebooking")]
        public IHttpActionResult UpdateTableBooking(vel_restro_tablebooking vradd)
        {
            Boolean b = new TableBookingClass().UpdateTableBooking(vradd);
            if (b)
            {
                re.code = 200;
                re.message = "succesfully data has updated";
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
