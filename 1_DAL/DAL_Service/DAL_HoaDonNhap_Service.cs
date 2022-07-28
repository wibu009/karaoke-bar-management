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
    public class DAL_HoaDonNhap_Service : IDAL_HoaDonNhap_Service
    {
        private DatabaseContext _dB;
        public DAL_HoaDonNhap_Service()
        {
            _dB = new DatabaseContext();
        }

        public List<HoaDonNhap> GetListHoaDonNhapsFromDB()
        {
            return _dB.HoaDonNhaps.ToList();
        }

        public bool AddHoaDonNhap(HoaDonNhap hdn)
        {
            try
            {
                _dB.HoaDonNhaps.Add(hdn);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateHoaDonNhap(HoaDonNhap hdn)
        {
            try
            {
                _dB.HoaDonNhaps.Update(hdn);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteHoaDonNhap(HoaDonNhap hdn)
        {
            try
            {
                _dB.HoaDonNhaps.Remove(hdn);
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
