using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_ThietBi_Service
    {
        public List<ThietBi> GetlstThietBis();
        public bool AddThietBi(ThietBi tb);
        public bool EditThietBi(ThietBi tb);
        public bool RemoveThietBi(ThietBi tb);
        public bool SaveThietBi();
    }
}
