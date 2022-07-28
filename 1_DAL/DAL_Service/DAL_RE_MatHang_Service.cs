using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DBContext;
using _1_DAL.Entities;

namespace _1_DAL.DAL_Service
{
    public class DAL_RE_MatHang_Service : IDAL_RE_MatHang_Service
    {
        private DatabaseContext _dB;

        public DAL_RE_MatHang_Service()
        {
            _dB = new DatabaseContext();
        }

        public List<MatHang> GetListMatHangFromDB()
        {
            return _dB.MatHangs.ToList();
        }

        public bool AddMatHangToDB(MatHang mh)
        {
            try
            {
                _dB.MatHangs.Add(mh);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
                return false;
            }
        }

        public bool UpdateMatHangToDB(MatHang mh)
        {
            try
            {
                _dB.MatHangs.Update(mh);
                _dB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteMatHangToDB(MatHang mh)
        {
            try
            {
                _dB.MatHangs.Remove(mh);
                _dB.SaveChanges();
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
