using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class TableDefinitionController : ApiController
    {
        velfoodsEntities1 ve = new velfoodsEntities1();
        Responce re = new Responce();
        [HttpGet]
        [Route("gettabledefinition")]
        public Responce getproperty()
        {
            var ee = (from s in ve.vel_restro_tabledefination
                      select new
                      {
                          s.table_defination_id,
                          s.table_capatain,
                          s.table_description,
                          s.table_name,
                          s.table_pax,
                          s.table_status,
                          s.table_steward,
                          s.table_view
                      });

            re.Data = ee;
            re.message = "getting details successfully";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("tabledefadding")]
        public IHttpActionResult AddingTable(vel_restro_tabledefination tbl)
        {
            Boolean b = new TableDefinitionclass().TableDef(tbl);
            if (b)
            {
                ve.vel_restro_tabledefination.Add(tbl);
                ve.SaveChanges();
                re.code = 200;
                re.message = "data inserted succesfully";
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
        [Route("tableupdate")]
        public IHttpActionResult UpdateTable(vel_restro_tabledefination tbl)
        {
            Boolean b = new TableDefinitionclass().tableup(tbl);
            if (b)
            {
                //ve.vel_restro_tabledefination.Add(tbl);
                //ve.SaveChanges();
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
