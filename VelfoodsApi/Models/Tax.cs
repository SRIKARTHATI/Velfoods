using System;
using System.Collections.Generic;
using System.Linq;

namespace VelfoodsApi.Models
{
    public class Tax
    {
        String tax_name;
        int count, tax_percentage, tax_id;
        public Boolean adding(vel_restro_tax restro_Tax)
        {
            List<vel_restro_tax> list = new List<vel_restro_tax>();
            using (velfoodsEntities2 en = new velfoodsEntities2())
            {
                list = en.vel_restro_tax.OrderBy(a => a.tax_id).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    tax_name = list[i].tax_name;
                    tax_percentage = list[i].tax_percentage;
                    if (restro_Tax.tax_name.Equals(tax_name) || restro_Tax.tax_percentage.Equals(tax_percentage))
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
        public Boolean updatetax(vel_restro_tax restro_Tax)
        {
            List<vel_restro_tax> list = new List<vel_restro_tax>();
            using (velfoodsEntities2 enti = new velfoodsEntities2())
            {
                list = enti.vel_restro_tax.OrderBy(a => a.tax_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {
                    tax_id = list[i].tax_id;
                    if (restro_Tax.tax_id.Equals(tax_id))
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
                    using (velfoodsEntities2 en = new velfoodsEntities2())
                    {
                        vel_restro_tax tax = (from a in en.vel_restro_tax
                                               where restro_Tax.tax_id == a.tax_id
                                               select a).FirstOrDefault();
                        tax.tax_name = restro_Tax.tax_name;
                        tax.tax_percentage = restro_Tax.tax_percentage;
                        tax.tax_status = restro_Tax.tax_status;
                        tax.tax_employeename = restro_Tax.tax_employeename;
                        tax.tax_Active_from = restro_Tax.tax_Active_from;
                        en.SaveChanges();
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