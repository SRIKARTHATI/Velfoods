using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class Offers
    {
        String promocode,promoname;
        int count, empid, offers_id;
        public Boolean adding(vel_restro_offers offers)
        {
            List<vel_restro_offers> list = new List<vel_restro_offers>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_offers.OrderBy(a => a.offers_id).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    promocode = list[i].promo_code;
                    promoname = list[i].promo_code_name;
                    if (offers.promo_code.Equals(promocode) || offers.promo_code_name.Equals(promoname))
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
        public Boolean update(vel_restro_offers offers)
        {
            List<vel_restro_offers> list = new List<vel_restro_offers>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_offers.OrderBy(a => a.offers_id).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    promocode = list[i].promo_code;
                    promoname = list[i].promo_code_name;
                    offers_id = list[i].offers_id;
                    if (offers.promo_code.Equals(promocode) || offers.promo_code_name.Equals(promoname) || offers.offers_id.Equals(offers_id))
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
                    using (velfoodsEntities2 ent = new velfoodsEntities2())
                    {
                        vel_restro_offers off = (from c in ent.vel_restro_offers
                                                            where c.offers_id == offers.offers_id
                                                            where c.restaurent_id == offers.restaurent_id
                                                            where c.promo_code == offers.promo_code
                                                            select c).FirstOrDefault();
                        off.promo_code_description = offers.promo_code_description;
                        off.promo_code_name = offers.promo_code_name;
                        off.Active_dare_status = offers.Active_dare_status;
                        off.from_date = offers.from_date;
                        off.to_date = offers.to_date;
                        off.Active_time_status = offers.Active_time_status;
                        off.from_time = offers.from_time;
                        off.to_time = offers.to_time;
                        off.percentage = offers.percentage;
                        off.Day_status = offers.Day_status;
                        off.Day_type = offers.Day_type;
                        off.Days = offers.Days;
                        off.minbill_status = offers.minbill_status;
                        off.minbill_amount = offers.minbill_amount;
                        off.maximum_bill_status = offers.maximum_bill_status;
                        off.maximum_bill_amount = offers.maximum_bill_amount;
                        off.offers_status = offers.offers_status;
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