using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_LoaiThietBi_Service
    {
        public List<LoaiThietBi> sendlstLoaiThietBi();
        public bool Add(LoaiThietBi mh);
        public bool Update(LoaiThietBi mh);
        public bool Remove(LoaiThietBi mh);
        public bool Save();
        public List<LoaiThietBi> FindName(string name);
    }
}
