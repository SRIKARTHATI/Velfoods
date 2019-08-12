using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class TableBookingClass
    {
        public int table_booking_id;
        public string tablebookingf_name;
        public int tablebooking_pax;
        public long tablebooking_mobile_no;
        public decimal tablebooking_advance;
        public TimeSpan tablebooking_time;
        public string tablebooking_splinstructions;
        public int restaurent_id;
        public int count;
        public DateTime tablebooking_date;

        public Boolean AddTableBooking(vel_restro_tablebooking resto)
        {

            List<vel_restro_tablebooking> list = new List<vel_restro_tablebooking>();
            using (velfoodsEntities2 entity = new velfoodsEntities2())
            {
                list = entity.vel_restro_tablebooking.OrderBy(a => a.table_booking_id).ToList();
                int c = list.Count;

                    for (int i = 0; i < c; i++)
                    {
                        tablebookingf_name = list[i].tablebookingf_name;
                        tablebooking_advance = list[i].tablebooking_advance;
                        tablebooking_mobile_no = list[i].tablebooking_mobile_no;
                        tablebooking_pax = list[i].tablebooking_pax;
                        tablebooking_splinstructions = list[i].tablebooking_splinstructions;
                        tablebooking_time = list[i].tablebooking_time;
                        table_booking_id = list[i].table_booking_id;
                        restaurent_id = list[i].restaurent_id;
                        tablebooking_date = list[i].tablebooking_date;

                        if (resto.tablebookingf_name.Equals(tablebookingf_name) && resto.tablebooking_advance.Equals(tablebooking_advance) && resto.tablebooking_mobile_no.Equals(tablebooking_mobile_no) && resto.tablebooking_pax.Equals(tablebooking_pax) && 
                            resto.tablebooking_splinstructions.Equals(tablebooking_splinstructions) && resto.tablebooking_time.Equals(tablebooking_time) && resto.tablebooking_date.Equals(tablebooking_date))
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
        public Boolean UpdateTableBooking(vel_restro_tablebooking resto)
        {

            List<vel_restro_tablebooking> list = new List<vel_restro_tablebooking>();
            using (velfoodsEntities2 entity = new velfoodsEntities2())
            {
                list = entity.vel_restro_tablebooking.OrderBy(a => a.table_booking_id).ToList();
                int c = list.Count;
                    for (int i = 0; i < c; i++)
                    {
                        tablebookingf_name = list[i].tablebookingf_name;
                        table_booking_id = list[i].table_booking_id;
                        restaurent_id = list[i].restaurent_id;

                        if (resto.tablebookingf_name.Equals(tablebookingf_name) && 
                            resto.table_booking_id.Equals(table_booking_id) && resto.restaurent_id.Equals(restaurent_id))
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
                        vel_restro_tablebooking vp = (from s in entit.vel_restro_tablebooking
                                                  where s.restaurent_id == resto.restaurent_id
                                                  where s.table_booking_id == resto.table_booking_id
                                                  where s.tablebookingf_name == resto.tablebookingf_name
                                                      select s).FirstOrDefault();
                        vp.tablebooking_advance = resto.tablebooking_advance;
                        vp.tablebooking_date = resto.tablebooking_date;
                        vp.tablebooking_mobile_no = resto.tablebooking_mobile_no;
                        vp.tablebooking_pax = resto.tablebooking_pax;
                        vp.tablebooking_splinstructions = resto.tablebooking_splinstructions;
                        vp.tablebooking_time = resto.tablebooking_time;
                        entit.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}