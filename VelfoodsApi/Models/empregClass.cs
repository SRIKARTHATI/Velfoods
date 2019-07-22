using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class empregClass
    {
        int count, empregid;
        string empregname;

        public Boolean adding(vel_restro_empregistration reg)
        {
            List<vel_restro_empregistration> list = new List<vel_restro_empregistration>();

            using(velfoodsEntities1 en =new velfoodsEntities1())
            {
                list = en.vel_restro_empregistration.OrderBy(a => a.empregistration_id).ToList();
                int cc = list.Count;
                for(int i =0; i < cc; i++)
                {
                    empregname = list[i].empregistration_name;
                    empregid = list[i].empregistration_id;
                    if (reg.empregistration_id.Equals(empregid) && reg.empregistration_name.Equals(empregname))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public Boolean update(vel_restro_empregistration reg)
        {
            List<vel_restro_empregistration> list = new List<vel_restro_empregistration>();

            using (velfoodsEntities1 en = new velfoodsEntities1())
            {
                list = en.vel_restro_empregistration.OrderBy(a => a.empregistration_id).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    empregname = list[i].empregistration_name;
                    empregid = list[i].empregistration_id;
                    if (reg.empregistration_id.Equals(empregid) && reg.empregistration_name.Equals(empregname) || reg.empregistration_name.Equals(empregname))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count == 0)
                {
                    return false;
                }
                else
                {
                    using (velfoodsEntities1 enn =new velfoodsEntities1())
                    {
                        vel_restro_empregistration registration = (from c in enn.vel_restro_empregistration
                                                                   where c.empregistration_id == reg.empregistration_id
                                                                   where c.empregistration_name == reg.empregistration_name
                                                                   where c.restaurent_id == reg.restaurent_id
                                                                   select c).FirstOrDefault();
                        registration.empregistration_name = reg.empregistration_name;
                        registration.empregistration_mobile_no = reg.empregistration_mobile_no;
                        registration.empregistration_email_id = reg.empregistration_email_id;
                        registration.empregistration_id_proof = reg.empregistration_id_proof;
                        registration.empregistration_id_data = reg.empregistration_id_data;
                        registration.empregistration_Address = reg.empregistration_Address;
                        registration.empdepartement_id = reg.empdepartement_id;
                        registration.empregistration_status = reg.empregistration_status;
                        registration.empregistration_login_type = reg.empregistration_login_type;
                        registration.Username = reg.Username;
                        registration.password = reg.password;
                        enn.SaveChanges();
                    }
                    return true;
                }
            }

        }
    }
}