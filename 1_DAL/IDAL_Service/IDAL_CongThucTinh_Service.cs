using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_CongThucTinh_Service
    {
        //Phương thức lấy danh sách công thức tính từ db
        public List<CongThucTinh> GetListCongThucTinhsFromDB();

        //Phương thức thêm công thức tính vào db
        public bool AddCongThucTinh(CongThucTinh ctt);

        //Phương thức sửa công thức tính trong db
        public bool UpdateCongThucTinh(CongThucTinh ctt);

        //Phương thức xóa công thức tính trong db
        public bool DeleteCongThucTinh(CongThucTinh ctt);
    }
}
