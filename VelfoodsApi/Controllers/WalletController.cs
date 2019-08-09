using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class WalletController : ApiController
    {
        velfoodsEntities2 ve = new velfoodsEntities2();
        Responce re = new Responce();
        [HttpPost]
        [Route("getwallets")]
        public Responce getwallets(vel_restro_wallet tbl)
        {
            var ee = (from s in ve.vel_restro_wallet
                      where s.restaurent_id == tbl.restaurent_id
                      select new
                      {
                          s.wallet_id,
                          s.wallet_code,
                          s.wallet_name,
                          s.wallet_reporting_name,
                          s.status,
                      });

            re.Data = ee;
            re.message = "getting details successfully";
            re.code = 200;
            return re;
        }

        [HttpPost]
        [Route("walletadding")]
        public IHttpActionResult AddingWallet(vel_restro_wallet tbl)
        {
            Boolean b = new WalletClass().walletadd(tbl);
            if (b)
            {
                tbl.BACKGROUND_COLOR = "Green";
                ve.vel_restro_tabledefination.Add(tbl);
                ve.SaveChanges();
                re.code = 200;
                re.message = "data inserted succesfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "failed to insert data";
                return Content(HttpStatusCode.OK, re);
            }
        }

        [HttpPost]
        [Route("walletupdate")]
        public IHttpActionResult Updatewallet(vel_restro_wallet tbl)
        {
            Boolean b = new WalletClass().walletupdate(tbl);
            if (b)
            {
                re.code = 200;
                re.message = "data Updated succesfully";
                return Content(HttpStatusCode.OK, re);
            }
            else
            {
                re.code = 100;
                re.message = "failed to update data";
                return Content(HttpStatusCode.OK, re);
            }
        }
    }
}
