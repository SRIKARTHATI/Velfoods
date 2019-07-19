using System;
using System.Net;
using System.Linq;
using System.Web.Http;
using VelfoodsApi.Models;

namespace VelfoodsApi.Controllers
{
    public class TaxController : ApiController
    {
        velfoodsEntities1 entity = new velfoodsEntities1();
        Responce re = new Responce();
        int taxcount;
        [HttpPost]
        [Route("TaxAdding")]
        public IHttpActionResult AddTax(vel_restro_tax restro_Tax)
        {
            Boolean b = new Tax().adding(restro_Tax);
            if (b)
            {
                entity.vel_restro_tax.Add(restro_Tax);
                entity.SaveChanges();
                re.code = 200;
                re.message = "Tax added Successfully";
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
        [Route("TaxList")]
        public Responce GetTax(vel_restro_tax restro_Tax)
        {
            var tax_list = (from a in entity.vel_restro_tax
                               where restro_Tax.restaurent_id == a.restaurent_id
                               select new
                               {
                                   a.tax_id,
                                   a.tax_name,
                                   a.tax_percentage,
                                   a.tax_status,
                                   a.tax_Active_from,
                                   a.tax_employeename
                               });
            taxcount = tax_list.AsQueryable().Count();
            if (taxcount.ToString() == "" || taxcount.ToString() == null || taxcount == 0)
            { 
                re.Data = tax_list;
                re.code = 100;
                re.message = "No Data found";
            }
            else
            {
                re.Data = tax_list;
                re.code = 200;
                re.message = "Data Successfull";
            }
            return re;
        }

        [HttpPost]
        [Route("TaxUpdate")]
        public IHttpActionResult UpdateTax(vel_restro_tax restro_Tax)
        {
            Boolean b = new Tax().updatetax(restro_Tax);
            if (b)
            {
                re.code = 200;
                re.message = "Tax Updated Successfully";
            }
            else
            {
                re.code = 100;
                re.message = "Failed to update Please check the values..!";
            }
            return Content(HttpStatusCode.OK, re);
        }
    }
}