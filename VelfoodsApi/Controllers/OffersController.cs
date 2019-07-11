using System;
using System.Net;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class OffersController : ApiController
    {
        velfoodsEntities1 entity = new velfoodsEntities1();
        Responce re = new Responce();
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
    }
}