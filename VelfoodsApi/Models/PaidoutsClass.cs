using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class PaidoutsClass
    {
        public int paidout_id;
        public string paidout_name;
        public string paidout_particular;
        public string paidout_reportingname;
        public string type_of_payment;
        public string bank_name;
        public string transaction_id;
        public decimal? Amoount;
        public int restaurent_id;
        public int count;

        public Boolean AddingPaidouts(vel_restro_paidouts resto)
        {

            List<vel_restro_paidouts> list = new List<vel_restro_paidouts>();
            using (velfoodsEntities2 entity = new velfoodsEntities2())
            {
                list = entity.vel_restro_paidouts.OrderBy(a => a.paidout_id).ToList();
                int c = list.Count;

                for (int i = 0; i < c; i++)
                {
                    paidout_name = list[i].paidout_name;
                    paidout_particular = list[i].paidout_pariticular;
                    paidout_reportingname = list[i].paidout_reportingname;
                    type_of_payment = list[i].type_of_payment;
                    bank_name = list[i].bank_name;
                    Amoount = list[i].Amoount;
                    transaction_id = list[i].transaction_id;
                    restaurent_id = list[i].restaurent_id;

                    if (resto.paidout_name.Equals(paidout_name) && resto.paidout_pariticular.Equals(paidout_particular) && resto.paidout_reportingname.Equals(paidout_reportingname) && resto.type_of_payment.Equals(type_of_payment) &&
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
            public Boolean UpdatePaidouts(vel_restro_paidouts resto)
            {

                List<vel_restro_paidouts> list = new List<vel_restro_paidouts>();
                using (velfoodsEntities2 entity = new velfoodsEntities2())
                {
                    list = entity.vel_restro_paidouts.OrderBy(a => a.paidout_id).ToList();
                    int c = list.Count;
                    for (int i = 0; i < c; i++)
                    {
                        paidout_id = list[i].paidout_id;
                        restaurent_id = list[i].restaurent_id;

                        if (resto.paidout_id.Equals(paidout_id) && resto.restaurent_id.Equals(restaurent_id))
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
                            vel_restro_paidouts vp = (from s in entit.vel_restro_paidouts
                                                          where s.paidout_id == resto.paidout_id
                                                          where s.restaurent_id == resto.restaurent_id
                                                          select s).FirstOrDefault();
                            vp.paidout_name = resto.paidout_name;
                            vp.paidout_pariticular = resto.paidout_pariticular;
                            vp.paidout_reportingname = resto.paidout_reportingname;
                            vp.transaction_id = resto.transaction_id;
                            vp.type_of_payment = resto.type_of_payment;
                            vp.Amoount = resto.Amoount;
                            vp.bank_name = resto.bank_name;
                            entit.SaveChanges();
                        }
                        return true;
                    }
                }
            }
    }
}