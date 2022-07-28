using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
   public interface IBUS_NhanVien_Service
    {
        public List<NhanVien> GetlstNhanViens();
        public List<ChucVu> GetlstChucVus();
        public List<NhanVien> FindName(string name);
        public bool Add(NhanVien nv);
        public bool Update(NhanVien nv);
        public bool Remove(NhanVien nv);
        public bool Save(NhanVien nv);
    }
}
