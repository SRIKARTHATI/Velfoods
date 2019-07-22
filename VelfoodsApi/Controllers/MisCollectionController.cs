using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class MisCollectionController : ApiController
    {
        velfoodsEntities1 ve = new velfoodsEntities1();
        Responce re = new Responce();
        [HttpPost]
        [Route("addingmiscollection")]
        public IHttpActionResult AddingMiscol(vel_restro_miscollection vradd)
        {
            Boolean b = new MiscollectionClass().AddingMiscol(vradd);
            if (b)
            {
                ve.vel_restro_miscollection.Add(vradd);
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
    }
}
