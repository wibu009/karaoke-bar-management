using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_MatHang_Service;

namespace _2_BUS.BUS_MatHang_Service
{
    public class BUS_DonViTinh_Service:IBUS_DonViTinh_Service
    {
        private IDAL_DonViTinh_Service daldvtservice;

        public BUS_DonViTinh_Service()
        {
            daldvtservice = new DAL_DonViTinh_Service();
        }
        public List<DonViTinh> GetlstDonViTinhs()
        {
            return daldvtservice.sendlstDvTinh();
        }

        public bool AddDonviTinh(DonViTinh dvt)
        {
            return daldvtservice.AddDVT(dvt);
        }
        public bool EditDonviTinh(DonViTinh dvt)
        {
            return daldvtservice.EditDVT(dvt);
        }
        public bool RemoveDonviTinh(DonViTinh dvt)
        {
            return daldvtservice.RemoveDVT(dvt);
        }
    
    }
}
