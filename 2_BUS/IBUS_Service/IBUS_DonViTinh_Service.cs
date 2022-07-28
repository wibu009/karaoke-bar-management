using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Entities;

namespace _2_BUS.IBUS_MatHang_Service
{
    public interface IBUS_DonViTinh_Service
    {
        public List<DonViTinh> GetlstDonViTinhs();
        public bool AddDonviTinh(DonViTinh dvt);
        public bool EditDonviTinh(DonViTinh dvt);
        public bool RemoveDonviTinh(DonViTinh dvt);
    }
}
