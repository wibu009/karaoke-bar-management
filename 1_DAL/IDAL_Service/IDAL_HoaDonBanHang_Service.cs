using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_HoaDonBanHang_Service
    {
        void GetlstHoaDonBanHang();
        List<HoaDonBanHang> sendlstHoaDonBanHang();
        bool Add(HoaDonBanHang hoaDonBanHang);
        List<HoaDonBanHang> FindName(string name);//tìm kiếm qua mã khách hàng
        List<HoaDonBanHang> Find(int id);
        bool Remove(int idHoaDon);
        bool Update(HoaDonBanHang hoaDonBanHang);
        bool Save();
    }
}
