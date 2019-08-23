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
        string uname, pwd;
        Boolean cou;
        public static int resid;

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
                    for (int i = 0; i < count1; i++)
                    {
                        uname = mangers[i].username;
                        pwd = mangers[i].password;
                        resid = mangers[i].restaurent_id;
                        if (uname.Equals(aa.username) && pwd.Equals(aa.password))
                        {
                            re.code = 200;
                            re.message = "Manger Login successfully";
                            cou = true;
                            resid = mangers[i].restaurent_id;
                        }
                        else
                        {
                          //  break;
                        }
                    }
                }
                if (count2 > 0)
                {
                    for (int i = 0; i < count2; i++)
                    {
                        uname = casier[i].Username;
                        pwd = casier[i].password;
                        resid = casier[i].restaurent_id;
                        if (uname.Equals(aa.username) && pwd.Equals(aa.password))
                        {
                            re.code = 200;
                            re.message = "casier Login successfully";
                            cou = true;
                            resid = casier[i].restaurent_id;
                        }
                        else
                        {
                           // break;
                        }
                    }
                }
                if(cou == true)
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
    }
}
public class admin
{
    public string username { get; set; }
    public string password { get; set; }
}