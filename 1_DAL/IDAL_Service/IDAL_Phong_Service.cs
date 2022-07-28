using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_Phong_Service
    {
        void GetlstPhong();
        List<Phong> sendlstPhong();
        bool Add(Phong Phong);
        List<Phong> FindName(string name);
        List<Phong> Find(int id);
        bool Remove(int idPhong);
        bool Update(Phong Phong);
        bool Save();
    }
}
