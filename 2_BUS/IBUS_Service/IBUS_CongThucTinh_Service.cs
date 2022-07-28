using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_CongThucTinh_Service
    {
        //Phương thức lấy danh sách công thức tính
        public List<CongThucTinh> GetListCongThucTinhsFromDAL();

        //Phương thức thêm công thức tính
        public bool AddCongThucTinh(double uuDai1, double uuDai2, double uuDai3, double thoiGianNhanUuDai1,
            double thoiGianNhanUuDai2, double thoiGianNhanUuDai3,double giaPhong, double giaPhongVIP, string ghiChu);

        //Phương thức sửa công thức tính
        public bool UpdateCongThucTinh(int id, double uuDai1, double uuDai2, double uuDai3, double thoiGianNhanUuDai1,
            double thoiGianNhanUuDai2, double thoiGianNhanUuDai3, double giaPhong, double giaPhongVIP, string ghiChu);

        //Phương thức xóa công thức tính
        public bool DeleteCongThucTinh(int id);
    }
}
