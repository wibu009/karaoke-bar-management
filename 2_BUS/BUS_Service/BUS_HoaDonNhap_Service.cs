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
    public class BUS_HoaDonNhap_Service : IBUS_HoaDonNhap_Service
    {
        private IDAL_HoaDonNhap_Service _hoaDonNhapService;
        private List<HoaDonNhap> _lstHoaDonNhaps;

        public BUS_HoaDonNhap_Service()
        {
            _hoaDonNhapService = new DAL_HoaDonNhap_Service();
            _lstHoaDonNhaps = new List<HoaDonNhap>(_hoaDonNhapService.GetListHoaDonNhapsFromDB());
        }

        public List<HoaDonNhap> GetListHoaDonNhaps()
        {
            return _lstHoaDonNhaps;
        }

        public bool AddHoaDonNhapTo(string idNhanVienNhap, int? idNhacc, float tienThanhToan, string nguoiTao, string nguoiCapNhat)
        {
            try
            {
                HoaDonNhap hoaDonNhap = new HoaDonNhap();
                if (_lstHoaDonNhaps.Count == 0)
                {
                    hoaDonNhap.Id = 1;
                }
                else
                {
                    hoaDonNhap.Id = _lstHoaDonNhaps.Max(c => c.Id) + 1;
                }

                hoaDonNhap.IdnhanVienNhap = idNhanVienNhap;
                hoaDonNhap.IdnhaCc = idNhacc;
                hoaDonNhap.TienThanhToan = tienThanhToan;
                hoaDonNhap.NgayNhap = DateTime.Now.ToShortDateString();
                hoaDonNhap.NgayTao = DateTime.Now;
                hoaDonNhap.NguoiTao = nguoiTao;
                hoaDonNhap.NgayCapNhap = DateTime.Now;
                hoaDonNhap.NguoiCapNhap = nguoiCapNhat;
                hoaDonNhap.IdtranngThai = "1";
                if (_hoaDonNhapService.AddHoaDonNhap(hoaDonNhap))
                {
                    _lstHoaDonNhaps = _hoaDonNhapService.GetListHoaDonNhapsFromDB();
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

        public bool UpdateHoaDonNhap(int idHoaDon, string idNhanVienNhap, int? idNhacc, float tienThanhToan, string nguoiCapNhat)
        {
            try
            {
                var hoaDonNhap = _lstHoaDonNhaps.FirstOrDefault(c => c.Id == idHoaDon);
                if (hoaDonNhap != null)
                {
                    hoaDonNhap.IdnhanVienNhap = idNhanVienNhap;
                    hoaDonNhap.IdnhaCc = idNhacc;
                    hoaDonNhap.TienThanhToan = tienThanhToan;
                    hoaDonNhap.NgayCapNhap = DateTime.Now;
                    hoaDonNhap.NguoiCapNhap = nguoiCapNhat;
                    if (_hoaDonNhapService.UpdateHoaDonNhap(hoaDonNhap))
                    {
                        _lstHoaDonNhaps = _hoaDonNhapService.GetListHoaDonNhapsFromDB();
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

        public bool DeleteHoaDonNhap(int idHoaDon)
        {
            try
            {
                var hoaDonNhap = _lstHoaDonNhaps.FirstOrDefault(c => c.Id == idHoaDon);
                if (hoaDonNhap != null)
                {
                    if (_hoaDonNhapService.DeleteHoaDonNhap(hoaDonNhap))
                    {
                        _lstHoaDonNhaps = _hoaDonNhapService.GetListHoaDonNhapsFromDB();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
