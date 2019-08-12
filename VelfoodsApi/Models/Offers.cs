using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class Offers
    {
        String promocode,promoname;
        int count, empid;
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
    }
}