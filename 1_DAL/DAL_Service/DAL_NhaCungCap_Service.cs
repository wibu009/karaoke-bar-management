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
    public class DAL_NhaCungCap_Service :IDAL_NhaCungCap_Service
    {
        private DatabaseContext _db;
        private List<NhaCungCap> _lstNhaCungCaps;

        public DAL_NhaCungCap_Service()
        {
            _db = new DatabaseContext();
            _lstNhaCungCaps = new List<NhaCungCap>(GetListNhaCungCapsFromDB());
        }

        public List<NhaCungCap> GetListNhaCungCapsFromDB()
        {
            return _db.NhaCungCaps.ToList();
        }

        public bool AddNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                _db.NhaCungCaps.Add(ncc);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                _db.NhaCungCaps.Update(ncc);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                _db.NhaCungCaps.Remove(ncc);
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
