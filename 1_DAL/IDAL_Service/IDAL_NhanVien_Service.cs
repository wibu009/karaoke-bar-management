using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_NhanVien_Service
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
