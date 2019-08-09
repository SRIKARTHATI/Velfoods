using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class bankdetailsClass
    {
        string bankcode, bankname;
        int resid,bankid,count;

        public Boolean adding(vel_restro_banks bank)
        {
            List<vel_restro_banks> list = new List<vel_restro_banks>();
            using (velfoodsEntities2 en =new velfoodsEntities2())
            {
                list = en.vel_restro_banks.OrderBy(a => a.bank_id).ToList();
                int co = list.Count;
                for(int i =0; i<co; i++)
                {
                    bankcode = list[i].bank_code;
                    bankname = list[i].bank_name;
                    resid = list[i].restaurent_id;
                    if (bankcode.Equals(bank.bank_code) && bankname.Equals(bank.bank_name) && resid.Equals(bank.restaurent_id))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if(count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Boolean update(vel_restro_banks bank)
        {
            List<vel_restro_banks> list = new List<vel_restro_banks>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_banks.OrderBy(a => a.bank_id).ToList();
                int co = list.Count;
                for (int i = 0; i < co; i++)
                {
                    bankcode = list[i].bank_code;
                    bankname = list[i].bank_name;
                    resid = list[i].restaurent_id;
                    if (bankcode.Equals(bank.bank_code)  && resid.Equals(bank.restaurent_id))
                    {
                        count = 0;
                        break;
                    }
                    else
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    using (velfoodsEntities2 ent =new velfoodsEntities2())
                    {
                        vel_restro_banks banks = (from c in ent.vel_restro_banks
                                                  where bank.bank_code == c.bank_code
                                                  where bank.restaurent_id == c.restaurent_id
                                                  select c).FirstOrDefault();
                        banks.bank_code = bank.bank_code;
                        banks.bank_name = bank.bank_name;
                        banks.bank_account_no = bank.bank_account_no;
                        banks.bank_status = bank.bank_status;
                        banks.bank_reporting_name = bank.bank_reporting_name;
                        banks.empregistration_id = bank.empregistration_id;
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