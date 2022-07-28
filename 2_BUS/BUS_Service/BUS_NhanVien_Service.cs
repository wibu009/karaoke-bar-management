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
    public class BUS_NhanVien_Service : IBUS_NhanVien_Service
    {
        private IDAL_NhanVien_Service _idalNhanVienService;
        public BUS_NhanVien_Service()
        {
            _idalNhanVienService = new DAL_NhanVien_Service();
        }
        public List<NhanVien> FindName(string name)
        {
            return _idalNhanVienService.FindName(name);
        }

        public List<NhanVien> GetlstNhanViens()
        {
            return _idalNhanVienService.GetlstNhanViens();
        }

        public bool Add(NhanVien nv)
        {
            return _idalNhanVienService.Add(nv);
        }
        public bool Update(NhanVien nv)
        {
            return _idalNhanVienService.Update(nv);
        }
        public bool Remove(NhanVien nv)
        {
            return _idalNhanVienService.Remove(nv);
        }
        public bool Save(NhanVien nv)
        {
            return _idalNhanVienService.Save(nv);
        }

        public List<ChucVu> GetlstChucVus()
        {
            return _idalNhanVienService.GetlstChucVus();
        }
    }
}
