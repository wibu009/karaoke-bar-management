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
    public class DAL_KhachHang_Service : IDAL_KhachHang_Service
    {
        private List<KhachHang> _lstKhachHangs;
        private DatabaseContext _dbContext;

        public DAL_KhachHang_Service()
        {
            _lstKhachHangs = new List<KhachHang>();
            _dbContext = new DatabaseContext();
            GetlstKhachHang();
        }
        public void GetlstKhachHang()
        {
            _lstKhachHangs = _dbContext.KhachHangs.ToList();
        }
        public List<KhachHang> GetlstKhachHangs()
        {
            return _lstKhachHangs = _dbContext.KhachHangs.ToList();
        }

        public List<KhachHang> FindNameKhachHang(string name)
        {
            return _lstKhachHangs.Where(c => c.Ten.ToLower().StartsWith(name.ToLower())).ToList();
        }

        public bool Add(KhachHang kh)
        {
            _dbContext.KhachHangs.Add(kh);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Update(KhachHang kh)
        {
            _dbContext.KhachHangs.Update(kh);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Remove(KhachHang kh)
        {
            _dbContext.KhachHangs.Remove(kh);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Save(KhachHang kh)
        {
            _dbContext.SaveChanges();
            return true;
        }

    }
}
