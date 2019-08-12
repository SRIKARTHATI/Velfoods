using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class PropertyController : ApiController
    {
        velfoodsEntities2 ve = new velfoodsEntities2();
        Responce re = new Responce();
        [HttpGet]
        [Route("getproperty")]
        public Responce getproperty()
        {
            var ee = (from s in ve.vel_restro_property
                      select new
                      {
                          s.property_id,
                          s.property_name,
                          s.property_address,
                          s.property_mobile_no,
                          s.property_land_mark,
                          s.property_landline,
                          s.property_city,
                          s.property_email,
                          s.property_state,
                          s.property_website,
                          s.property_pincode,
                          s.property_gst,
                          s.property_country
                      });

            re.Data = ee;
            re.message = "getting details successfully";
            re.code = 200;
            return re;
        }
        [HttpPost]
        [Route("addproperty")]
        public IHttpActionResult addingproperty(vel_restro_property vradd)
        {
            Boolean b = new PropertyAdding().AddingProperty(vradd);
            if (b)
            {
                ve.vel_restro_property.Add(vradd);
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
        [Route("updateproperty")]
        public IHttpActionResult updatingproperty(vel_restro_property vru)
        {
            //var resup = (from a in ve.vel_restro_property
            //             where a.property_id == vru.property_id
            //             select a).FirstOrDefault();
            //if (resup != null)
            //{
            //    resup.property_name = vru.property_name;
            //    resup.property_address = vru.property_address;
            //    resup.property_city = vru.property_city;
            //    resup.property_country = vru.property_country;
            //    resup.property_email = vru.property_email;
            //    resup.property_gst = vru.property_gst;
            //    resup.property_landline = vru.property_landline;
            //    resup.property_land_mark = vru.property_land_mark;
            //    resup.property_mobile_no = vru.property_mobile_no;
            //    resup.property_pincode = vru.property_pincode;
            //    resup.property_state = vru.property_state;
            //    resup.property_website = vru.property_website;
            //    ve.SaveChanges();
            //    re.code = 200;
            //    re.message = "Updated successfully";
            //    return Content(HttpStatusCode.OK, re);
            //}
            //else
            //{
            //    re.code = 100;
            //    re.message = "failed to update data";
            //    return Content(HttpStatusCode.OK, re);
            //}


            Boolean be = new PropertyAdding().update(vru);
            if(be)
            {
                re.code = 200;
                re.message = "updated successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "failed to update data";
                return Content(HttpStatusCode.OK, re);
            }
        }
        [HttpPost]
        [Route("deleteproperty")]
        public IHttpActionResult deletingproperty(vel_restro_property vru)
        {
            var resup = (from a in ve.vel_restro_property
                         where a.property_id == vru.property_id
                         select a).FirstOrDefault();
            if (resup != null)
            {
                resup.property_id = vru.property_id;
                ve.vel_restro_property.Remove(resup);
                ve.SaveChanges();
                re.code = 200;
                re.message = "Deleted successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "failed to delete data";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
