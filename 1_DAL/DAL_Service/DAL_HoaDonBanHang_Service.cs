using _1_DAL.DBContext;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.DAL_Service
{
    public class DAL_HoaDonBanHang_Service : IDAL_HoaDonBanHang_Service
    {
        private DatabaseContext _dbContext;
        private List<HoaDonBanHang> _lsthoaDonBanHangs;
        public DAL_HoaDonBanHang_Service()
        {
            _dbContext = new DatabaseContext();
            _lsthoaDonBanHangs = new List<HoaDonBanHang>();
            _lsthoaDonBanHangs = _dbContext.HoaDonBanHangs.ToList();
        }
        public bool Add(HoaDonBanHang hoaDonBanHang)
        {
            _dbContext.HoaDonBanHangs.Add(hoaDonBanHang);
            _dbContext.SaveChanges();
            GetlstHoaDonBanHang();
            return true;
        }

        public List<HoaDonBanHang> Find(int id)
        {
            if (_lsthoaDonBanHangs.Where(c => c.IdhoaDon == id).FirstOrDefault() == null) return null;
            return _lsthoaDonBanHangs.Where(c => c.IdhoaDon == id).ToList();
        }

        public List<HoaDonBanHang> FindName(string name)
        {
            if (_lsthoaDonBanHangs.Where(c => c.IdmaKh == name).FirstOrDefault() == null) return null;
            return _lsthoaDonBanHangs.Where(c => c.IdmaKh == name).ToList();
        }

        public void GetlstHoaDonBanHang()
        {
            _lsthoaDonBanHangs = _dbContext.HoaDonBanHangs.ToList();
        }

        public bool Remove(int idHoaDon)
        {
            var temp = _lsthoaDonBanHangs.Where(c => c.IdhoaDon == idHoaDon).FirstOrDefault();
            _dbContext.HoaDonBanHangs.Remove(temp);
            _dbContext.SaveChanges();
            GetlstHoaDonBanHang();
            return true;
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }

        public List<HoaDonBanHang> sendlstHoaDonBanHang()
        {
            return _lsthoaDonBanHangs;
        }

        public bool Update(HoaDonBanHang hoaDonBanHang)
        {
            _dbContext.HoaDonBanHangs.Update(hoaDonBanHang);
            _dbContext.SaveChanges();
            GetlstHoaDonBanHang();
            return true;
        }
    }
}
