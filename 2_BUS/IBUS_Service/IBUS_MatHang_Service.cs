using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_Service
{
   public interface IBUS_MatHang_Service
    {
        public List<MatHang> GetlstMatHangs();
        public bool AddMatHangh(MatHang mh);
        public bool EditMatHang(MatHang mh);
        public bool banhang(int idmathang);
        public bool hoantra(int idmathang);
        public bool RemoveMatHang(MatHang mh);
        public bool SaveMatHang();
    }
}
