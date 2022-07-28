using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _1_DAL.IDAL_Service
{
    public interface IDAL_DonViTinh_Service
    {
        
        public List<DonViTinh> sendlstDvTinh();
        public bool AddDVT(DonViTinh dvt);
        public bool EditDVT(DonViTinh dvt);
        public bool RemoveDVT(DonViTinh dvt);
    }
}
