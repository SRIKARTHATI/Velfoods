using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class bankController : ApiController
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();
        [HttpPost]
        [Route("getbanks")]
        public Responce getbanks(vel_restro_banks bank)
        {
            var a = (from c in entity.vel_restro_banks
                     where bank.restaurent_id == c.restaurent_id
                     select new
                     {
                         c.bank_id,
                         c.bank_code,
                         c.bank_name,
                         c.bank_account_no,
                         c.bank_status,
                         c.bank_reporting_name,
                         c.empregistration_id
                     });
            re.Data = a;
            re.message = "Data Succuess";
            re.code = 200;
            return re;
        } 
        [HttpPost]
        [Route("addbanks")]
        public IHttpActionResult insert(vel_restro_banks bank)
        {
            Boolean b = new bankdetailsClass().adding(bank);
            if (b)
            {
                entity.vel_restro_banks.Add(bank);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Data inserted sucuessfully";
                return Content(HttpStatusCode.OK, re);

            }
            else
            {
                re.code = 100;
                re.message = "Data inserted fail please check the value";
                return Content(HttpStatusCode.OK, re);
            }
        }
        [HttpPost]
        [Route("updatebanks")]
        public IHttpActionResult update (vel_restro_banks bank)
        {
            Boolean b = new bankdetailsClass().update(bank);
            if (b)
            {
                re.code = 200;
                re.message = "Data updated sucuessfully";
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
