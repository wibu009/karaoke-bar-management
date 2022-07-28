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
    public class DAL_LoaiPhong_Service : IDAL_LoaiPhong_Service
    {
        private DatabaseContext _dbContext;
        private List<LoaiPhong> _lstLoaiPhong;
        public DAL_LoaiPhong_Service()
        {
            _dbContext = new DatabaseContext();
            _lstLoaiPhong = new List<LoaiPhong>();
            _lstLoaiPhong = _dbContext.LoaiPhongs.ToList();
        }
        public bool Add(LoaiPhong loaiPhong)
        {
            _dbContext.LoaiPhongs.Add(loaiPhong);
            _dbContext.SaveChanges();
            GetlstLoaiPhong();
            return true;
        }

        public List<LoaiPhong> Find(int id)
        {
            if (_lstLoaiPhong.Where(c => c.Id == id).FirstOrDefault() == null) return null;
            return _lstLoaiPhong.Where(c => c.Id == id).ToList();
        }

        public List<LoaiPhong> FindName(string name)
        {
            if (_lstLoaiPhong.Where(c => c.TenLoaiPhong == name).FirstOrDefault() == null) return null;
            return _lstLoaiPhong.Where(c => c.TenLoaiPhong == name).ToList();
        }

        public void GetlstLoaiPhong()
        {
            _lstLoaiPhong = _dbContext.LoaiPhongs.ToList();
        }

        public bool Remove(int idloaiPhong)
        {
            var temp = _lstLoaiPhong.Where(c => c.Id == idloaiPhong).FirstOrDefault();
            _dbContext.LoaiPhongs.Remove(temp);
            _dbContext.SaveChanges();
            GetlstLoaiPhong();
            return true;
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }

        public List<LoaiPhong> sendlstLoaiPhong()
        {
            return _lstLoaiPhong;
        }

        public bool Update(LoaiPhong loaiPhong)
        {
            _dbContext.LoaiPhongs.Update(loaiPhong);
            _dbContext.SaveChanges();
            GetlstLoaiPhong();
            return true;
        }
    }
}
