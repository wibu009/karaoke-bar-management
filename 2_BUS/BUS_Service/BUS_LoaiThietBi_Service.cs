using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_Service;

namespace _2_BUS.BUS_Service
{
    public class BUS_LoaiThietBi_Service : IBUS_LoaiThietBi_Service
    {
        private DAL_LoaiThietBi_Service dalLoaiThietBiService;
        public BUS_LoaiThietBi_Service()
        {
            dalLoaiThietBiService = new DAL_LoaiThietBi_Service();
        }
        public List<LoaiThietBi> GetlstLoaiThietBis()
        {
            return dalLoaiThietBiService.sendlstLoaiThietBi();
        }

        public bool AddLoaiThietBi(LoaiThietBi ltb)
        {
            return dalLoaiThietBiService.Add(ltb);
        }
        public bool EditLoaiThietBi(LoaiThietBi ltb)
        {
            return dalLoaiThietBiService.Update(ltb);
        }
        public bool RemoveLoaiThietBi(LoaiThietBi ltb)
        {
            return dalLoaiThietBiService.Remove(ltb);
        }
        public bool SaveLoaiThietBi()
        {
            return dalLoaiThietBiService.Save();
        }
    }
}
