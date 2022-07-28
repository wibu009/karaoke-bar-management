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
    public class BUS_CongThucTinh_Service : IBUS_CongThucTinh_Service
    {
        private IDAL_CongThucTinh_Service _congThucTinh_Service ;
        private List<CongThucTinh> _lstCongThucTinhs;

        public BUS_CongThucTinh_Service()
        {
            _congThucTinh_Service = new DAL_CongThucTinh_Service();
            _lstCongThucTinhs = new List<CongThucTinh>(_congThucTinh_Service.GetListCongThucTinhsFromDB());
        }

        public List<CongThucTinh> GetListCongThucTinhsFromDAL()
        {
            return _lstCongThucTinhs;
        }

        public bool AddCongThucTinh(double uuDai1, double uuDai2, double uuDai3, double thoiGianNhanUuDai1, double thoiGianNhanUuDai2, double thoiGianNhanUuDai3, double giaPhong, double giaPhongVIP, string ghiChu)
        {
            try
            {
                CongThucTinh ctt = new CongThucTinh();
                if (_lstCongThucTinhs == null)
                {
                    ctt.IdcongThucTinh = 1;
                }
                else
                {
                    ctt.IdcongThucTinh = _lstCongThucTinhs.Max(c => c.IdcongThucTinh) + 1;
                }

                ctt.UuDai1 = uuDai1;
                ctt.UuDai2 = uuDai2;
                ctt.UuDai3 = uuDai3;
                ctt.ThoiGianNhanUuDai1 = thoiGianNhanUuDai1;
                ctt.ThoiGianNhanUuDai2 = thoiGianNhanUuDai2;
                ctt.ThoiGianNhanUuDai3 = thoiGianNhanUuDai3;
                ctt.GhiChu = ghiChu;
                ctt.IdtrangThai = 1;
                if (_congThucTinh_Service.AddCongThucTinh(ctt))
                {
                    _lstCongThucTinhs = _congThucTinh_Service.GetListCongThucTinhsFromDB();
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

        public bool UpdateCongThucTinh(int id, double uuDai1, double uuDai2, double uuDai3, double thoiGianNhanUuDai1,
            double thoiGianNhanUuDai2, double thoiGianNhanUuDai3, double giaPhong, double giaPhongVIP,string ghiChu)
        {
            try
            {
                var ctt = _lstCongThucTinhs.FirstOrDefault(c => c.IdcongThucTinh == id);
                if (ctt != null)
                {
                    ctt.UuDai1 = uuDai1;
                    ctt.UuDai2 = uuDai2;
                    ctt.UuDai3 = uuDai3;
                    ctt.ThoiGianNhanUuDai1 = thoiGianNhanUuDai1;
                    ctt.ThoiGianNhanUuDai2 = thoiGianNhanUuDai2;
                    ctt.ThoiGianNhanUuDai3 = thoiGianNhanUuDai3;
                    ctt.GiaPhong = giaPhong;
                    ctt.GiaPhongVIP = giaPhongVIP;
                    ctt.GhiChu = ghiChu;
                    if (_congThucTinh_Service.UpdateCongThucTinh(ctt))
                    {
                        _lstCongThucTinhs = _congThucTinh_Service.GetListCongThucTinhsFromDB();
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

        public bool DeleteCongThucTinh(int id)
        {
            try
            {
                var ctt = _lstCongThucTinhs.FirstOrDefault(c => c.IdcongThucTinh == id);
                if (ctt != null)
                {
                    if (_congThucTinh_Service.DeleteCongThucTinh(ctt))
                    {
                        _lstCongThucTinhs = _congThucTinh_Service.GetListCongThucTinhsFromDB();
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
    }
}
