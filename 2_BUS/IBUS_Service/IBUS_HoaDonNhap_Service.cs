using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_HoaDonNhap_Service
    {
        //Phương thức lấy danh sách hoa đơn 
        public List<HoaDonNhap> GetListHoaDonNhaps();

        //Phương thức thêm hóa đơn 
        public bool AddHoaDonNhapTo(string idNhanVienNhap, int? idNhacc, float tienThanhToan, string nguoiTao,
            string nguoiCapNhat);

        //Phương thức sửa hóa đơn
        public bool UpdateHoaDonNhap(int idHoaDon, string idNhanVienNhap, int? idNhacc, float tienThanhToan,
            string nguoiCapNhat);

        //Phương thức xóa hóa đơn
        public bool DeleteHoaDonNhap(int idHoaDon);
    }
}
