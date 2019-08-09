using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class itemcategoryclass
    {
        string itemcategoryname;
        int count, itemcategoryid,restrent_id;
        public Boolean adding(vel_restro_itemcategory category)
        {
            List<vel_restro_itemcategory> list = new List<vel_restro_itemcategory>();
            using (velfoodsEntities2 en =new velfoodsEntities2())
            {
                list = en.vel_restro_itemcategory.OrderBy(a => a.item_name).ToList();
                int cou = list.Count;
                for (int i=0; i<cou; i++)
                {
                    itemcategoryname = list[i].item_name;
                    restrent_id = list[i].restaurent_id;

                    if (category.item_name.Equals(itemcategoryname) )
                    {
                        //&& category.restaurent_id.Equals(restrent_id)
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count ==0)
                {
                    return true;
                }
                else
                {
                    return false; 
                }
            }
        }
        public Boolean update(vel_restro_itemcategory cate)
        {
            List<vel_restro_itemcategory> list = new List<vel_restro_itemcategory>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_itemcategory.OrderBy(a => a.itemcategory_id).ToList();
                int cou = list.Count;
                for (int i = 0; i < cou; i++)
                {
                    itemcategoryid = list[i].itemcategory_id;
                    itemcategoryname = list[i].item_name;
                    restrent_id = list[i].restaurent_id;
                    if (cate.item_name.Equals(itemcategoryname) && cate.restaurent_id.Equals(restrent_id))
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
                    using(velfoodsEntities2 ent =new velfoodsEntities2())
                    {
                        vel_restro_itemcategory category = (from c in ent.vel_restro_itemcategory
                                                            where c.item_name == cate.item_name
                                                            where c.restaurent_id == cate.restaurent_id
                                                            select c).FirstOrDefault();
                        category.item_name = cate.item_name;
                        category.item_description = cate.item_description;
                        category.item_active_from = cate.item_active_from;
                        category.item_status = cate.item_status;
                        category.item_reporting_name = cate.item_reporting_name;
                        ent.SaveChanges();

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