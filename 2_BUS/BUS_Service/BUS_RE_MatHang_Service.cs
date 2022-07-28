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
    public class BUS_RE_MatHang_Service : IBUS_RE_MatHang_Service
    {
        private List<MatHang> _lstMatHangs;
        private IDAL_RE_MatHang_Service _reMatHangService;

        public BUS_RE_MatHang_Service()
        {
            _reMatHangService = new DAL_RE_MatHang_Service();
            _lstMatHangs = new List<MatHang>(_reMatHangService.GetListMatHangFromDB());
        }

        public virtual List<MatHang> GetListMatHangs()
        {
            return _lstMatHangs;
        }

        public virtual bool ReAddMatHang(string tenMatHang, int? idDonViTinh, double donGia, string nguoiTao, string nguoiCapNhat) 
        {
            try
            {
                MatHang mh = new MatHang();
                if (_lstMatHangs.Count == 0)
                {
                    mh.Id = 1;
                }
                else
                {
                    mh.Id = _lstMatHangs.Max(c => c.Id) + 1;
                }
                mh.TenMatHang = tenMatHang;
                mh.SoLuong = 0;
                mh.NgayTao = DateTime.Now;
                mh.NguoiTao = nguoiTao;
                mh.NgayCapNhap = DateTime.Now;
                mh.NguoiCapNhap = nguoiCapNhat;
                mh.IdtranngThai = 1;
                if (_reMatHangService.AddMatHangToDB(mh))
                {
                    _lstMatHangs = _reMatHangService.GetListMatHangFromDB();
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

        public virtual bool ReUpdateMatHang(int id, string tenMatHang, int? idDonViTinh, double donGia, int? soLuong,string nguoiCapNhat)
        {
            try
            {
                var mh = _lstMatHangs.FirstOrDefault(c => c.Id == id);
                if (mh != null)
                {
                    mh.TenMatHang = tenMatHang;
                    mh.IddonViTinh = idDonViTinh;
                    mh.DonGia = donGia;
                    mh.SoLuong = soLuong;
                    mh.NgayCapNhap = DateTime.Now;
                    mh.NguoiCapNhap = nguoiCapNhat;
                    if (_reMatHangService.UpdateMatHangToDB(mh))
                    {
                        _lstMatHangs = _reMatHangService.GetListMatHangFromDB();
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

        public virtual bool ReDeleteMatHang(int id)
        {
            try
            {
                var mh = _lstMatHangs.FirstOrDefault(c => c.Id == id);
                if (mh != null)
                {
                    if (_reMatHangService.DeleteMatHangToDB(mh))
                    {
                        _lstMatHangs = _reMatHangService.GetListMatHangFromDB();
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
