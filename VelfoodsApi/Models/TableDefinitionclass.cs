using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class TableDefinitionclass
    {
        public int table_defination_id;
        public string table_capatain;
        public string table_description;
        public string table_name;
        public int table_pax;
        public string table_status;
        public string table_steward;
        public string table_view;
        public int restaurent_id;
        public int count;
        public Boolean TableDef(vel_restro_tabledefination veltbl)
        {
            List<vel_restro_tabledefination> list = new List<vel_restro_tabledefination>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_tabledefination.OrderBy(a => a.table_defination_id).ToList();
                int c = list.Count;
                veltbl.restaurent_id = 1;
                for(int i =0; i < c; i++)
                {
                    table_name = list[i].table_name;
                    table_capatain = list[i].table_capatain;
                    table_description = list[i].table_description;
                    table_pax = list[i].table_pax;
                    table_status = list[i].table_status;
                    table_steward = list[i].table_steward;
                    table_view = list[i].table_view;
                    restaurent_id = list[i].restaurent_id;
                    if (veltbl.table_name.Equals(table_name) && veltbl.table_description.Equals(table_description) && veltbl.table_pax.Equals(table_pax) && veltbl.table_status.Equals(table_status) &&
                        veltbl.table_steward.Equals(table_steward) && veltbl.table_view.Equals(table_view) && veltbl.restaurent_id.Equals(restaurent_id)&& veltbl.table_capatain.Equals(table_capatain))
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
        public Boolean tableup(vel_restro_tabledefination tbl)
        {
            List<vel_restro_tabledefination> list = new List<vel_restro_tabledefination>();

            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_tabledefination.OrderBy(a => a.table_defination_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    table_name = list[i].table_name;
                    table_pax = list[i].table_pax;
                    table_defination_id = list[i].table_defination_id;
                    if (table_name.Equals(table_name) && table_pax.Equals(table_pax) && table_defination_id.Equals(table_defination_id))
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
                    using (velfoodsEntities2 entit = new velfoodsEntities2())
                    {
                        vel_restro_tabledefination vp = (from s in entit.vel_restro_tabledefination
                                                  where s.table_defination_id == tbl.table_defination_id
                                                  where s.restaurent_id == tbl.restaurent_id
                                                  select s).FirstOrDefault();
                        vp.table_capatain = tbl.table_capatain;
                        vp.table_steward = tbl.table_steward;
                        vp.table_description = tbl.table_description;
                        vp.table_status = tbl.table_status;
                        vp.table_view = tbl.table_view;
                        vp.BACKGROUND_COLOR = tbl.BACKGROUND_COLOR;
                        entit.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}