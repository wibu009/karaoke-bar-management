using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_ThietBi_Service
    {
        public List<ThietBi> sendlstThietBi();
        public bool Add(ThietBi mh);
        public bool Update(ThietBi mh);
        public bool Remove(ThietBi mh);
        public bool Save();
        public List<ThietBi> FindName(string name);
    }
}
