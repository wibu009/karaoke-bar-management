using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    public interface IDAL_RE_MatHang_Service
    {
        //Phương thức lấy danh sách mặt hàng từ database
        public List<MatHang> GetListMatHangFromDB();

        //Phương thức thêm mặt hàng vào database
        public bool AddMatHangToDB(MatHang mh);

        //Phương thức sửa mặt hàng trong database
        public bool UpdateMatHangToDB(MatHang mh);

        //Phương thức xóa mặt hàng trong database
        public bool DeleteMatHangToDB(MatHang mh);
    }
}
