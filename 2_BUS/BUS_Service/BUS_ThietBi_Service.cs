using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.BUS_Service
{
    public class BUS_ThietBi_Service : IBUS_ThietBi_Service
    {
        private DAL_ThietBi_Service dalThietBiService;
        public BUS_ThietBi_Service()
        {
            dalThietBiService = new DAL_ThietBi_Service();
        }
        public List<ThietBi> GetlstThietBis()
        {
            return dalThietBiService.sendlstThietBi();
        }

        public bool AddThietBi(ThietBi ltb)
        {
            return dalThietBiService.Add(ltb);
        }
        public bool EditThietBi(ThietBi ltb)
        {
            return dalThietBiService.Update(ltb);
        }
        public bool RemoveThietBi(ThietBi ltb)
        {
            return dalThietBiService.Remove(ltb);
        }
        public bool SaveThietBi()
        {
            return dalThietBiService.Save();
        }
    }
}
