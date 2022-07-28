using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_NhaCungCap_Service
    {
        //Phương thức lấy danh sách nhà cung cấp từ dal
        public List<NhaCungCap> GetListnNhaCungCapsFromDAL();

        //Phương thức thêm nhà cung cấp mới vào danh sách nhà cung cấp
        public bool AddNhaCungCap(string tenNcc, string nguoiTao, string nguoiCapNhat, string dienThoai, string email,
            string diaChi);

        //Phương thức sửa nhà cung cấp trong danh sách nhà cung cấp
        public bool UpdateNhaCungCap(int id, string tenNcc, string nguoiCapNhap, string diaChi, string email,
            string dienThoai);

        //Phương thức xóa nhà cung cấp trong danh sách nhà cung cấp
        public bool DeleteNhaCungCap(int id);
    }
}
