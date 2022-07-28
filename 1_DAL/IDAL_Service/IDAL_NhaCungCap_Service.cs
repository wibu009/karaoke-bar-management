using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_NhaCungCap_Service
    {
        //Phương thức lấy danh sách nhà cung cấp từ db
        public List<NhaCungCap> GetListNhaCungCapsFromDB();

        //Phương thức thêm nhà cung cấp vào db
        public bool AddNhaCungCap(NhaCungCap ncc);

        //Phương thức sửa nhà cung cấp trong db
        public bool UpdateNhaCungCap(NhaCungCap ncc);

        //Phương thức xóa nhà cung cấp trong db
        public bool DeleteNhaCungCap(NhaCungCap ncc);
    }
}
