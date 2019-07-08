using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class empcategoryController : ApiController
    {
        velfoodsEntities1 entity = new velfoodsEntities1();
        Responce re = new Responce();
        [HttpPost]
        [Route("getempdepartments")]
        public  Responce getvalues(vel_restro_empdepartment dept)
        {
            var res = (from c in entity.vel_restro_empdepartment
                       where c.restaurent_id == dept.restaurent_id
                       select new
                       {
                           c.empdepartement_id,
                           c.empdepartement_name,
                           c.empdepartement_status,
                           c.restaurent_id
                       });
            re.Data = res;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("empdeptinsert")]
        public  IHttpActionResult insert(vel_restro_empdepartment dept)
        {
            Boolean b = new empdeptclass().adding(dept);

            if (b)
            {
                entity.vel_restro_empdepartment.Add(dept);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Data inserted sucessfull";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "inserted fail please check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("empdeptupdate")]
        public IHttpActionResult update(vel_restro_empdepartment dept)
        {
            Boolean b = new empdeptclass().update(dept);
            if (b)
            {
                re.code = 200;
                re.message = "Data updated sucessfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Data updated unsuccessfull please check the field values";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
