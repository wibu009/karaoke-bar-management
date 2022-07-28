using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_ChiTietHoaDonNhap_Service
    {
        //Phương thức lấy danh sách chi tiết hóa đơn nhập
        public List<ChiTietHoaDonNhap> GetListChiTietHoaDonNhaps();

        //Phương thức tạo chi tiết hóa đơn nhập mới
        public bool AddChiTietHoaDonNhap(int iDHoaDon, int idMatHang, int soLuong, double donGiaNhap);

        //Phương thức sửa chi tiết hóa đơn nhập
        public bool UpdateChiTietHoaDonNhap(int idChiTietHoaDonNhap, int iDHoaDon, int idMatHang, int? soLuong,
            double? donGiaNhap);

        //Phương thức xóa chi tiết hóa đơn nhập
        public bool DeleteChiTietHoaDonNhap(int iDChiTietHoaDonNhap);
    }
}
