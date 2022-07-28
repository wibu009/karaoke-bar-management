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
    public class DAL_Tang_Service : IDAL_Tang_Service
    {
        private DatabaseContext _dbContext;
        private List<Tang> _lstTang;
        public DAL_Tang_Service()
        {
            _dbContext = new DatabaseContext();
            _lstTang = new List<Tang>();
            _lstTang = _dbContext.Tangs.ToList();
        }
        public bool Add(Tang Tang)
        {
            _dbContext.Tangs.Add(Tang);
            _dbContext.SaveChanges();
            GetlstTang();
            return true;
        }

        public List<Tang> Find(int id)
        {
            if (_lstTang.Where(c => c.Idtang == id).FirstOrDefault() == null) return null;
            return _lstTang.Where(c => c.Idtang == id).ToList();
        }

        public List<Tang> FindName(string name)
        {
            if (_lstTang.Where(c => c.TenTang == name).FirstOrDefault() == null) return null;
            return _lstTang.Where(c => c.TenTang == name).ToList();
        }

        public void GetlstTang()
        {
            _lstTang = _dbContext.Tangs.ToList();
        }

        public bool Remove(int idTang)
        {
            var temp = _lstTang.Where(c => c.Idtang == idTang).FirstOrDefault();
            _dbContext.Tangs.Remove(temp);
            _dbContext.SaveChanges();
            GetlstTang();
            return true;
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }

        public List<Tang> sendlstTang()
        {
            return _lstTang;
        }

        public bool Update(Tang Tang)
        {
            _dbContext.Tangs.Update(Tang);
            _dbContext.SaveChanges();
            GetlstTang();
            return true;
        }
    }
}
