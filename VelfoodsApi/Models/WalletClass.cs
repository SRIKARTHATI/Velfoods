using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class WalletClass
    {
        public string wallet_code;
        public string wallet_name;
        public string wallet_reporting_name;
        public string wallet_status;
        public int restaurent_id;
        public int count;
        public int empregistration_id;
        public Boolean walletadd(vel_restro_wallet veltbl)
        {
            List<vel_restro_wallet> list = new List<vel_restro_wallet>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_wallet.OrderBy(a => a.wallet_id).ToList();
                int c = list.Count;
                veltbl.restaurent_id = 1;
                for (int i = 0; i < c; i++)
                {
                    wallet_name = list[i].wallet_name;
                    wallet_reporting_name = list[i].wallet_reporting_name;
                    wallet_code = list[i].wallet_code;
                    wallet_status = list[i].wallet_status;
                    restaurent_id = list[i].restaurent_id;
                    if (veltbl.wallet_name.Equals(wallet_name)  && veltbl.wallet_code.Equals(wallet_code))
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
        public Boolean walletupdate(vel_restro_wallet tbl)
        {
            List<vel_restro_wallet> list = new List<vel_restro_wallet>();

            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_wallet.OrderBy(a => a.wallet_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    wallet_name = list[i].wallet_name;
                    wallet_code = list[i].wallet_code;
                    restaurent_id = list[i].restaurent_id;
                    if (tbl.wallet_code.Equals(wallet_code) && tbl.restaurent_id.Equals(restaurent_id))
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
                        vel_restro_wallet vp = (from s in entit.vel_restro_wallet
                                                         where s.wallet_id == tbl.wallet_id
                                                         where s.restaurent_id == tbl.restaurent_id
                                                         select s).FirstOrDefault();
                        vp.wallet_code = tbl.wallet_code;
                        vp.wallet_name = tbl.wallet_name;
                        vp.wallet_reporting_name = tbl.wallet_reporting_name;
                        vp.wallet_status = tbl.wallet_status;
                        vp.empregistration_id = tbl.empregistration_id;
                        entit.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}