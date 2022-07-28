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
   public class DAL_Phong_Service: IDAL_Phong_Service
    {
        private DatabaseContext _dbContext;
        private List<Phong> _lstPhong;
        public DAL_Phong_Service()
        {
            _dbContext = new DatabaseContext();
            _lstPhong = new List<Phong>();
            _lstPhong = _dbContext.Phongs.ToList();

        }
        public bool Add(Phong Phong)
        {
            _dbContext.Phongs.Add(Phong);
            _dbContext.SaveChanges();
            GetlstPhong();
            return true;
        }

        public List<Phong> Find(int id)
        {
            if (_lstPhong.Where(c => c.Id == id).FirstOrDefault() == null) return null;
            return _lstPhong.Where(c => c.Id == id).ToList();
        }

        public List<Phong> FindName(string name)
        {
            if (_lstPhong.Where(c => c.TenPhong == name).FirstOrDefault() == null) return null;
            return _lstPhong.Where(c => c.TenPhong == name).ToList();
        }

        public void GetlstPhong()
        {
            _lstPhong = _dbContext.Phongs.ToList();
        }

        public bool Remove(int idphong)
        {
            var temp = _lstPhong.Where(c => c.Id == idphong).FirstOrDefault();
            _dbContext.Phongs.Remove(temp);
            _dbContext.SaveChanges();
            GetlstPhong();
            return true;
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }

        public List<Phong> sendlstPhong()
        {
            return _lstPhong;
        }

        public bool Update(Phong Phong)
        {
            _dbContext.Phongs.Update(Phong);
            _dbContext.SaveChanges();
            GetlstPhong();
            return true;
        }
    }
}
