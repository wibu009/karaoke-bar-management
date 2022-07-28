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
    public class DAL_LoaiThietBi_Service : IDAL_LoaiThietBi_Service
    {
        private DatabaseContext db;
        private List<LoaiThietBi> _thietbi;
        public DAL_LoaiThietBi_Service()
        {
            db = new DatabaseContext();
            _thietbi = new List<LoaiThietBi>();
            GetlstThietBi();
        }

        private void GetlstThietBi()
        {
            _thietbi = db.LoaiThietBis.ToList();
        }
        public List<LoaiThietBi> sendlstLoaiThietBi()
        {
            return _thietbi;
        }
        public bool Add(LoaiThietBi ltb)
        {
            db.LoaiThietBis.Add(ltb);
            _thietbi.Add(ltb);
            return true;
        }

        public List<LoaiThietBi> FindName(string name)
        {
            throw new NotImplementedException();
        }
        public bool Remove(LoaiThietBi ltb)
        {
            db.LoaiThietBis.Remove(ltb);
            _thietbi.Remove(ltb);
            return true;
        }

        public bool Save()
        {
            db.SaveChanges();
            return true;
        }

        public bool Update(LoaiThietBi ltb)
        {
            db.LoaiThietBis.Update(ltb);
            _thietbi[_thietbi.FindIndex(x => x.IdtranngThai == ltb.IdtranngThai)] = ltb;
            return true;
        }
    }
}
