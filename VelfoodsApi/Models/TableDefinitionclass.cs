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
        public int count;
        public Boolean TableDef(vel_restro_tabledefination veltbl)
        {
            List<vel_restro_tabledefination> list = new List<vel_restro_tabledefination>();
            using (velfoodsEntities1 en = new velfoodsEntities1())
            {
                list = en.vel_restro_tabledefination.OrderBy(a => a.table_defination_id).ToList();
                int c = list.Count;
                for(int i =0; i < c; i++)
                {
                    table_name = list[i].table_name;
                    table_capatain = list[i].table_capatain;
                    table_description = list[i].table_description;
                    table_pax = list[i].table_pax;
                    table_status = list[i].table_status;
                    table_steward = list[i].table_steward;
                    table_view = list[i].table_view;
                    if (table_name.Equals(table_name) && table_description.Equals(table_description) && table_pax.Equals(table_pax) && table_status.Equals(table_status) &&
                        table_steward.Equals(table_steward) && table_view.Equals(table_view))
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

            using (velfoodsEntities1 en = new velfoodsEntities1())
            {
                list = en.vel_restro_tabledefination.OrderBy(a => a.table_defination_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    table_name = list[i].table_name;
                    table_capatain = list[i].table_capatain;
                    table_description = list[i].table_description;
                    table_pax = list[i].table_pax;
                    table_status = list[i].table_status;
                    table_steward = list[i].table_steward;
                    table_view = list[i].table_view;
                    if (table_name.Equals(table_name) && table_description.Equals(table_description) && table_pax.Equals(table_pax) && table_status.Equals(table_status) &&
                        table_steward.Equals(table_steward) && table_view.Equals(table_view))
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
    }
}