using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class printController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("getprints")]
        public Responce getprints(vel_restro_print print)
        {
            var ee = (from c in entity.vel_restro_print
                      where c.restaurent_id == print.restaurent_id
                      select new
                      {
                          c.print_id,
                          c.total_amount,
                          c.table_defination_id,
                          c.offers_id,
                          c.discount_amount,
                          c.print_status,
                          c.restaurent_id,
                          c.table_name
                      });
            re.Data = ee;
            re.code = 200;
            re.message = "Data success";
            return re;
        }
        [HttpPost]
        [Route("getprintid")]
        public Responce getprintid(vel_restro_print print)
        {
            var ee = (from c in entity.vel_restro_print
                      where c.restaurent_id == print.restaurent_id
                      where c.table_name == print.table_name
                      where c.print_status == "Printed"
                      select new
                      {
                          c.print_id,
                          c.total_amount,
                          c.table_defination_id,
                          c.offers_id,
                          c.total_after_discount,
                          c.discount_amount,
                          c.print_status,
                          c.restaurent_id,
                          c.table_name
                      });
            re.Data = ee;
            re.code = 200;
            re.message = "Data success";
            return re;
        }

        [HttpPost]
        [Route("printinsert")]
        public IHttpActionResult insert(vel_restro_print print)
        {
            Boolean b = new printClass().addprints(print);
            if (b == true)
            {
                entity.vel_restro_print.Add(print);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Data inserted sucuessfully";
                return Content(HttpStatusCode.OK, re);

            }
            else if (b == false)
            {
                re.code = 100;
                re.message = "Data inserted fail please check the value";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "table not found";
                return Content(HttpStatusCode.OK, re);
            }
        }
        [HttpPost]
        [Route("printupdate")]
        public IHttpActionResult update(vel_restro_print print)
        {
            Boolean b = new printClass().update(print);
            if (b)
            {
                re.code = 200;
                re.message = "Data updated sucuessfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Data updated fail please check the value";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
