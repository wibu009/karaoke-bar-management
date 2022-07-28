using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1_DAL.Entities;
using _2_BUS.BUS_MatHang_Service;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_MatHang_Service;
using _2_BUS.IBUS_Service;

namespace _3_GUI
{
    public partial class frm_ThongKeThuChi : Form
    {
        private IBUS_HoaDonNhap_Service _hoaDonNhapService;
        private IBUS_HoaDonBanHang_Service _hoaDonBanHangService;
        private IBUS_ChiTietHoaDonBan_Service _chiTietHoaDonBanService;
        private IBUS_ChiTietHoaDonNhap_Service _chiTietHoaDonNhapService;
        private IBUS_NhaCungCap_Service _nhaCungCapService;
        private IBUS_CongThucTinh_Service _congThucTinhService;
        private IBUS_RE_MatHang_Service _reMatHangService;
        private IBUS_DonViTinh_Service _donViTinhService;
        private int _iDHoaDonNhap;
        private int _idHoaDonBan;
        private int _flagOfHoaDonNhap = 0;
        private int _flagOfHoaDonBan = 0;

        public frm_ThongKeThuChi()
        {
            InitializeComponent();
            _hoaDonNhapService = new BUS_HoaDonNhap_Service();
            _hoaDonBanHangService = new BUS_HoaDonBanHang_Service();
            _chiTietHoaDonNhapService = new BUS_ChiTietHoaDonNhap_Service();
            _chiTietHoaDonBanService = new BUS_ChiTietHoaDonBan_Service();
            _nhaCungCapService = new BUS_NhaCungCap_Service();
            _congThucTinhService = new BUS_CongThucTinh_Service();
            _reMatHangService = new BUS_RE_MatHang_Service();
            _donViTinhService = new BUS_DonViTinh_Service();
            gbx_ChiTietHoaDonNhap.Visible = false;
            gbx_ChiTietHoaDonBan.Visible = false;
            FillDataHoaDonNhap(DateTime.Now);
            FillDataHoaDonBan(DateTime.Now);
        }

        public void FillDataHoaDonNhap(DateTime ngay)
        {
            dgrid_HoaDonNhap.Columns.Clear();
            dgrid_HoaDonNhap.ColumnCount = 7;
            dgrid_HoaDonNhap.Columns[0].Name = "Mã hóa đơn";
            dgrid_HoaDonNhap.Columns[1].Name = "Đơn giá";
            dgrid_HoaDonNhap.Columns[2].Name = "Mã nhà cung cấp";
            dgrid_HoaDonNhap.Columns[3].Name = "Ngày tạo";
            dgrid_HoaDonNhap.Columns[4].Name = "Người tạo";
            dgrid_HoaDonNhap.Columns[5].Name = "Ngày cập nhật";
            dgrid_HoaDonNhap.Columns[6].Name = "Người cập nhật";

            dgrid_HoaDonNhap.Columns[6].Visible = false;
            dgrid_HoaDonNhap.Columns[5].Visible = false;
            dgrid_HoaDonNhap.Columns[2].Visible = false;

            if (_flagOfHoaDonNhap == 0)
            {
                foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps())
                {
                    dgrid_HoaDonNhap.Rows.Add(x.Id, x.TienThanhToan, x.IdnhaCc, x.NgayTao, x.NguoiTao, x.NgayCapNhap, x.NguoiCapNhap);
                }

                return;
            }

            if(_flagOfHoaDonNhap == 1)
            {
                foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps().Where(c =>
                    c.NgayTao.Day == ngay.Day && c.NgayTao.Month == ngay.Month && c.NgayTao.Year == ngay.Year))
                {
                    dgrid_HoaDonNhap.Rows.Add(x.Id, x.IdnhaCc, x.TienThanhToan, x.NgayTao, x.NguoiTao, x.NgayCapNhap, x.NguoiCapNhap);
                }

                return;
            }

            if (_flagOfHoaDonNhap == 2)
            {
                foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps().Where(c => c.NgayTao.Month == ngay.Month && c.NgayTao.Year == ngay.Year))
                {
                    dgrid_HoaDonNhap.Rows.Add(x.Id, x.IdnhaCc, x.TienThanhToan, x.NgayTao, x.NguoiTao, x.NgayCapNhap, x.NguoiCapNhap);
                }

