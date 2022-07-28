using _1_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_LoaiThietBi_Service
    {
        public List<LoaiThietBi> GetlstLoaiThietBis();
        public bool AddLoaiThietBi(LoaiThietBi ltb);
        public bool EditLoaiThietBi(LoaiThietBi ltb);
        public bool RemoveLoaiThietBi(LoaiThietBi ltb);
        public bool SaveLoaiThietBi();
    }
}
