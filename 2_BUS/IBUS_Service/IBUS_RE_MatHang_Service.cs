using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_RE_MatHang_Service
    {
        //Phương thức lấy danh sách mặt hàng
        public List<MatHang> GetListMatHangs();

        //Phương thức thêm mặt hàng
        public bool ReAddMatHang(string tenMatHang, int? idDonViTinh, double donGia, string nguoiTao,
            string nguoiCapNhat);

        //Phương thức sửa mặt hàng
        public bool ReUpdateMatHang(int id, string tenMatHang, int? idDonViTinh, double donGia, int? soLuong,
            string nguoiCapNhat);

        //Phương thức xóa mặt hàng
        public bool ReDeleteMatHang(int id);
    }
}
