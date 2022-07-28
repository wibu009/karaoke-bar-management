using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_ChiTietHoaDonBan_Service
    {
        void GetlstChiTietHoaDonBan();
        List<ChiTietHoaDonBan> sendlstChiTietHoaDonBan();
        bool Add(ChiTietHoaDonBan chiTietHoaDonBan);
        List<ChiTietHoaDonBan> FindName(int name);//tìm kiếm qua mã mặt hàng
        List<ChiTietHoaDonBan> Find(int id);
        bool Remove(int idHoaDon);
        bool Update(ChiTietHoaDonBan chiTietHoaDonBan);
        bool Save();
    }
}
