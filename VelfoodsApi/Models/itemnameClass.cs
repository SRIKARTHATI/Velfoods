using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class itemnameClass
    {
        int count,restarentid;
        string itemname;
        public Boolean adding (vel_restro_itemname iname)
        {
            List<vel_restro_itemname> list = new List<vel_restro_itemname>();
            using (velfoodsEntities2 en =new velfoodsEntities2())
            {
                list = en.vel_restro_itemname.OrderBy(a => a.itemname_id).ToList();
                int c = list.Count;
                for(int i=0; i<c; i++)
                {
                    itemname = list[i].itemname_item_name;
                    restarentid = list[i].restaurent_id;
                    if(iname.itemname_item_name.Equals(itemname) && iname.restaurent_id.Equals(restarentid))
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

        public Boolean update(vel_restro_itemname name)
        {
            List<vel_restro_itemname> list = new List<vel_restro_itemname>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_itemname.OrderBy(a => a.itemname_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    itemname = list[i].itemname_item_name;
                    restarentid = list[i].restaurent_id;
                    if (name.itemname_item_name.Equals(itemname) && name.restaurent_id.Equals(restarentid))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count == 1)
                {
                    using (velfoodsEntities2 enn =new velfoodsEntities2())
                    {
                        vel_restro_itemname names = (from inam in enn.vel_restro_itemname
                                                     where inam.restaurent_id == name.restaurent_id
                                                     where inam.itemname_item_name == name.itemname_item_name
                                                     select inam).FirstOrDefault();
                        names.itemname_item_name = name.itemname_item_name;
                        names.itemname_description = name.itemname_description;
                        names.itemname_reportingname = name.itemname_reportingname;
                        names.itemname_active_from = name.itemname_active_from;
                        names.itemname_status = name.itemname_status;
                        names.item_dinein_amount = name.item_dinein_amount;
                        names.item_dinein_tax = name.item_dinein_tax;
                        names.item_takeaway_amount = name.item_takeaway_amount;
                        names.item_takeaway_tax = name.item_takeaway_tax;
                        names.item_homedelivary_amount = name.item_homedelivary_amount;
                        names.item_homedelivary_tax = name.item_homedelivary_tax;
                        names.item_homedelivery_deliverycharges = name.item_homedelivery_deliverycharges;
                        enn.SaveChanges();
                    }
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