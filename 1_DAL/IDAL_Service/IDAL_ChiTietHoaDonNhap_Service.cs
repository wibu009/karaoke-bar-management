using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_ChiTietHoaDonNhap_Service
    {
        //Phương thức lấy danh sách chi tiết hóa đơn từ db
        public List<ChiTietHoaDonNhap> GetlistChiTietHoaDonNhapsFromDB();

        //Phương thức thêm chi tiết hóa đơn vào db
        public bool AddChiTietHoaDonNhap(ChiTietHoaDonNhap cthdn);

        //Phương thức sửa chi tiết hóa đơn trong db
        public bool UpdateChiTietHoaDonNhap(ChiTietHoaDonNhap cthdn);

        //Phương thức xóa chi tiết hóa đơn khỏi db
        public bool DeleteChiTietHoaDonNhap(ChiTietHoaDonNhap cthdn);
    }
}
