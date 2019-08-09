using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VelfoodsApi.Models
{
    public class ManagerClass
    {
        public int manger_id;
        public string manger_name;
        public long? manger_mobile_no;
        public long? manger_contact_no;
        public string manger_id_proof;
        public string manger_id_no;
        public string manger_status;
        public int restaurent_id;
        public int count;

        public Boolean AddingManager(vel_restro_manger mngr)
        {
            List<vel_restro_manger> list = new List<vel_restro_manger>();
            using (velfoodsEntities2 entity = new velfoodsEntities2())
            {
                list = entity.vel_restro_manger.OrderBy(a => a.manger_id).ToList();
                int c = list.Count;

                for (int i = 0; i < c; i++)
                {
                    manger_name = list[i].manger_name;
                    restaurent_id = list[i].restaurent_id;
                    manger_mobile_no = list[i].manger_mobile_no;
                    manger_contact_no = list[i].manger_contact_no;
                    manger_id_proof = list[i].manger_id_proof;
                    manger_id_no = list[i].manger_id_no;
                    manger_status = list[i].manger_status;

                    if (mngr.manger_name.Equals(manger_name) && mngr.manger_mobile_no.Equals(manger_mobile_no) && mngr.manger_contact_no.Equals(manger_contact_no) && mngr.manger_id_proof.Equals(manger_id_proof) && mngr.restaurent_id.Equals(restaurent_id))
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

        public Boolean UpdatingManager(vel_restro_manger mngr)
        {
            List<vel_restro_manger> list = new List<vel_restro_manger>();
            using (velfoodsEntities2 entity = new velfoodsEntities2())
            {
                list = entity.vel_restro_manger.OrderBy(a => a.manger_id).ToList();
                int c = list.Count;

                for (int i = 0; i < c; i++)
                {
                    manger_name = list[i].manger_name;
                    restaurent_id = list[i].restaurent_id;
                    manger_mobile_no = list[i].manger_mobile_no;
                    manger_contact_no = list[i].manger_contact_no;
                    manger_id_proof = list[i].manger_id_proof;
                    manger_id_no = list[i].manger_id_no;
                    manger_status = list[i].manger_status;

                    if (mngr.manger_name.Equals(manger_name) && mngr.manger_mobile_no.Equals(manger_mobile_no) && mngr.manger_contact_no.Equals(manger_contact_no) && mngr.manger_id_proof.Equals(manger_id_proof) && mngr.restaurent_id.Equals(restaurent_id))
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
                        vel_restro_manger vp = (from s in entit.vel_restro_manger
                                                where s.restaurent_id == mngr.restaurent_id
                                                where s.manger_id == mngr.manger_id
                                                select s).FirstOrDefault();
                        vp.manger_name = mngr.manger_name;
                        vp.manger_mobile_no = mngr.manger_mobile_no;
                        vp.manger_contact_no = mngr.manger_contact_no;
                        vp.manger_id_proof = mngr.manger_id_proof;
                        vp.manger_id_no = mngr.manger_id_no;
                        vp.manger_status = mngr.manger_status;
                        entit.SaveChanges();
                    }
                    return true;
                }
            }
        }
    }
}