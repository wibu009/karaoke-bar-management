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
    public class BUS_ChiTietHoaDonNhap_Service : IBUS_ChiTietHoaDonNhap_Service
    {
        private IDAL_ChiTietHoaDonNhap_Service _chiTietHoaDonNhapService;
        private List<ChiTietHoaDonNhap> _lstHoaDonNhaps;

        public BUS_ChiTietHoaDonNhap_Service()
        {
            _chiTietHoaDonNhapService = new DAL_ChiTietHoaDonNhap_Service();
            _lstHoaDonNhaps = new List<ChiTietHoaDonNhap>(_chiTietHoaDonNhapService.GetlistChiTietHoaDonNhapsFromDB());
        }

        public List<ChiTietHoaDonNhap> GetListChiTietHoaDonNhaps()
        {
            return _lstHoaDonNhaps;
        }

        public bool AddChiTietHoaDonNhap(int iDHoaDon, int idMatHang, int soLuong, double donGiaNhap)
        {
            try
            {
                ChiTietHoaDonNhap cthdn = new ChiTietHoaDonNhap();
                if (_lstHoaDonNhaps.Count == 0)
                {
                    cthdn.IdchiTietHoaDonNhap = 1;
                }
                else
                {
                    cthdn.IdchiTietHoaDonNhap = _lstHoaDonNhaps.Max(c => c.IdchiTietHoaDonNhap) + 1;
                }
                cthdn.IdhoaDon = iDHoaDon;
                cthdn.IdmatHang = idMatHang;
                cthdn.SoLuong = soLuong;
                cthdn.DonGiaNhap = donGiaNhap;
                if (_chiTietHoaDonNhapService.AddChiTietHoaDonNhap(cthdn))
                {
                    _lstHoaDonNhaps = _chiTietHoaDonNhapService.GetlistChiTietHoaDonNhapsFromDB();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateChiTietHoaDonNhap(int idChiTietHoaDonNhap,int iDHoaDon, int idMatHang, int? soLuong, double? donGiaNhap)
        {
            try
            {
                var cthdn = _lstHoaDonNhaps.FirstOrDefault(c => c.IdchiTietHoaDonNhap == idChiTietHoaDonNhap);
                if (cthdn != null)
                {
                    cthdn.IdhoaDon = iDHoaDon;
                    cthdn.IdmatHang = idMatHang;
                    cthdn.SoLuong = soLuong;
                    cthdn.DonGiaNhap = donGiaNhap;
                    if (_chiTietHoaDonNhapService.UpdateChiTietHoaDonNhap(cthdn))
                    {
                        _lstHoaDonNhaps = _chiTietHoaDonNhapService.GetlistChiTietHoaDonNhapsFromDB();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteChiTietHoaDonNhap(int iDChiTietHoaDonNhap)
        {
            try
            {
                var cthdn = _lstHoaDonNhaps.FirstOrDefault(c => c.IdchiTietHoaDonNhap == iDChiTietHoaDonNhap);
                if (cthdn != null)
                {
                    if (_chiTietHoaDonNhapService.DeleteChiTietHoaDonNhap(cthdn))
                    {
                        _lstHoaDonNhaps = _chiTietHoaDonNhapService.GetlistChiTietHoaDonNhapsFromDB();
                        return false;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
