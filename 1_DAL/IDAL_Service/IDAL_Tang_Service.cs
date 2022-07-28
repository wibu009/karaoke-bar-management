using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_Tang_Service
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
