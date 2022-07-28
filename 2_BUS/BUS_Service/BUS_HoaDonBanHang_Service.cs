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
    public class BUS_HoaDonBanHang_Service : IBUS_HoaDonBanHang_Service
    {
        private IDAL_HoaDonBanHang_Service _iDAL_HoaDonBanHang_Service;
        public BUS_HoaDonBanHang_Service()
        {
            _iDAL_HoaDonBanHang_Service = new DAL_HoaDonBanHang_Service();
        }
        public bool Add(HoaDonBanHang hoaDonBanHang)
        {
            return _iDAL_HoaDonBanHang_Service.Add(hoaDonBanHang);
        }

        public List<HoaDonBanHang> Find(int id)
        {
            return _iDAL_HoaDonBanHang_Service.Find(id);
        }

        public List<HoaDonBanHang> FindName(string name)
        {
            return _iDAL_HoaDonBanHang_Service.FindName(name);
        }

        public void GetlstHoaDonBanHang()
        {
            _iDAL_HoaDonBanHang_Service.GetlstHoaDonBanHang();
        }

        public bool Remove(int idHoaDon)
        {
            return _iDAL_HoaDonBanHang_Service.Remove(idHoaDon);
        }

        public bool Save()
        {
            return _iDAL_HoaDonBanHang_Service.Save();
        }

        public List<HoaDonBanHang> sendlstHoaDonBanHang()
        {
            return _iDAL_HoaDonBanHang_Service.sendlstHoaDonBanHang();
        }

        public bool Update(HoaDonBanHang hoaDonBanHang)
        {
            return _iDAL_HoaDonBanHang_Service.Update(hoaDonBanHang);
        }
    }
}
