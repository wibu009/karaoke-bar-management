using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DBContext;

namespace _1_DAL.DAL_Service
{
    public class DAL_ThietBi_Service : IDAL_ThietBi_Service
    {
        private DatabaseContext db;
        private List<ThietBi> _thietbi;
        public DAL_ThietBi_Service()
        {
            db = new DatabaseContext();
            _thietbi = new List<ThietBi>();
            GetlstThietBi();
        }

        private void GetlstThietBi()
        {
            _thietbi = db.ThietBis.ToList();
        }
        public List<ThietBi> sendlstThietBi()
        {
            return _thietbi;
        }
        public bool Add(ThietBi tb)
        {
            db.ThietBis.Add(tb);
            _thietbi.Add(tb);
            return true;
        }

        public List<ThietBi> FindName(string name)
        {
            throw new NotImplementedException();
        }
        public bool Remove(ThietBi tb)
        {
            db.ThietBis.Remove(tb);
            _thietbi.Remove(tb);
            return true;
        }

        public bool Save()
        {
            db.SaveChanges();
            return true;
        }

        public bool Update(ThietBi tb)
        {
            db.ThietBis.Update(tb);
            _thietbi[_thietbi.FindIndex(x => x.IdmaLoaiTb == tb.IdmaLoaiTb)] = tb;
            return true;
        }
    }
}
