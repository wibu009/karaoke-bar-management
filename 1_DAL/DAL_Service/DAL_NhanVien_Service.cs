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
    public class DAL_NhanVien_Service : IDAL_NhanVien_Service
    {
        private DatabaseContext _dbContext;
        private List<NhanVien> _lstNhanViens;
        private List<ChucVu> _lstChucVus;
        public DAL_NhanVien_Service()
        {
            _dbContext = new DatabaseContext();
            _lstNhanViens = new List<NhanVien>();
            _lstChucVus = new List<ChucVu>();
            GetlstNhanVien();
        }

        public void GetlstNhanVien()
        {
            _lstNhanViens = _dbContext.NhanViens.ToList();
        }
        public List<NhanVien> GetlstNhanViens()
        {
            return _lstNhanViens = _dbContext.NhanViens.ToList();
        }
        public List<ChucVu> GetlstChucVus()
        {
            return _lstChucVus = _dbContext.ChucVus.ToList();
        }
        public List<NhanVien> FindName(string name)
        {
            return _lstNhanViens.Where(c => c.Ten.ToLower().StartsWith(name.ToLower())).ToList();
        }

        public bool Add(NhanVien nv)
        {
            _dbContext.NhanViens.Add(nv);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Update(NhanVien nv)
        {
            _dbContext.NhanViens.Update(nv);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Remove(NhanVien nv)
        {
            _dbContext.NhanViens.Remove(nv);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Save(NhanVien nv)
        {
            _dbContext.SaveChanges();
            return true;
        }

    }
}
