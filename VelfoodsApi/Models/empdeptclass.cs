using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class empdeptclass
    {
        String empname;
        int count, empid;
        public Boolean adding(vel_restro_empdepartment dept)
        {
            List<vel_restro_empdepartment> list = new List<vel_restro_empdepartment>();
            using (velfoodsEntities1 en = new velfoodsEntities1())
            {
                list = en.vel_restro_empdepartment.OrderBy(a => a.empdepartement_id).ToList();
                int cc = list.Count;
                for(int i =0; i < cc; i++)
                {
                    empname = list[i].empdepartement_name;
                    empid = list[i].empdepartement_id;
                    if(dept.empdepartement_id.Equals(empid) && dept.empdepartement_name.Equals(empname) || dept.empdepartement_name.Equals(empname))
                    { 
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if(count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean update(vel_restro_empdepartment dept)
        {
            List<vel_restro_empdepartment> list =new List<vel_restro_empdepartment>();
            using (velfoodsEntities1  en =new velfoodsEntities1())
            {
                list = en.vel_restro_empdepartment.OrderBy(a => a.empdepartement_id).ToList();
                int cc = list.Count;
                for(int i=0; i<cc; i++)
                {
                    empid = list[i].empdepartement_id;
                    empname = list[i].empdepartement_name;
                    if (dept.empdepartement_name.Equals(empname) && dept.empdepartement_id.Equals(empid))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if(count == 0)
                {
                    return false;
                }
                else
                {
                    using (velfoodsEntities1  ent =new velfoodsEntities1())
                    {
                        vel_restro_empdepartment emp = (from c in ent.vel_restro_empdepartment
                                                        where c.empdepartement_id == dept.empdepartement_id
                                                        where c.empdepartement_name == dept.empdepartement_name
                                                        where c.restaurent_id == dept.restaurent_id
                                                        select c).FirstOrDefault();
                        emp.empdepartement_name = dept.empdepartement_name;
                        emp.empdepartement_status = dept.empdepartement_status;
                        ent.SaveChanges();
                    }
                    return true;
                }
            }

        }
    }
}