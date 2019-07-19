using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class MiscollectionClass
    {
        public int miscollection_id;
        public string miscollection_name;
        public string miscollection_pariticular;
        public string miscollection_reportingname;
        public string type_of_payment;
        public string bank_name;
        public string transaction_id;
        public decimal? Amoount;
        public int restaurent_id;
        public int count;
        public Boolean AddingMiscol(vel_restro_miscollection resto)
        {

            List<vel_restro_miscollection> list = new List<vel_restro_miscollection>();
            using (velfoodsEntities1 entity = new velfoodsEntities1())
            {
                list = entity.vel_restro_miscollection.OrderBy(a => a.miscollection_id).ToList();
                int c = list.Count;

                for (int i = 0; i < c; i++)
                {
                    miscollection_name = list[i].miscollection_name;
                    miscollection_pariticular = list[i].miscollection_pariticular;
                    miscollection_reportingname = list[i].miscollection_reportingname;
                    type_of_payment = list[i].type_of_payment;
                    bank_name = list[i].bank_name;
                    Amoount = list[i].Amoount;
                    transaction_id = list[i].transaction_id;
                    restaurent_id = list[i].restaurent_id;

                    if (resto.miscollection_name.Equals(miscollection_name) && resto.miscollection_pariticular.Equals(miscollection_pariticular) && resto.miscollection_reportingname.Equals(miscollection_reportingname) && resto.type_of_payment.Equals(type_of_payment) &&
                        resto.bank_name.Equals(bank_name) && resto.Amoount.Equals(Amoount) && resto.transaction_id.Equals(transaction_id))
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