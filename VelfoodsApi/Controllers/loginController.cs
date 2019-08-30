using System;
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
        string uname, pwd,name;
        Boolean cou;
        int id;
        public static int resid;
        public static string user;
        public string mangername, casiername;

        [HttpGet]
        [Route("Restaurents")]
        public Responce getRestos(vel_restro_restaurent res)
        {
            var rest = (from c in entity.vel_restro_restaurent
                        select new
                        {
                            c.restaurent_id,
                            c.restaurent_name
                        });
            re.Data = rest;
            re.code = 200;
            re.message = "Data Sucess";
            return re;
        }
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
            var manger1 = (from cash in entity.vel_restro_empregistration
                          join cash1 in entity.vel_restro_empdepartment on cash.empdepartement_id equals cash1.empdepartement_id
                          where cash1.empdepartement_name == "manger"
                           where cash.empregistration_status == "Active"
                          select cash).ToList();
            int mange1 = manger1.Count;

            if (count > 0 ||count1 >0 || count2 >0 || mange1 >0)
            {
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        uname = admin[i].admin_username;
                        pwd = admin[i].admin_password;
                        if(uname.Equals(aa.username) && pwd.Equals(aa.password))
                        {
                            re.code = 200;
                            re.message = "Admin Login successfully";
                            cou = true;
                            var ee = (from c in entity.vel_restro_restaurent
                                      select c).ToList();
                            int rescount = ee.Count;
                        }
                        else
                        {
                          //  break;
                        }
                    }
                }
                if (count1 > 0)
                {
                    for (int j = 0; j < count1; j++)
                    {
                        if (aa.username.Equals(mangers[j].username))
                        {
                            for (int i = 0; i < count1; i++)
                            {

                                uname = mangers[i].username;
                                pwd = mangers[i].password;
                                id = mangers[i].restaurent_id;
                                if (uname.Equals(aa.username) && pwd.Equals(aa.password))
                                {
                                    resid = id;
                                    re.resid = id;
                                    re.user = uname;
                                    re.passw = "Manger";
                                    var ee = (from c in entity.vel_restro_restaurent
                                              where c.restaurent_id == re.resid
                                              select new
                                              {
                                                  c.restaurent_name,
                                                  name = c.restaurent_name
                                              }).ToList();
                                    int nt = ee.Count; if (nt > 0) { re.rname = ee[0].restaurent_name; }
                                    re.code = 200;
                                    re.message = "Manger Login successfully";
                                    cou = true;

                                }
                                else
                                {
                                    //  break;
                                }
                            }
                        }
                    }
                    
                     
                    
                }
                if (count2 > 0)
                {
                    for(int j = 0; j < count2; j++)
                    {
                        if (aa.username.Equals(casier[j].Username))
                        {
                            for (int i = 0; i < count2; i++)
                            {
                                uname = casier[i].Username;
                                casiername = casier[i].Username;
                                pwd = casier[i].password;
                                id = casier[i].restaurent_id;
                                if (uname.Equals(aa.username) && pwd.Equals(aa.password))
                                {
                                    resid = id;
                                    re.resid = id;
                                    re.user = uname;
                                    re.passw = "Cashier";
                                    var ee = (from c in entity.vel_restro_restaurent
                                              where c.restaurent_id == re.resid
                                              select new
                                              {
                                                  c.restaurent_name,
                                                  name = c.restaurent_name
                                              }).ToList();
                                    int nt = ee.Count; if (nt > 0) { re.rname = ee[0].restaurent_name; }

                                    re.code = 200;
                                    re.message = "Cashier Login successfully";
                                    cou = true;

                                }
                                else
                                {
                                    // break;
                                }
                            }
                    }
                    
                    }
                }
                if (mange1 > 0)
                {
                    for(int j = 0; j < mange1; j++)
                    {
                        if (aa.username.Equals(manger1[j].Username))
                        {
                            for (int i = 0; i < mange1; i++)
                            {
                                uname = manger1[i].Username;
                                mangername = manger1[i].Username;
                                pwd = manger1[i].password;
                                id = manger1[i].restaurent_id;
                                if (uname.Equals(aa.username) && pwd.Equals(aa.password))
                                {
                                    resid = id;
                                    re.resid = id;
                                    re.user = uname;
                                    re.passw = "Manger";
                                    var ee = (from c in entity.vel_restro_restaurent
                                              where c.restaurent_id == re.resid
                                              select new
                                              {
                                                  c.restaurent_name,
                                                  name = c.restaurent_name
                                              }).ToList();
                                    int nt = ee.Count; if (nt > 0) { re.rname = ee[0].restaurent_name; }

                                    re.code = 200;
                                    re.message = "Manger Login successfully";
                                    cou = true;

                                }
                                else
                                {
                                    //  break;
                                }
                            }

                        }
                        else
                        {

                        }
                    }
                }
                if (cou == true)
                {
                    return Content(HttpStatusCode.OK, re);
                }
                else
                {
                    re.code = 100;
                    re.message = "Please check the username and password";
                    return Content(HttpStatusCode.OK, re);
                }

            }
            else
            {
                re.code = 100;
                re.message = "Please check the username and password";
                return Content(HttpStatusCode.OK, re);
            }

        }

        //[HttpPost]
        //[Route("sucess")]
        //public Responce success(admin a)
        //{
        //    var admin = (from c in entity.vel_restro_Admin
        //                 where c.admin_status == "Active"
        //                 where c.admin_username == a.username
        //                 where c.admin_password == a.password
        //                 select c).ToList();
        //    int count = admin.Count;
        //    //manger
        //    var mangers = (from cc in entity.vel_restro_manger
        //                   where cc.manger_status == "Active"
        //                   where cc.username == a.username
        //                   where cc.password ==a.password
        //                   select cc).ToList();
        //    int count1 = mangers.Count;
        //    //casier
        //    var casier = (from cash in entity.vel_restro_empregistration
        //                  join cash1 in entity.vel_restro_empdepartment on cash.empdepartement_id equals cash1.empdepartement_id
        //                  where cash1.empdepartement_name == "Cashier"
        //                  where cash.empregistration_status == "Active"
        //                  where cash.Username ==a.username
        //                  where cash.password ==a.password
        //                  select cash).ToList();
        //    int count2 = casier.Count;
        //    var manger1 = (from mm in entity.vel_restro_empregistration
        //                   join mm1 in entity.vel_restro_empdepartment on mm.empdepartement_id equals mm1.empdepartement_id
        //                   where mm1.empdepartement_name == "manger"
        //                   where mm.empregistration_status == "Active"
        //                   select mm).ToList();
        //    int mange1 = manger1.Count;

        //    if (count >0 || count1 >0 ||count2 > 0 ||mange1 >0)
        //    { 
        //        if (count > 0)
        //        {
                    
        //        }
        //        if(count1 >0 )
        //        {
        //            re.user = mangers[0].username;
        //            user = "manger";
        //            re.passw = user;
        //            re.resid = mangers[0].restaurent_id;
        //            var ee = (from c in entity.vel_restro_restaurent
        //                      where c.restaurent_id == re.resid
        //                      select new
        //                      {
        //                          c.restaurent_name,
        //                          name = c.restaurent_name
        //                      }).ToList();
        //            int nt = ee.Count; if(nt > 0) { re.rname = ee[0].restaurent_name; }
        //        }
        //        if (count2 > 0)
        //        {
        //            if (a.username.Equals(casier[0].Username))
        //            {
        //                re.user = casier[0].Username;
        //                user = "Cashier";
        //                re.passw = user;
        //                re.resid = casier[0].restaurent_id;
        //                var ee = (from c in entity.vel_restro_restaurent
        //                          where c.restaurent_id == re.resid
        //                          select new
        //                          {
        //                              c.restaurent_name,
        //                              name = c.restaurent_name
        //                          }).ToList();
        //                int nt = ee.Count; if (nt > 0) { re.rname = ee[0].restaurent_name; }
        //            }
        //        }
        //        if(mange1 > 0)
        //        {
        //            if (a.username.Equals(manger1[0].Username))
        //            {
        //                re.user = manger1[0].Username;
        //                user = "manger";
        //                re.passw = user;
        //                re.resid = manger1[0].restaurent_id;
        //                var ee = (from c in entity.vel_restro_restaurent
        //                          where c.restaurent_id == re.resid
        //                          select new
        //                          {
        //                              c.restaurent_name,
        //                              name = c.restaurent_name
        //                          }).ToList();
        //                int nt = ee.Count; if (nt > 0) { re.rname = ee[0].restaurent_name; }
        //            }
        //        }
        //    }
           
        //    re.code = 200;
        //    re.message = "Data success";
        //    return re;
        //}
    }
}
public class admin
{
    public string username { get; set; }
    public string password { get; set; }
}