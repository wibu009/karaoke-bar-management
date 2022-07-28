using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
   public interface IDAL_MatHang_Service
    {
        public List<MatHang> sendlstMatHang();
        public bool Add(MatHang mh);
        public bool Update(MatHang mh);
        public bool Remove(MatHang mh);
        public bool Save();
        public List<MatHang> FindName(string name);
    }
}
