using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VelfoodsApi.Models;

namespace VelfoodsApi.Models
{
    public class RestaurantClass
    {
        public int restoid;
        public string restaurent_name;
        public string restaurent_address;
        public long restaurent_mobile_no;
        public string restostatus;
        public string restrent_manger;
        public int propertyid;
        public int count;
        public Boolean AddingRestaurant(vel_restro_restaurent resto)
        {
            List<vel_restro_restaurent> list = new List<vel_restro_restaurent>();
            using (velfoodsEntities2 entity = new velfoodsEntities2())
            {
                list = entity.vel_restro_restaurent.OrderBy(a => a.restaurent_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    restaurent_name = list[i].restaurent_name;
                    restaurent_address = list[i].restaurent_address;
                    restaurent_mobile_no = list[i].restaurent_mobile_no;
                    restostatus = list[i].restaruent_status;
                    restrent_manger = list[i].restrent_manger;
                    if (resto.restaurent_name.Equals(restaurent_name) && resto.restaurent_address.Equals(restaurent_address) && resto.restaurent_mobile_no.Equals(restaurent_mobile_no) && resto.restrent_manger.Equals(restrent_manger))
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
        public Boolean UpdatingRestaurant(vel_restro_restaurent resto)
        {
            List<vel_restro_restaurent> list = new List<vel_restro_restaurent>();

            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_restaurent.OrderBy(a => a.restaurent_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    restoid = list[i].restaurent_id;
                    if (resto.restaurent_id.Equals(restoid))
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
                        vel_restro_restaurent vp = (from s in entit.vel_restro_restaurent
                                                         where s.restaurent_id == resto.restaurent_id
                                                         select s).FirstOrDefault();
                        vp.restaurent_name = resto.restaurent_name;
                        vp.restaurent_mobile_no = resto.restaurent_mobile_no;
                        vp.restaurent_address = resto.restaurent_address;
                        vp.restrent_manger = resto.restrent_manger;
                        vp.restaruent_status = resto.restaruent_status;
                        entit.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}