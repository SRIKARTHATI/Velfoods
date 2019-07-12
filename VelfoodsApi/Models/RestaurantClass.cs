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
        public string restoname;
        public string restoaddress;
        public long restomobile;
        public string restostatus;
        public string restomanager;
        public int propertyid;
        public int count;
        public Boolean AddingRestaurant(vel_restro_restaurent resto)
        {
            List<vel_restro_restaurent> list = new List<vel_restro_restaurent>();
            using (velfoodsEntities1 entity = new velfoodsEntities1())
            {
                list = entity.vel_restro_restaurent.OrderBy(a => a.restaurent_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    restoname = list[i].restaurent_name;
                    restoaddress = list[i].restaurent_address;
                    restomobile = list[i].restaurent_mobile_no;
                    restostatus = list[i].restaruent_status;
                    restomanager = list[i].restrent_manger;
                    if (resto.restaurent_name.Equals(restoname) && resto.restaurent_address.Equals(restoaddress) && resto.restaurent_mobile_no.Equals(restomobile) && resto.restrent_manger.Equals(restomanager) && resto.restaruent_status.Equals(restostatus) && resto.property_id.Equals(propertyid))
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

            using (velfoodsEntities1 en = new velfoodsEntities1())
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
                    using (velfoodsEntities1 entit = new velfoodsEntities1())
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