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
    public class BUS_NhaCungCap_Service : IBUS_NhaCungCap_Service
    {
        private IDAL_NhaCungCap_Service _nhaCungCapService;
        private List<NhaCungCap> _lsNhaCungCaps;

        public BUS_NhaCungCap_Service()
        {
            _nhaCungCapService = new DAL_NhaCungCap_Service();
            _lsNhaCungCaps = new List<NhaCungCap>(_nhaCungCapService.GetListNhaCungCapsFromDB());
        }

        public List<NhaCungCap> GetListnNhaCungCapsFromDAL()
        {
            return _lsNhaCungCaps;
        }

        public bool AddNhaCungCap(string tenNcc, string nguoiTao, string nguoiCapNhat, string dienThoai, string email, string diaChi)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                if (_lsNhaCungCaps == null)
                {
                    ncc.Id = 1;
                }
                else
                {
                    ncc.Id = _lsNhaCungCaps.Max(c => c.Id) + 1;
                }
                ncc.TenNcc = tenNcc;
                ncc.NguoiTao = nguoiTao;
                ncc.NguoiCapNhap = nguoiCapNhat;
                ncc.DiaChi = diaChi;
                ncc.Email = email;
                ncc.DienThoai = dienThoai;
                ncc.NgayTao = DateTime.Now;
                ncc.NgayCapNhap = DateTime.Now;
                ncc.IdtranngThai = 1;
                if (_nhaCungCapService.AddNhaCungCap(ncc))
                {
                    _lsNhaCungCaps = _nhaCungCapService.GetListNhaCungCapsFromDB();
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

        public bool UpdateNhaCungCap(int id, string tenNcc, string nguoiCapNhap, string diaChi, string email, string dienThoai)
        {
            try
            {
                var ncc = _lsNhaCungCaps.FirstOrDefault(c => c.Id == id);
                if (ncc != null)
                {
                    ncc.TenNcc = tenNcc;
                    ncc.DiaChi = diaChi;
                    ncc.Email = email;
                    ncc.DienThoai = dienThoai;
                    ncc.NguoiCapNhap = nguoiCapNhap;
                    ncc.NgayCapNhap = DateTime.Now;
                    if (_nhaCungCapService.UpdateNhaCungCap(ncc))
                    {
                        _lsNhaCungCaps = _nhaCungCapService.GetListNhaCungCapsFromDB();
                        return true;
                    }
                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteNhaCungCap(int id)
        {
            try
            {
                var ncc = _lsNhaCungCaps.FirstOrDefault(c => c.Id == id);
                if (ncc != null)
                {
                    if (_nhaCungCapService.DeleteNhaCungCap(ncc))
                    {
                        _lsNhaCungCaps = _nhaCungCapService.GetListNhaCungCapsFromDB();
                        return true;
                    }
                    return false;
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
