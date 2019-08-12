using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class empregController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("empregvalues")]
        public  Responce getvalues(vel_restro_empregistration reg)
        {
            var ee = (from c in entity.vel_restro_empregistration
                      where c.restaurent_id == reg.restaurent_id
                      select new
                      {
                          c.empregistration_id,
                          c.empregistration_name,
                          c.empregistration_mobile_no,
                          c.empregistration_email_id,
                          c.empregistration_id_proof,
                          c.empregistration_id_data,
                          c.empregistration_Address,
                          c.empdepartement_id,
                          c.empregistration_status,
                          c.empregistration_login_type,
                          c.Username,
                          c.password,
                          c.restaurent_id
                      });
            re.Data = ee;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }
        [HttpPost]
        [Route("captains")]
        public Responce getcaptains(vel_restro_empregistration reg)
        {
            var ee = (from c in entity.vel_restro_empregistration
                      join cc in entity.vel_restro_empdepartment on c.empdepartement_id  equals cc.empdepartement_id
                      where c.restaurent_id == reg.restaurent_id
                      where cc.empdepartement_name == "Captain"
                      select new
                      {
                          c.empregistration_id,
                          c.empregistration_name
                      });
            re.Data = ee;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("stewards")]
        public Responce getstewards(vel_restro_empregistration reg)
        {
            var ee = (from c in entity.vel_restro_empregistration
                      join cc in entity.vel_restro_empdepartment on c.empdepartement_id equals cc.empdepartement_id
                      where c.restaurent_id == reg.restaurent_id
                      where cc.empdepartement_name == "Steward"
                      select new
                      {
                          c.empregistration_id,
                          c.empregistration_name
                      });
            re.Data = ee;
            re.message = "Data sucess";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("empreginsert")]
        public IHttpActionResult insert(vel_restro_empregistration reg)
        {
            Boolean b = new empregClass().adding(reg);
            if (b)
            {
                entity.vel_restro_empregistration.Add(reg);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Data inserted sucessfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Data inserted fail please check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("empregupdate")]
        public IHttpActionResult update(vel_restro_empregistration reg)
        {
            Boolean b = new empregClass().update(reg);
            if (b)
            {
                re.code = 200;
                re.message = "Data updated sucessfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Data updated fail please check the values";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
