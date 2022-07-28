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
    public class DAL_CongThucTinh_Service :IDAL_CongThucTinh_Service
    {
        private DatabaseContext _db;
        private List<CongThucTinh> _lsCongThucTinhs;

        public DAL_CongThucTinh_Service()
        {
            _db = new DatabaseContext();
            _lsCongThucTinhs = new List<CongThucTinh>(GetListCongThucTinhsFromDB());
        }

        public List<CongThucTinh> GetListCongThucTinhsFromDB()
        {
            return _db.CongThucTinhs.ToList();
        }

        public bool AddCongThucTinh(CongThucTinh ctt)
        {
            try
            {
                _db.CongThucTinhs.Add(ctt);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateCongThucTinh(CongThucTinh ctt)
        {
            try
            {
                _db.CongThucTinhs.Update(ctt);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteCongThucTinh(CongThucTinh ctt)
        {
            try
            {
                _db.CongThucTinhs.Remove(ctt);
                _db.SaveChanges();
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
