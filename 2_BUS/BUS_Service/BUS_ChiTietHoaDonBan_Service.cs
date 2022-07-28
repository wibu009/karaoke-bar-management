using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.BUS_Service
{
    public class BUS_ChiTietHoaDonBan_Service : IBUS_ChiTietHoaDonBan_Service
    {
        private IDAL_ChiTietHoaDonBan_Service _iDAL_ChiTietHoaDonBan_Service;
        public BUS_ChiTietHoaDonBan_Service()
        {
            _iDAL_ChiTietHoaDonBan_Service = new DAL_ChiTietHoaDonBan_Service();
        }
        public bool Add(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            if (getdatabyidhoadon(chiTietHoaDonBan))
            {
                if (sendlstChiTietHoaDonBan().Count == 0)
                {
                    chiTietHoaDonBan.IdchiTietHoaDonBan = 1;
                }
                else
                {
                    chiTietHoaDonBan.IdchiTietHoaDonBan = sendlstChiTietHoaDonBan().Max(x => x.IdchiTietHoaDonBan) + 1;
                }
                chiTietHoaDonBan.SoLuong = 1;
                return _iDAL_ChiTietHoaDonBan_Service.Add(chiTietHoaDonBan);
            }
            else
            {
                var cthd = sendlstChiTietHoaDonBan().Where(x => x.IdhoaDon == chiTietHoaDonBan.IdhoaDon)
                    .Where(c => c.IdmatHang == chiTietHoaDonBan.IdmatHang).FirstOrDefault();
                cthd.SoLuong += 1;
                return _iDAL_ChiTietHoaDonBan_Service.Update(cthd);
            }
        }

        private bool getdatabyidhoadon(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            foreach (var x in sendlstChiTietHoaDonBan())
            {
                if (x.IdhoaDon==chiTietHoaDonBan.IdhoaDon && x.IdmatHang==chiTietHoaDonBan.IdmatHang)
                {
                    return false;
                }
            }
            return true;
        }
        public List<ChiTietHoaDonBan> Find(int id)
        {
            return _iDAL_ChiTietHoaDonBan_Service.Find(id);
        }

        public List<ChiTietHoaDonBan> FindName(int name)
        {
            return _iDAL_ChiTietHoaDonBan_Service.FindName(name);
        }

        public void GetlstChiTietHoaDonBan()
        {
            _iDAL_ChiTietHoaDonBan_Service.GetlstChiTietHoaDonBan();
        }

        public bool Remove(int idchitiethoadon)
        {
            if (sendlstChiTietHoaDonBan().Where(x=>x.IdchiTietHoaDonBan==idchitiethoadon).SingleOrDefault().SoLuong==1)
            { 
                return _iDAL_ChiTietHoaDonBan_Service.Remove(idchitiethoadon);
            }

            var newcthd = sendlstChiTietHoaDonBan().Where(x => x.IdchiTietHoaDonBan == idchitiethoadon).SingleOrDefault();
            newcthd.SoLuong--;
            return _iDAL_ChiTietHoaDonBan_Service.Update(newcthd);
        }

        public bool Save()
        {
            return _iDAL_ChiTietHoaDonBan_Service.Save();
        }

        public List<ChiTietHoaDonBan> sendlstChiTietHoaDonBan()
        {
            return _iDAL_ChiTietHoaDonBan_Service.sendlstChiTietHoaDonBan();
        }

        public bool Update(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            return _iDAL_ChiTietHoaDonBan_Service.Update(chiTietHoaDonBan);
        }
    }
}
