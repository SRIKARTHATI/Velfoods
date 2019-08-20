﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class printClass
    {
        velfoodsEntities2 entity = new velfoodsEntities2();
        int printid, tabledefinationid,count;
        public Boolean addprints(vel_restro_print print)
        {
            List<vel_restro_print> list = new List<vel_restro_print>();
            using (velfoodsEntities2 en =new velfoodsEntities2())
            {
                list = en.vel_restro_print.OrderBy(a => a.print_id).ToList();
                int cc = list.Count;
                for(int i=0; i<cc; i++)
                {
                    printid = list[i].print_id;
                    tabledefinationid = list[i].table_defination_id;
                    if (printid.Equals(print.print_id) && tabledefinationid.Equals(print.table_defination_id))
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
                    var ee = (from c in entity.vel_restro_tabledefination
                              where c.table_defination_id == print.table_defination_id
                              select c).FirstOrDefault();
                    ee.BACKGROUND_COLOR = "Darkslategray";
                    entity.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean update(vel_restro_print print)
        {
            List<vel_restro_print> list = new List<vel_restro_print>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_print.OrderBy(a => a.print_id).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    printid = list[i].print_id;
                    tabledefinationid = list[i].table_defination_id;
                    if (printid.Equals(print.print_id) && tabledefinationid.Equals(print.table_defination_id))
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
                    using (velfoodsEntities2 ent = new velfoodsEntities2())
                    {
                        vel_restro_print printss = (from c in entity.vel_restro_print
                                                    where c.restaurent_id == print.restaurent_id
                                                    where c.table_defination_id == print.table_defination_id
                                                    where c.print_id == print.print_id
                                                    select c).FirstOrDefault();
                        printss.print_status = print.print_status;
                        ent.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}