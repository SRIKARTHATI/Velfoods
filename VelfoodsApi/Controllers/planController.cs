using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class planController : ApiController
    {

        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        public string A;
        [HttpPost]
        [Route("getplannames")]
        public Responce getplans(vel_restro_plan plans)  
        {
            var plan = (from c in entity.vel_restro_plan
                        where c.restaurent_id == plans.restaurent_id
                        select new
                        {
                           c.plan_id,
                           c.plan_name,
                           c.plan_percentage,
                           A =c.plan_name+"-"+ c.plan_percentage+"%"
                        });
            re.Data = plan;
            re.code = 200;
            re.message = "Data Sucess";
            return re;
        }
    }
}
