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
   public class BUS_MatHang_Service: IBUS_Service.IBUS_MatHang_Service
    {
        private IDAL_MatHang_Service dalMatHangService;
        public BUS_MatHang_Service()
        {
            dalMatHangService = new DAL_MatHang_Service();
        }
        public List<MatHang> GetlstMatHangs()
        {
            return dalMatHangService.sendlstMatHang();
        }

        public bool AddMatHangh(MatHang mh)
        {
            return dalMatHangService.Add(mh);
        }

        public bool EditMatHang(MatHang mh)
        {
            return dalMatHangService.Update(mh);
        }

        public bool banhang(int idmathang)
        {
            var _mathang = GetlstMatHangs().SingleOrDefault(c => c.Id == idmathang);
            _mathang.SoLuong -=1;
            return dalMatHangService.Update(_mathang);
        }

        public bool hoantra(int idmathang)
        {
            var _mathang = GetlstMatHangs().SingleOrDefault(c => c.Id == idmathang);
            _mathang.SoLuong += 1;
            return dalMatHangService.Update(_mathang);
        }
        public bool RemoveMatHang(MatHang mh)
        {
            return dalMatHangService.Remove(mh);
        }
        public bool SaveMatHang()
        {
            return dalMatHangService.Save();
        }


    }
}
