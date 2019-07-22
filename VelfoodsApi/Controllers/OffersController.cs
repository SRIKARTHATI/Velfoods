using System;
using System.Net;
using System.Linq;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class OffersController : ApiController
    {
        velfoodsEntities1 entity = new velfoodsEntities1();
        Responce re = new Responce();
        int offersCount;
        [HttpPost]
        [Route("OfferAdding")]
        public IHttpActionResult addOffer(vel_restro_offers offers)
        {
            Boolean b = new Offers().adding(offers);
            if (b)
            {
                entity.vel_restro_offers.Add(offers);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Offer added Successfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "Failed to insert Please check the values..!";
                return Content(HttpStatusCode.OK, re);
            }
        }
        [HttpPost]
        [Route("OffersList")]
        public Responce OfferList(vel_restro_offers restro_Offers)
        {
            var offers_list = (from a in entity.vel_restro_offers
                                where restro_Offers.restaurent_id == a.restaurent_id
                                select new
                                {
                                    a.offers_id,
                                    a.promo_code_name,
                                    a.promo_code,
                                    a.percentage,
                                    a.Active_dare_status,
                                    a.from_date,
                                    a.to_date,
                                    a.Active_time_status,
                                    a.from_time,
                                    a.to_time,
                                    a.Day_status,
                                    a.Day_type,
                                    a.Days,
                                    a.minbill_status,
                                    a.minbill_amount,
                                    a.maximum_bill_status,
                                    a.maximum_bill_amount,
                                });
            offersCount = offers_list.AsQueryable().Count();
            if (offersCount.ToString() == "" || offersCount.ToString() == null || offersCount == 0)
            {
                re.Data = offers_list;
                re.code = 100;
                re.message = "No Data found";
            }
            else
            {
                re.Data = offers_list;
                re.code = 200;
                re.message = "Data Successfull";
            }
            return re;
        }
    }
}