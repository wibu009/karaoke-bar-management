using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_Tang_Service
    {
        void GetlstTang();
        List<Tang> sendlstTang();
        bool Add(Tang Tang);
        List<Tang> FindName(string name);
        List<Tang> Find(int id);
        bool Remove(int idTang);
        bool Update(Tang Tang);
        bool Save();
    }
}
