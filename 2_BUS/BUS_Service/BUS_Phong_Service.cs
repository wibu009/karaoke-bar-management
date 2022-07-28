using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.BUS_Service
{
   public class BUS_Phong_Service: IBUS_Phong_Service
    {
        private IDAL_Phong_Service _iDAL_Phong_Service;
        public BUS_Phong_Service()
        {
            _iDAL_Phong_Service = new DAL_Phong_Service();
        }
        public bool Add(Phong Phong)
        {
            return _iDAL_Phong_Service.Add(Phong);
        }

        public List<Phong> Find(int id)
        {
            return _iDAL_Phong_Service.Find(id);
        }

        public List<Phong> FindName(string name)
        {
            return _iDAL_Phong_Service.FindName(name);
        }

        public void GetlstPhong()
        {
            _iDAL_Phong_Service.GetlstPhong();
        }

        public bool Remove(int idphong)
        {
            return _iDAL_Phong_Service.Remove(idphong);
        }

        public bool Save()
        {
            return _iDAL_Phong_Service.Save();
        }

        public List<Phong> sendlstPhong()
        {
            return _iDAL_Phong_Service.sendlstPhong();
        }

        public bool Update(Phong Phong)
        {
            return _iDAL_Phong_Service.Update(Phong);
        }
    }
}
