﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class loginController : ApiController
    {

        velfoodsEntities2 entity = new velfoodsEntities2();
        Responce re = new Responce();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult login(admin aa)
        {
            //admin
            var admin = (from c in entity.vel_restro_Admin
                         where c.admin_status == "Active"
                         select c).ToList();
            int count = admin.Count;
            //manger
            var mangers = (from cc in entity.vel_restro_manger
                           where cc.manger_status =="Active"
                           select cc).ToList();
            int count1 = mangers.Count;
            //casier
            var casier = (from cash in entity.vel_restro_empregistration
                          join cash1 in entity.vel_restro_empdepartment on cash.empdepartement_id equals cash1.empdepartement_id
                          where cash1.empdepartement_name == "Cashier"
                          where cash.empregistration_status =="Active"
                          select cash).ToList();
            int count2 = casier.Count;
            if (count > 0 ||count1 >0 || count2 >0)
            {

                re.code = 200;
                re.message = "Login successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Please check the username and password";
                return Content(HttpStatusCode.OK, re);
            }

        }
    }
}
public class admin
{
    public string username { get; set; }
    public string password { get; set; }
}