using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
     public interface IDAL_LoaiPhong_Service
    {
        void GetlstLoaiPhong();
        List<LoaiPhong> sendlstLoaiPhong();
        bool Add(LoaiPhong loaiPhong);
        List<LoaiPhong> FindName(string name);
        List<LoaiPhong> Find(int id);
        bool Remove(int idloaiPhong);
        bool Update(LoaiPhong loaiPhong);
        bool Save();
    }
}
