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
    public class BUS_LoaiPhong_Service : IBUS_LoaiPhong_Service
    {
        private IDAL_LoaiPhong_Service _iDAL_LoaiPhong_Service;
        public BUS_LoaiPhong_Service()
        {
            _iDAL_LoaiPhong_Service = new DAL_LoaiPhong_Service();
        }
        public bool Add(LoaiPhong loaiPhong)
        {
            return _iDAL_LoaiPhong_Service.Add(loaiPhong);
        }

        public List<LoaiPhong> Find(int id)
        {
            return _iDAL_LoaiPhong_Service.Find(id);
        }

        public List<LoaiPhong> FindName(string name)
        {
            return _iDAL_LoaiPhong_Service.FindName(name);
        }

        public void GetlstLoaiPhong()
        {
            _iDAL_LoaiPhong_Service.GetHashCode();
        }

        public bool Remove(int loaiPhong)
        {
            return _iDAL_LoaiPhong_Service.Remove(loaiPhong);
        }

        public bool Save()
        {
            return _iDAL_LoaiPhong_Service.Save();
        }

        public List<LoaiPhong> sendlstLoaiPhong()
        {
            return _iDAL_LoaiPhong_Service.sendlstLoaiPhong();
        }

        public bool Update(LoaiPhong loaiPhong)
        {
            return _iDAL_LoaiPhong_Service.Update(loaiPhong);
        }
    }
}
