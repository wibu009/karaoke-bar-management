using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_ChiTietHoaDonBan_Service
    {
        void GetlstChiTietHoaDonBan();
        List<ChiTietHoaDonBan> sendlstChiTietHoaDonBan();
        bool Add(ChiTietHoaDonBan chiTietHoaDonBan);
        List<ChiTietHoaDonBan> FindName(int name);//tìm kiếm qua mã mặt hàng
        List<ChiTietHoaDonBan> Find(int id);
        bool Remove(int idchitiethoadon);
        bool Update(ChiTietHoaDonBan chiTietHoaDonBan);
        bool Save();
    }
}
