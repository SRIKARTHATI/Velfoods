using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class PropertyAdding
    {
        public int prptid;
        public string property_name;
        public long property_mobile_no;
        public string property_address;
        public string property_land_mark;
        public long? property_landline;
        public string property_city; public string property_email; public string property_state; public string property_website;
        public int property_pincode; public string property_gst; public string property_country;
        public int count;
        public Boolean AddingProperty(vel_restro_property resto)
        {

            List<vel_restro_property> list = new List<vel_restro_property>();
            using (velfoodsEntities1 entity = new velfoodsEntities1())
            {
                list = entity.vel_restro_property.OrderBy(a => a.property_id).ToList();
                int c = list.Count;
                if (c < 1)
                {
                    
                    for (int i = 0; i < c; i++)
                    {
                        property_name = list[i].property_name;
                        property_address = list[i].property_address;
                        property_mobile_no = list[i].property_mobile_no;
                        property_land_mark = list[i].property_land_mark;
                        property_landline = list[i].property_landline;
                        property_city = list[i].property_city;
                        property_email = list[i].property_email;
                        property_state = list[i].property_state;
                        property_website = list[i].property_website;
                        property_pincode = list[i].property_pincode;
                        property_gst = list[i].property_gst;
                        property_country = list[i].property_country;
                        if (resto.property_name.Equals(property_name) && resto.property_address.Equals(property_address) && resto.property_mobile_no.Equals(property_mobile_no) && resto.property_land_mark.Equals(property_land_mark) && resto.property_landline.Equals(property_landline) && resto.property_city.Equals(property_city) &&
                            resto.property_email.Equals(property_email) && resto.property_state.Equals(property_state) && resto.property_website.Equals(property_website) && resto.property_pincode.Equals(property_pincode) &&
                            resto.property_gst.Equals(property_gst) && resto.property_country.Equals(property_country))
                        {
                            count = 1;
                            break;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
                else
                {
                    return false;
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
        public Boolean update(vel_restro_property vrprpt)
        {
            List<vel_restro_property> list = new List<vel_restro_property>();
            using (velfoodsEntities1 entity = new velfoodsEntities1())
            {
                list = entity.vel_restro_property.OrderBy(a => a.property_id).ToList();
                int c = list.Count;
                for (int i = 0; i < c; i++)
                {

                    property_mobile_no = list[i].property_mobile_no;
                    prptid = list[i].property_id;
                    if (vrprpt.property_mobile_no.Equals(property_mobile_no) && vrprpt.property_id.Equals(prptid))
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
                    using (velfoodsEntities1 entit = new velfoodsEntities1())
                    {
                        vel_restro_property vp = (from s in entit.vel_restro_property
                                                  where s.property_id == vrprpt.property_id
                                                  select s).FirstOrDefault();
                        vp.property_country = vrprpt.property_country;
                        vp.property_name = vrprpt.property_name;
                        vp.property_address = vrprpt.property_address;
                        vp.property_land_mark = vrprpt.property_land_mark;
                        vp.property_landline = vrprpt.property_landline;
                        vp.property_city = vrprpt.property_city;
                        vp.property_email = vrprpt.property_email;
                        vp.property_state = vrprpt.property_state;
                        vp.property_website = vrprpt.property_website;
                        vp.property_pincode = vrprpt.property_pincode;
                        vp.property_gst = vrprpt.property_gst;
                        vp.property_mobile_no = vrprpt.property_mobile_no;
                        entit.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}