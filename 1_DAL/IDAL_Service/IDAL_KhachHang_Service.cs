using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_KhachHang_Service
    {
        public List<KhachHang> GetlstKhachHangs();
        public List<KhachHang> FindNameKhachHang(string name);
        public bool Add(KhachHang kh);
        public bool Update(KhachHang kh);
        public bool Remove(KhachHang kh);
        public bool Save(KhachHang kh);

    }
}
