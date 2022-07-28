using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_HoaDonNhap_Service
    {
        //Phương thức lấy danh sách hóa đơn nhập từ db
        public List<HoaDonNhap> GetListHoaDonNhapsFromDB();

        //Phương thức thêm hóa đơn nhập vào db
        public bool AddHoaDonNhap(HoaDonNhap hdn);

        //Phương thức sửa hóa đơn nhập trong db
        public bool UpdateHoaDonNhap(HoaDonNhap hdn);

        //Phương thức xóa hóa đơn nhập trong db
        public bool DeleteHoaDonNhap(HoaDonNhap hdn);
    }
}
