//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using VelfoodsApi.Models;

//namespace VelfoodsApi.Controllers
//{
//    public class ManagerController : ApiController
//    {
//        velfoodsEntities2 ve = new velfoodsEntities2();
//        Responce re = new Responce();

//        public ManagerController()
//        {
//        }

//        [HttpPost]
//        [Route("gettingmanagers")]
//        public Responce gettingmanagers(vel_restro_manger mgr)
//        {
//            var a = (from s in ve.vel_restro_manger
//                     where s.restaurent_id == mgr.restaurent_id
//                     select new
//                     {
//                         s.manger_id,
//                         s.manger_name,
//                         s.manger_mobile_no,
//                         s.manger_contact_no,
//                         s.manger_id_proof,
//                         s.manger_id_no,
//                         s.manger_status,
//                         s.restaurent_id
//                     });
//            re.Data = a;
//            re.message = "Getting details successfully";
//            re.code = 200;
//            return re;
//        }

//        [HttpPost]
//        [Route("addingmanager")]
//        public IHttpActionResult addingmanager(vel_restro_manger mngra)
//        {
//            Boolean b = new ManagerClass().AddingManager(mngra);
//            if (b)
//            {
//                ve.vel_restro_manger.Add(mngra);
//                ve.SaveChanges();
//                re.code = 200;
//                re.message = "Succesfully data has inserted";
//                return Content(HttpStatusCode.OK, re);
//            }
//            else
//            {
//                re.code = 100;
//                re.message = "Failed to insert data";
//                return Content(HttpStatusCode.OK, re);
//            }
//        }

//        [HttpPost]
//        [Route("updatingmanager")]
//        public IHttpActionResult updatingmanager(vel_restro_manger mngru)
//        {
//            Boolean b = new ManagerClass().UpdatingManager(mngru);
//            if (b)
//            {
//                re.code = 200;
//                re.message = "Succesfully data has updated";
//                return Content(HttpStatusCode.OK, re);
//            }
//            else
//            {
//                re.code = 100;
//                re.message = "Failed to update data";
//                return Content(HttpStatusCode.OK, re);
//            }
//        }
//    }
//}
