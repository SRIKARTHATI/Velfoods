//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using VelfoodsApi.Models;

//namespace VelfoodsApi.Controllers
//{
//    public class MisCollectionController : ApiController
//    {
//        velfoodsEntities2 ve = new velfoodsEntities2();
//        Responce re = new Responce();

//        [HttpPost]
//        [Route("getmiscollection")]
//        public Responce getmiscollection(vel_restro_miscollection vp)
//        {
//            var a = (from s in ve.vel_restro_miscollection
//                     where s.restaurent_id == vp.restaurent_id
//                     select new
//                     {
//                         s.miscollection_id,
//                         s.miscollection_name,
//                         s.miscollection_pariticular,
//                         s.miscollection_reportingname,
//                         s.restaurent_id,
//                         s.transaction_id,
//                         s.type_of_payment,
//                         s.Amoount,
//                         s.bank_name
//                     });
//            re.Data = a;
//            re.code = 200;
//            re.message = "getting details successfully";
//            return re;
//        }

//        [HttpPost]
//        [Route("addingmiscollection")]
//        public IHttpActionResult AddingMiscol(vel_restro_miscollection vradd)
//        {
//            Boolean b = new MiscollectionClass().AddingMiscol(vradd);
//            if (b)
//            {
//                ve.vel_restro_miscollection.Add(vradd);
//                ve.SaveChanges();
//                re.code = 200;
//                re.message = "succesfully data has inserted";
//                return Content(HttpStatusCode.OK, re);
//            }
//            else
//            {
//                re.code = 100;
//                re.message = "failed to insert data";
//                return Content(HttpStatusCode.OK, re);
//            }
//        }
//    }
//}
