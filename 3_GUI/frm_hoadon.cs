using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1_DAL.Entities;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_Service;

namespace _3_GUI
{
    public partial class frm_hoadon : Form
    {
        private IBUS_ChiTietHoaDonBan_Service _chiTietHoaDonBanService;
        private IBUS_KhachHang_Service _khachHangService;
        private IBUS_MatHang_Service _matHangService;
        private IBUS_Phong_Service _phongService;
        private HoaDonBanHang _hoadon;
        private IBUS_LoaiPhong_Service _loaiPhongService;
        private IBUS_CongThucTinh_Service _congThucTinhService;
        public frm_hoadon(HoaDonBanHang hoaDonBanHang)
        {
            InitializeComponent();
            _hoadon = hoaDonBanHang;
            _chiTietHoaDonBanService = new BUS_ChiTietHoaDonBan_Service();
            _matHangService = new BUS_MatHang_Service();
            _khachHangService = new BUS_KhachHang_Service();
            _phongService = new BUS_Phong_Service();
            _loaiPhongService = new BUS_LoaiPhong_Service();
            _congThucTinhService = new BUS_CongThucTinh_Service();

            loaddata();
            load();
        }

        void load()
        {
            var khachhang = _khachHangService.GetlstKhachHangs().SingleOrDefault(c => c.MaKh == _hoadon.IdmaKh);
            lb_khachhang.Text = khachhang.Ho + " " + khachhang.TenDem + " " + khachhang.Ten;
            lb_SDT.Text = "-"+khachhang.DienThoai;
            lb_phong.Text =_loaiPhongService.sendlstLoaiPhong().SingleOrDefault(c=>c.Id == _phongService.sendlstPhong().SingleOrDefault(c => c.Id == _hoadon.Idphong).IdloaiPhong).TenLoaiPhong +" "+
                _phongService.sendlstPhong().SingleOrDefault(c => c.Id == _hoadon.Idphong).TenPhong;
            lb_timestart.Text = _hoadon.ThoiGianBatDau.Value.ToShortTimeString();
            lb_timeend.Text = _hoadon.ThoiGianKetThuc.Value.ToShortTimeString();
            lb_tienphong.Text = _hoadon.DonGiaPhong.Value.ToString();
            lb_tienDV.Text = tienDV().ToString() ;
            lb_chiphikhac.Text = _hoadon.NguoiBan;
            lb_tong.Text = (tienphongdutinh()+tienDV()+double.Parse(_hoadon.NguoiBan)).ToString();
            tienphongused();
            
        }
        void tienphongused()
        {
            int tg = thoigiansudung();
            double tientheogio = 0;
            double uudai = 0; 
            var CTT = _congThucTinhService.GetListCongThucTinhsFromDAL()
                .SingleOrDefault(c => c.IdcongThucTinh == _hoadon.IdcongThucTinh);
            if (tg < CTT.ThoiGianNhanUuDai3)
            {
                if (tg < CTT.ThoiGianNhanUuDai2)
                {
                    if (tg < CTT.ThoiGianNhanUuDai1)
                    {
                        tientheogio = tg * _hoadon.DonGiaPhong.Value;
                        uudai = 0;
                    }
                    else
                    {
                        tientheogio = tg * _hoadon.DonGiaPhong.Value * (1 - CTT.UuDai1.Value);
                        uudai = CTT.UuDai1.Value;

                    }
                }
                else
                {
                    tientheogio = tg * _hoadon.DonGiaPhong.Value * (1 - CTT.UuDai2.Value);
                    uudai = CTT.UuDai2.Value;
                }
            }
            else
            {
                tientheogio = tg * _hoadon.DonGiaPhong.Value * (1 - CTT.UuDai3.Value);
                uudai = CTT.UuDai3.Value;
            }
            lb_ud.Text = (uudai*100).ToString()+"%";
            lb_thanhtien.Text = (tientheogio + tienDV() +double.Parse(_hoadon.NguoiBan)).ToString();
        }
        int thoigiansudung()
        {
            int x;
            x = _hoadon.ThoiGianKetThuc.Value.Hour - _hoadon.ThoiGianBatDau.Value.Hour;
            if (_hoadon.ThoiGianKetThuc.Value.Minute - _hoadon.ThoiGianBatDau.Value.Minute >= 15)
            {
                x += 1;
            }
            if (x == 0)
            {
                x = 1;
            }
            return x;
        }
        double tienphongdutinh()
        {
            double tienphongdutinh;
            return tienphongdutinh = thoigiansudung() * _hoadon.DonGiaPhong.Value;
        }
        double tienDV()
        {
            double C = 0;
            foreach (var x in _chiTietHoaDonBanService.sendlstChiTietHoaDonBan().Where(x => x.IdhoaDon == _hoadon.IdhoaDon))
            {
                C += x.DonGia.Value * x.SoLuong.Value;
            }
            return C;
        }
        void loaddata()
        {
            var data = (from a in _chiTietHoaDonBanService.sendlstChiTietHoaDonBan().Where(c => c.IdhoaDon == _hoadon.IdhoaDon)
                join b in _matHangService.GetlstMatHangs() on a.IdmatHang equals b.Id
                select new
                {
                    b.TenMatHang,
                    a.SoLuong,
                    a.DonGia
                }).ToList();
            dataGridView1.DataSource = data;
        }

        private void frm_hoadon_Load(object sender, EventArgs e)
        {
            lb_sohd.Text = _hoadon.IdhoaDon.ToString();
            lb_time.Text = DateTime.Now.ToLongTimeString();
            dataGridView1.Columns["TenMatHang"].HeaderText = "Tên mặt hàng";
            dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView1.Columns["DonGia"].HeaderText = "Đơn giá(VND.)";
        }
    }
}
