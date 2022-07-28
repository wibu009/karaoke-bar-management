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
   public class DAL_MatHang_Service: IDAL_MatHang_Service
    {
        private DatabaseContext db;
        private List<MatHang> _mathang;
        public DAL_MatHang_Service()
        {
            db = new DatabaseContext();
            _mathang = new List<MatHang>();
            GetlstMatHang();
        }

        private void GetlstMatHang()
        {
            _mathang = db.MatHangs.ToList();
        }
        public List<MatHang> sendlstMatHang()
        {
            return _mathang;
        }
        public bool Add(MatHang mh)
        {
            db.MatHangs.Add(mh);
            _mathang.Add(mh);
            db.SaveChanges();
            return true;
        }

        public List<MatHang> FindName(string name)
        {
            throw new NotImplementedException();
        }



        public bool Remove(MatHang mh)
        {
            db.MatHangs.Remove(mh);
            _mathang.Remove(mh);
            db.SaveChanges();
            return true;
        }

        public bool Save()
        {
            db.SaveChanges();
            return true;
        }

        public bool Update(MatHang mh)
        {
            db.MatHangs.Update(mh);
            _mathang[_mathang.FindIndex(x => x.Id == mh.Id)] = mh;
            db.SaveChanges();
            return true;
        }
    }
}
