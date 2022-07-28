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
    public class DAL_ChiTietHoaDonBan_Service : IDAL_ChiTietHoaDonBan_Service
    {
        private DatabaseContext _dbContext;
        private List<ChiTietHoaDonBan> _lstchiTietHoaDonBans;
        public DAL_ChiTietHoaDonBan_Service()
        {
            _dbContext = new DatabaseContext();
            _lstchiTietHoaDonBans = new List<ChiTietHoaDonBan>();
            _lstchiTietHoaDonBans = _dbContext.ChiTietHoaDonBans.ToList();
        }
        public bool Add(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            _dbContext.ChiTietHoaDonBans.Add(chiTietHoaDonBan);
            _dbContext.SaveChanges();
            GetlstChiTietHoaDonBan();
            return true;
        }

        public List<ChiTietHoaDonBan> Find(int id)
        {
            if (_lstchiTietHoaDonBans.Where(c => c.IdhoaDon == id).FirstOrDefault() == null) return null;
            return _lstchiTietHoaDonBans.Where(c => c.IdhoaDon == id).ToList();
        }

        public List<ChiTietHoaDonBan> FindName(int name)//tìm kiếm qua mã mặt hàng
        {
            if (_lstchiTietHoaDonBans.Where(c => c.IdmatHang == name).FirstOrDefault() == null) return null;
            return _lstchiTietHoaDonBans.Where(c => c.IdhoaDon == name).ToList();
        }

        public void GetlstChiTietHoaDonBan()
        {
            _lstchiTietHoaDonBans = _dbContext.ChiTietHoaDonBans.ToList();
        }

        public bool Remove(int idctHD)
        {
            var temp = _lstchiTietHoaDonBans.Where(c => c.IdchiTietHoaDonBan == idctHD).FirstOrDefault();
            _dbContext.ChiTietHoaDonBans.Remove(temp);
            _dbContext.SaveChanges();
            GetlstChiTietHoaDonBan();
            return true;
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }

        public List<ChiTietHoaDonBan> sendlstChiTietHoaDonBan()
        {
            return _lstchiTietHoaDonBans;
        }

        public bool Update(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            _dbContext.ChiTietHoaDonBans.Update(chiTietHoaDonBan);
            _dbContext.SaveChanges();
            GetlstChiTietHoaDonBan();
            return true;
        }
    }
}
