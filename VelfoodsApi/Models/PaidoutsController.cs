//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using VelfoodsApi.Models;

//namespace VelfoodsApi.Controllers
//{
//    public class PaidoutsController : ApiController
//    {
//        velfoodsEntities2 ve = new velfoodsEntities2();
//        Responce re = new Responce();
//        [HttpPost]
//        [Route("getpaidouts")]
//        public Responce getpaidouts(vel_restro_paidouts vp)
//        {
//            var a = (from s in ve.vel_restro_paidouts
//                     where s.restaurent_id == vp.restaurent_id
//                     select new
//                     {
//                         s.paidout_id,
//                         s.paidout_name,
//                         s.paidout_pariticular,
//                         s.paidout_reportingname,
//                         s.restaurent_id,
//                         s.transaction_id,
//                         s.type_of_payment,
//                         s.Amoount,
//                         s.bank_name
//                     });
//                     re.Data = a;
//                     re.code = 200;
//                     re.message = "getting details successfully";
//                     return re;
//        }
//        [HttpPost]
//        [Route("addingpaidouts")]
//         public IHttpActionResult AddingPaidouts(vel_restro_paidouts vradd)
//        {
//            Boolean b = new PaidoutsClass().AddingPaidouts(vradd);
//            if (b)
//            {
//                ve.vel_restro_paidouts.Add(vradd);
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
//        [HttpPost]
//        [Route("updatepaidouts")]
//        public IHttpActionResult UpdatePaidouts(vel_restro_paidouts vradd)
//        {
//            Boolean b = new PaidoutsClass().UpdatePaidouts(vradd);
//            if(b)
//            {
//                re.code = 200;
//                re.message = "succesfully data has updated";
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
