using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_Service;

namespace _2_BUS.BUS_Service
{
    public class BUS_KhachHang_Service : IBUS_KhachHang_Service
    {
        private IDAL_KhachHang_Service _ibusKhachHang;
        public BUS_KhachHang_Service()
        {
            _ibusKhachHang = new DAL_KhachHang_Service();
        }
        public List<KhachHang> GetlstKhachHangs()
        {
            return _ibusKhachHang.GetlstKhachHangs();
        }

        public List<KhachHang> FindNameKhachHang(string name)
        {
            return _ibusKhachHang.FindNameKhachHang(name);
        }

        public bool Add(KhachHang kh)
        {
            return _ibusKhachHang.Add(kh);
        }

        public bool Update(KhachHang kh)
        {
            return _ibusKhachHang.Update(kh);
        }
        public bool Remove(KhachHang kh)
        {
            return _ibusKhachHang.Remove(kh);
        }

        public bool Save(KhachHang kh)
        {
            return _ibusKhachHang.Save(kh);
        }
    }
}