                return;
            }

            if (_flagOfHoaDonNhap == 3)
            {
                foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps().Where(c => c.NgayTao.Year == ngay.Year))
                {
                    dgrid_HoaDonNhap.Rows.Add(x.Id, x.IdnhaCc, x.TienThanhToan, x.NgayTao, x.NguoiTao, x.NgayCapNhap, x.NguoiCapNhap);
                }

                return;
            }

        }

        public void FillDataHoaDonBan(DateTime ngay)
        {
            dgrid_HoaDonBan.Columns.Clear();
            dgrid_HoaDonBan.ColumnCount = 8;
            dgrid_HoaDonBan.Columns[0].Name = "Mã hóa đơn";
            dgrid_HoaDonBan.Columns[1].Name = "Mã phòng";
            dgrid_HoaDonBan.Columns[2].Name = "Người tạo";
            dgrid_HoaDonBan.Columns[3].Name = "Ngày tạo";
            dgrid_HoaDonBan.Columns[4].Name = "Người cập nhật";
            dgrid_HoaDonBan.Columns[5].Name = "Ngày cập nhật";
            dgrid_HoaDonBan.Columns[6].Name = "Công thức tính";
            dgrid_HoaDonBan.Columns[7].Name = "Đơn giá";

            dgrid_HoaDonBan.Columns[4].Visible = false;
            dgrid_HoaDonBan.Columns[5].Visible = false;
            dgrid_HoaDonBan.Columns[1].Visible = false;
            dgrid_HoaDonBan.Columns[7].Visible = false;

            if (_flagOfHoaDonBan == 0)
            {
                foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang())
                {
                    dgrid_HoaDonBan.Rows.Add(x.IdhoaDon, x.Idphong, x.NguoiTao, x.NgayTao, x.NguoiCapNhap,
                        x.NgayCapNhap, x.IdcongThucTinh, x.DonGiaPhong);
                }
                return;
            }

            if(_flagOfHoaDonBan == 1)
            {
                foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang().Where(c => c.NgayTao?.Day == ngay.Day && c.NgayTao?.Month == ngay.Month && c.NgayTao?.Year == ngay.Year))
                {
                    dgrid_HoaDonBan.Rows.Add(x.IdhoaDon, x.Idphong, x.NguoiTao, x.NgayTao, x.NguoiCapNhap,
                        x.NgayCapNhap, x.IdcongThucTinh, x.DonGiaPhong);
                }
                return;
            }

            if (_flagOfHoaDonBan == 2)
            {
                foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang().Where(c => c.NgayTao?.Month == ngay.Month && c.NgayTao?.Year == ngay.Year))
                {
                    dgrid_HoaDonBan.Rows.Add(x.IdhoaDon, x.Idphong, x.NguoiTao, x.NgayTao, x.NguoiCapNhap,
                        x.NgayCapNhap, x.IdcongThucTinh, x.DonGiaPhong);
                }
                return;
            }

            if (_flagOfHoaDonBan == 3)
            {
                foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang().Where(c => c.NgayTao?.Year == ngay.Year))
                {
                    dgrid_HoaDonBan.Rows.Add(x.IdhoaDon, x.Idphong, x.NguoiTao, x.NgayTao, x.NguoiCapNhap,
                        x.NgayCapNhap, x.IdcongThucTinh, x.DonGiaPhong);
                }

                return;
            }
        }

        public void FillDataChiTietHoaDonNhap(int idHoaDonNhap)
        {
            dgrid_ChiTietHoaDonNhap.Columns.Clear();
            dgrid_ChiTietHoaDonNhap.ColumnCount = 6;
            dgrid_ChiTietHoaDonNhap.Columns[0].Name = "Mã chi tiết hóa đơn";
            dgrid_ChiTietHoaDonNhap.Columns[1].Name = "Mã hóa đơn";
            dgrid_ChiTietHoaDonNhap.Columns[2].Name = "Mặt hàng";
            dgrid_ChiTietHoaDonNhap.Columns[3].Name = "Số lượng";
            dgrid_ChiTietHoaDonNhap.Columns[4].Name = "Đơn giá";
            dgrid_ChiTietHoaDonNhap.Columns[5].Name = "Đơn vị tính";

            dgrid_ChiTietHoaDonNhap.Columns[0].Visible = false;
            dgrid_ChiTietHoaDonNhap.Columns[1].Visible = false;
            foreach (var x in _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps().Where(c => c.IdhoaDon == _iDHoaDonNhap))
            {
                dgrid_ChiTietHoaDonNhap.Rows.Add(x.IdchiTietHoaDonNhap, x.IdhoaDon, _reMatHangService.GetListMatHangs().FirstOrDefault(c => c.Id == x.IdmatHang)?.TenMatHang, x.SoLuong, x.DonGiaNhap,
                    _donViTinhService.GetlstDonViTinhs().FirstOrDefault(c =>
                        c.Id == _reMatHangService.GetListMatHangs().FirstOrDefault(hang => hang.Id == x.IdmatHang)
                            ?.IddonViTinh)
                        ?.TenDvt);
            }
        }

        public void FillDataChiTietHoaDonBan(int idHoaDonBan)
        {
            dgrid_ChiTietHoaDonBan.Columns.Clear();
            dgrid_ChiTietHoaDonBan.ColumnCount = 7;
            dgrid_ChiTietHoaDonBan.Columns[0].Name = "Mã chi tiết hóa đơn";
            dgrid_ChiTietHoaDonBan.Columns[1].Name = "Mã hóa đơn";
            dgrid_ChiTietHoaDonBan.Columns[2].Name = "Mặt hàng";
            dgrid_ChiTietHoaDonBan.Columns[3].Name = "Người tạo";
            dgrid_ChiTietHoaDonBan.Columns[4].Name = "Số lượng";
            dgrid_ChiTietHoaDonBan.Columns[5].Name = "Đơn giá";
            dgrid_ChiTietHoaDonBan.Columns[6].Name = "Đơn vị tính";

            dgrid_ChiTietHoaDonBan.Columns[0].Visible = false;
            dgrid_ChiTietHoaDonBan.Columns[1].Visible = false;
            foreach (var x in _chiTietHoaDonBanService.sendlstChiTietHoaDonBan().Where(c => c.IdhoaDon == _idHoaDonBan))
            {
                dgrid_ChiTietHoaDonBan.Rows.Add(x.IdchiTietHoaDonBan, x.IdhoaDon,
                    _reMatHangService.GetListMatHangs().FirstOrDefault(c => c.Id == x.IdmatHang)?.TenMatHang,
                    x.Idusername, x.SoLuong, x.DonGia, _donViTinhService.GetlstDonViTinhs().FirstOrDefault(c =>
                            c.Id == _reMatHangService.GetListMatHangs().FirstOrDefault(hang => hang.Id == x.IdmatHang)?.IddonViTinh)
                        ?.TenDvt);
            }
        }

        private void btn_NgayChi_Click(object sender, EventArgs e)
        {
            _flagOfHoaDonNhap = 1;
            FillDataHoaDonNhap(Convert.ToDateTime(dtp_HoaDonNhap.Text));
            double? totalOfHoaDonNhap = 0;
            foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps().Where(c =>
                c.NgayTao.Day == Convert.ToDateTime(dtp_HoaDonNhap.Text).Day &&
                c.NgayTao.Month == Convert.ToDateTime(dtp_HoaDonNhap.Text).Month &&
                c.NgayTao.Year == Convert.ToDateTime(dtp_HoaDonNhap.Text).Year))
            {
                totalOfHoaDonNhap += x.TienThanhToan;
            }

            lbl_chi.Text = totalOfHoaDonNhap + " VNĐ";
        }

        private void btn_ThangChi_Click(object sender, EventArgs e)
        {
            _flagOfHoaDonNhap = 2;
            FillDataHoaDonNhap(Convert.ToDateTime(dtp_HoaDonNhap.Text));
            double? totalOfHoaDonNhap = 0;
            foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps().Where(c =>
                c.NgayTao.Month == Convert.ToDateTime(dtp_HoaDonNhap.Text).Month &&
                c.NgayTao.Year == Convert.ToDateTime(dtp_HoaDonNhap.Text).Year))
            {
                totalOfHoaDonNhap += x.TienThanhToan;
            }

            lbl_chi.Text = totalOfHoaDonNhap + " VNĐ";
        }

        private void btn_QuiChi_Click(object sender, EventArgs e)
        {
            _flagOfHoaDonNhap = 3;
            FillDataHoaDonNhap(Convert.ToDateTime(dtp_HoaDonNhap.Text));
            double? totalOfHoaDonNhap = 0;
            foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps().Where(c =>
                c.NgayTao.Year == Convert.ToDateTime(dtp_HoaDonNhap.Text).Year))
            {
                totalOfHoaDonNhap += x.TienThanhToan;
            }

            lbl_chi.Text = totalOfHoaDonNhap + " VNĐ";
        }

        private void btn_NgayThu_Click(object sender, EventArgs e)
        {
            _flagOfHoaDonBan = 1;
            FillDataHoaDonBan(Convert.ToDateTime(dtp_HoaDonXuat.Text));
            double? totalOfHoaDonBan = 0;
            foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang().Where(c =>
                c.NgayTao?.Day == Convert.ToDateTime(dtp_HoaDonXuat.Text).Day &&
                c.NgayTao?.Month == Convert.ToDateTime(dtp_HoaDonXuat.Text).Month &&
                c.NgayTao?.Year == Convert.ToDateTime(dtp_HoaDonXuat.Text).Year))
            {
                totalOfHoaDonBan += x.DonGiaPhong;
            }

            lbl_Thu.Text = totalOfHoaDonBan + " VNĐ";
        }

        private void btn_ThangThu_Click(object sender, EventArgs e)
        {
            _flagOfHoaDonBan = 2;
            FillDataHoaDonBan(Convert.ToDateTime(dtp_HoaDonXuat.Text));
            double? totalOfHoaDonBan = 0;
            foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang().Where(c =>
                c.NgayTao?.Month == Convert.ToDateTime(dtp_HoaDonXuat.Text).Month &&
                c.NgayTao?.Year == Convert.ToDateTime(dtp_HoaDonXuat.Text).Year))
            {
                totalOfHoaDonBan += x.DonGiaPhong;
            }

            lbl_Thu.Text = totalOfHoaDonBan + " VNĐ";
        }

        private void btn_QuiThu_Click(object sender, EventArgs e)
        {
            _flagOfHoaDonBan = 3;
            FillDataHoaDonBan(Convert.ToDateTime(dtp_HoaDonXuat.Text));
            double? totalOfHoaDonBan = 0;
            foreach (var x in _hoaDonBanHangService.sendlstHoaDonBanHang().Where(c =>
                c.NgayTao?.Year == Convert.ToDateTime(dtp_HoaDonXuat.Text).Year))
            {
                totalOfHoaDonBan += x.DonGiaPhong;
            }

            lbl_Thu.Text = totalOfHoaDonBan + " VNĐ";
        }

        private void dgrid_HoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == _hoaDonNhapService.GetListHoaDonNhaps().Count || e.RowIndex == -1) return;
            _iDHoaDonNhap = Convert.ToInt32(dgrid_HoaDonNhap.Rows[e.RowIndex].Cells[0].Value);
            var hoaDonNhap = _hoaDonNhapService.GetListHoaDonNhaps().FirstOrDefault(c => c.Id == _iDHoaDonNhap);
            if (hoaDonNhap != null)
            {
                txt_DonGiaNhap.Text = hoaDonNhap.TienThanhToan + " VNĐ";
                txt_MaHoaDonNhap.Text = hoaDonNhap.Id.ToString();
                txt_NhaCungCap.Text = _nhaCungCapService.GetListnNhaCungCapsFromDAL()
                    .FirstOrDefault(c => c.Id == hoaDonNhap.IdnhaCc)
                    ?.TenNcc;
                gbx_ChiTietHoaDonBan.Visible = false;
                gbx_ChiTietHoaDonNhap.Visible = true;
                FillDataChiTietHoaDonNhap(_iDHoaDonNhap);
            }
        }

        private void dgrid_HoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _hoaDonBanHangService.sendlstHoaDonBanHang().Count || e.RowIndex == -1) return;
            _idHoaDonBan = Convert.ToInt32(dgrid_HoaDonBan.Rows[e.RowIndex].Cells[0].Value);
            var hoaDonBan = _hoaDonBanHangService.sendlstHoaDonBanHang()
                .FirstOrDefault(c => c.IdhoaDon == _idHoaDonBan);
            if (hoaDonBan != null)
            {
                TimeSpan? datediff = hoaDonBan.ThoiGianKetThuc - hoaDonBan.ThoiGianBatDau;
                txt_MaHoaDonBan.Text = hoaDonBan.IdhoaDon.ToString();
                txt_MaPhong.Text = hoaDonBan.Idphong.ToString();
                txt_DonGiaBan.Text = hoaDonBan.DonGiaPhong.ToString();
                txt_CongThucTinh.Text = hoaDonBan.IdcongThucTinh.ToString();
                txt_ThoiGianDung.Text = datediff?.TotalHours.ToString(CultureInfo.InvariantCulture);
                gbx_ChiTietHoaDonNhap.Visible = false;
                gbx_ChiTietHoaDonBan.Visible = true;
                FillDataChiTietHoaDonBan(_idHoaDonBan);
            }
        }

    }
}
