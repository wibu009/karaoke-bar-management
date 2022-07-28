using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_LoaiPhong_Service
    {
        void GetlstLoaiPhong();
        List<LoaiPhong> sendlstLoaiPhong();
        bool Add(LoaiPhong loaiPhong);
        List<LoaiPhong> FindName(string name);
        List<LoaiPhong> Find(int id);
        bool Remove(int loaiPhong);
        bool Update(LoaiPhong loaiPhong);
        bool Save();
    }
}
