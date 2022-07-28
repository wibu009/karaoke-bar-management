using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DBContext;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;

namespace _1_DAL.DAL_Service
{
    public class DAL_ChiTietHoaDonNhap_Service : IDAL_ChiTietHoaDonNhap_Service
    {
        private DatabaseContext _dB;
        public DAL_ChiTietHoaDonNhap_Service()
        {
            _dB = new DatabaseContext();
        }

        public List<ChiTietHoaDonNhap> GetlistChiTietHoaDonNhapsFromDB()
        {
            return _dB.ChiTietHoaDonNhaps.ToList();
        }

        public bool AddChiTietHoaDonNhap(ChiTietHoaDonNhap cthdn)
        {
            try
            {
                _dB.ChiTietHoaDonNhaps.Add(cthdn);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateChiTietHoaDonNhap(ChiTietHoaDonNhap cthdn)
        {
            try
            {
                _dB.ChiTietHoaDonNhaps.Update(cthdn);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteChiTietHoaDonNhap(ChiTietHoaDonNhap cthdn)
        {
            try
            {
                _dB.ChiTietHoaDonNhaps.Remove(cthdn);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
