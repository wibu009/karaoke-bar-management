using System;
using System.Linq;
using System.Windows.Forms;
using _2_BUS.BUS_MatHang_Service;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_MatHang_Service;
using _2_BUS.IBUS_Service;

namespace _3_GUI
{
    public partial class frm_HoaDonNhap : Form
    {
        private readonly IBUS_ChiTietHoaDonNhap_Service _chiTietHoaDonNhapService;
        private readonly IBUS_DonViTinh_Service _donViTinhService;
        private readonly IBUS_HoaDonNhap_Service _hoaDonNhapService;
        private int _idChiTietHoaDonNhap;
        private int _iDHoaDon;
        private int _idMatHang;
        private readonly string _iDNhanVien;
        private readonly IBUS_NhaCungCap_Service _nhaCungCapService;
        private readonly IBUS_RE_MatHang_Service _reMatHangService;

        //tạo form không có tham số
        public frm_HoaDonNhap()
        {
            InitializeComponent();
            _chiTietHoaDonNhapService = new BUS_ChiTietHoaDonNhap_Service();
            _hoaDonNhapService = new BUS_HoaDonNhap_Service();
            _reMatHangService = new BUS_RE_MatHang_Service();
            _nhaCungCapService = new BUS_NhaCungCap_Service();
            _donViTinhService = new BUS_DonViTinh_Service();
            _iDNhanVien = Frm_Main.sendnhanvien().MaNv;
            txt_TienThanhToan.Text = "0";
            gbx_ChiTietHoaDon.Enabled = false;
            gbx_NhaCungCap.Enabled = false;
            txt_MaHoaDon.Enabled = false;
            txt_TienThanhToan.Enabled = false;
            dtp_NgayTao.Enabled = false;
            dgrid_MatHang.Enabled = false;
            gbx_ChiTietHoaDon.Visible = false;
            FillDataNhaCungCapToCBX();
            FillDataHoaDontoGrid();
            FillDataMatHangToGrid();
            FillDataHangCanNhap(DateTime.Now);
        }

        

        public void FillDataNhaCungCapToCBX()
        {
            cbx_NhaCungCap.Items.Clear();
            foreach (var x in _nhaCungCapService.GetListnNhaCungCapsFromDAL()) cbx_NhaCungCap.Items.Add(x.Id);

            cbx_NhaCungCap.SelectedIndex = 0;
        }

        public void FillDataHangCanNhap(DateTime ngay)
        {
            dgrid_HangCanCapNhat.Columns.Clear();
            dgrid_HangCanCapNhat.ColumnCount = 4;
            dgrid_HangCanCapNhat.Columns[0].Name = "ID hàng";
            dgrid_HangCanCapNhat.Columns[1].Name = "Tên hàng";
            dgrid_HangCanCapNhat.Columns[2].Name = "Số lượng cần cập nhật";
            dgrid_HangCanCapNhat.Columns[3].Name = "Đơn vị tính";
            //Lấy các hóa đơn trùng ngày
            var hoaDonCanNhapKho = _hoaDonNhapService.GetListHoaDonNhaps().Where(c =>
                c.NgayTao.Day == ngay.Day && c.NgayTao.Month == ngay.Month && c.NgayTao.Year == ngay.Year);

            //Lấy danh sách hàng
            foreach (var x in _reMatHangService.GetListMatHangs())
            {
                //tạo biến tổng để tính số lượng
                int? total = 0;
                //dùng x2 vòng lặp để gọi ra các chi tiết hóa đơn có mã mặt hàng và mã hóa đơn trùng với danh sách hóa đơn đã tìm kiếm ở bên trên
                foreach (var y in hoaDonCanNhapKho)
                foreach (var z in _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                    .Where(c => c.IdhoaDon == y.Id && c.IdmatHang == x.Id))
                    total += z.SoLuong;
                var donViTInh = _donViTinhService.GetlstDonViTinhs()
                    .FirstOrDefault(c => c.Id == x.IddonViTinh);
                if (donViTInh != null) dgrid_HangCanCapNhat.Rows.Add(x.Id, x.TenMatHang, total, donViTInh.TenDvt);
            }
        }

        public void FillDataChiTietHoaDon(int? idHoaDon)
        {
            dgrid_ChiTietHoaDonNhap.Columns.Clear();
            dgrid_ChiTietHoaDonNhap.ColumnCount = 7;
            dgrid_ChiTietHoaDonNhap.Columns[0].Name = "Mã chi tiết hóa đơn";
            dgrid_ChiTietHoaDonNhap.Columns[1].Name = "Mã hóa đơn";
            dgrid_ChiTietHoaDonNhap.Columns[2].Name = "Mã mặt hàng";
            dgrid_ChiTietHoaDonNhap.Columns[3].Name = "Tên mặt hàng";
            dgrid_ChiTietHoaDonNhap.Columns[4].Name = "Số lượng";
            dgrid_ChiTietHoaDonNhap.Columns[5].Name = "Đơn vị tính";
            dgrid_ChiTietHoaDonNhap.Columns[6].Name = "Đơn giá";

            dgrid_ChiTietHoaDonNhap.Columns[0].Visible = false;
            dgrid_ChiTietHoaDonNhap.Columns[1].Visible = false;
            dgrid_ChiTietHoaDonNhap.Columns[2].Visible = false;
            //check id hóa đơn truyền vào có bị null hay không
            if (idHoaDon != null)
                foreach (var x in _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                    .Where(c => c.IdhoaDon == _iDHoaDon))
                {
                    var matHang = _reMatHangService.GetListMatHangs().FirstOrDefault(c => c.Id == x.IdmatHang);
                    var donViTInh = _donViTinhService.GetlstDonViTinhs()
                        .FirstOrDefault(c => matHang != null && c.Id == matHang.IddonViTinh);
                    if (donViTInh != null && matHang != null)
                        dgrid_ChiTietHoaDonNhap.Rows.Add(x.IdchiTietHoaDonNhap, x.IdhoaDon, x.IdmatHang,
                            matHang.TenMatHang, x.SoLuong,
                            donViTInh.TenDvt, x.DonGiaNhap);
                }

            var btnXoa = new DataGridViewButtonColumn();
            btnXoa.Text = "Xóa";
            btnXoa.Name = "Xóa mặt hàng";
            btnXoa.UseColumnTextForButtonValue = true;
            dgrid_ChiTietHoaDonNhap.Columns.Add(btnXoa);
        }

        public void FillDataHoaDontoGrid()
        {
            dgrid_HoaDonNhap.Columns.Clear();
            dgrid_HoaDonNhap.ColumnCount = 7;
            dgrid_HoaDonNhap.Columns[0].Name = "Mã hóa đơn";
            dgrid_HoaDonNhap.Columns[1].Name = "Tiền thanh toán";
            dgrid_HoaDonNhap.Columns[2].Name = "Mã nhà cung cấp";
            dgrid_HoaDonNhap.Columns[3].Name = "Ngày tạo";
            dgrid_HoaDonNhap.Columns[4].Name = "Người tạo";
            dgrid_HoaDonNhap.Columns[5].Name = "Ngày cập nhật";
            dgrid_HoaDonNhap.Columns[6].Name = "Người cập nhật";


            dgrid_HoaDonNhap.Columns[5].Visible = false;
            dgrid_HoaDonNhap.Columns[6].Visible = false;
            dgrid_HoaDonNhap.Columns[2].Visible = false;
            foreach (var x in _hoaDonNhapService.GetListHoaDonNhaps())
                dgrid_HoaDonNhap.Rows.Add(x.Id, x.TienThanhToan, x.IdnhaCc, x.NgayTao, x.NguoiTao, x.NgayCapNhap,
                    x.NguoiCapNhap);

            var btnCapNhat = new DataGridViewButtonColumn();
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.Name = "Update";
            btnCapNhat.UseColumnTextForButtonValue = true;
            dgrid_HoaDonNhap.Columns.Add(btnCapNhat);
        }

        public void FillDataMatHangToGrid()
        {
            dgrid_MatHang.Columns.Clear();
            dgrid_MatHang.ColumnCount = 5;
            dgrid_MatHang.Columns[0].Name = "Mã mặt hàng";
            dgrid_MatHang.Columns[1].Name = "Tên mặt hàng";
            dgrid_MatHang.Columns[2].Name = "Đơn giá";
            dgrid_MatHang.Columns[3].Name = "Số lượng hiện có";
            dgrid_MatHang.Columns[4].Name = "Đơn vị tính";
            dgrid_MatHang.Columns[0].Visible = false;
            foreach (var x in _reMatHangService.GetListMatHangs())
                dgrid_MatHang.Rows.Add(x.Id, x.TenMatHang, x.DonGia, x.SoLuong, _donViTinhService.GetlstDonViTinhs().FirstOrDefault(c => c.Id == x.IddonViTinh)?.TenDvt);

            var btnThem = new DataGridViewButtonColumn();
            btnThem.Text = "Thêm";
            btnThem.Name = "Thêm vào hóa đơn";
            btnThem.UseColumnTextForButtonValue = true;
            dgrid_MatHang.Columns.Add(btnThem);
        }

        private void btn_AddHoaDon_Click(object sender, EventArgs e)
        {
            _hoaDonNhapService.AddHoaDonNhapTo(_iDNhanVien, null, Convert.ToInt64(txt_TienThanhToan.Text), _iDNhanVien,
                _iDNhanVien);
            var ngayHoaDonNhap = _hoaDonNhapService.GetListHoaDonNhaps().Max(c => c.NgayTao);
            if (_hoaDonNhapService != null)
                _iDHoaDon = _hoaDonNhapService.GetListHoaDonNhaps().FirstOrDefault(c => c.NgayTao == ngayHoaDonNhap).Id;
            gbx_ChiTietHoaDon.Enabled = true;
            gbx_HoaDon.Enabled = false;
            dgrid_MatHang.Enabled = true;
            txt_MaHoaDon.Text = null;
            txt_TienThanhToan.Text = "0";
            gbx_ChiTietHoaDon.Visible = true;
            dgrid_ChiTietHoaDonNhap.Columns.Clear();
        }

        private void btn_AddNhaCungCap_Click(object sender, EventArgs e)
        {
            _nhaCungCapService.AddNhaCungCap(txt_TenNhaCungCap.Text, _iDNhanVien, _iDNhanVien, txt_SoDienThoai.Text,
                txt_Email.Text, txt_DiaChi.Text);
            FillDataNhaCungCapToCBX();
            chk_NhaCungCap.Checked = false;
            cbx_NhaCungCap.SelectedIndex = _nhaCungCapService.GetListnNhaCungCapsFromDAL().Count - 1;
        }

        private void cbx_NhaCungCap_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var nhaCungCap = _nhaCungCapService.GetListnNhaCungCapsFromDAL()
                .FirstOrDefault(c => c.Id == Convert.ToInt32(cbx_NhaCungCap.SelectedItem.ToString()));
            if (nhaCungCap != null)
            {
                txt_TenNhaCungCap.Text = nhaCungCap.TenNcc;
                txt_SoDienThoai.Text = nhaCungCap.DienThoai;
                txt_DiaChi.Text = nhaCungCap.DiaChi;
                txt_Email.Text = nhaCungCap.Email;
            }
        }

        private void chk_NhaCungCap_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_NhaCungCap.Checked)
            {
                cbx_NhaCungCap.Enabled = false;
                gbx_NhaCungCap.Enabled = true;
            }
            else
            {
                cbx_NhaCungCap.Enabled = true;
                gbx_NhaCungCap.Enabled = false;
            }
        }

        private void dgrid_HoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _hoaDonNhapService.GetListHoaDonNhaps().Count || e.RowIndex == -1) return;
            _iDHoaDon = Convert.ToInt32(dgrid_HoaDonNhap.Rows[e.RowIndex].Cells[0].Value);
            txt_MaHoaDon.Text = _iDHoaDon.ToString();
            txt_TienThanhToan.Text = dgrid_HoaDonNhap.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbx_NhaCungCap.Text = dgrid_HoaDonNhap.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtp_NgayTao.Text = dgrid_HoaDonNhap.Rows[e.RowIndex].Cells[3].Value.ToString();
            gbx_ChiTietHoaDon.Visible = true;
            FillDataChiTietHoaDon(_iDHoaDon);
        }

        private void dgrid_HoaDonNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex==-1) return;
            if (dgrid_HoaDonNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected &&
                dgrid_HoaDonNhap.Columns[e.ColumnIndex].Name == "Update")
            {
                gbx_ChiTietHoaDon.Enabled = true;
                gbx_HoaDon.Enabled = false;
                dgrid_MatHang.Enabled = true;
            }
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            gbx_ChiTietHoaDon.Enabled = false;
            gbx_HoaDon.Enabled = true;
            dgrid_MatHang.Enabled = false;
            gbx_ChiTietHoaDon.Visible = false;
            if (_hoaDonNhapService.UpdateHoaDonNhap(_iDHoaDon, _iDNhanVien, Convert.ToInt32(cbx_NhaCungCap.Text),
                Convert.ToInt64(txt_TienThanhToan.Text), _iDNhanVien))
            {
                MessageBox.Show("Đã xác nhận hóa đơn thành công!!!", "Admin said", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                FillDataHoaDontoGrid();
                FillDataHangCanNhap(DateTime.Now);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            gbx_ChiTietHoaDon.Enabled = false;
            gbx_HoaDon.Enabled = true;
            gbx_MatHang.Enabled = false;
            foreach (var x in _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps().Where(c => c.IdhoaDon == _iDHoaDon))
                _chiTietHoaDonNhapService.DeleteChiTietHoaDonNhap(x.IdchiTietHoaDonNhap);
            _hoaDonNhapService.DeleteHoaDonNhap(_iDHoaDon);
            dgrid_ChiTietHoaDonNhap.Columns.Clear();
            FillDataHoaDontoGrid();
            FillDataHangCanNhap(DateTime.Now);
        }

        private void dgrid_MatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _hoaDonNhapService.GetListHoaDonNhaps().Count || e.RowIndex == -1) return;
            _idMatHang = Convert.ToInt32(dgrid_MatHang.Rows[e.RowIndex].Cells[0].Value);
        }

        private void dgrid_MatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex==-1) return;
            if (dgrid_MatHang.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected &&
                dgrid_MatHang.Columns[e.ColumnIndex].Name == "Thêm vào hóa đơn")
            {
                if (_chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                    .Any(c => c.IdhoaDon == _iDHoaDon && c.IdmatHang == _idMatHang))
                {
                    var chiTietHoaDon = _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                        .FirstOrDefault(c => c.IdhoaDon == _iDHoaDon && c.IdmatHang == _idMatHang);
                    if (chiTietHoaDon != null)
                        _chiTietHoaDonNhapService.UpdateChiTietHoaDonNhap(chiTietHoaDon.IdchiTietHoaDonNhap,
                            chiTietHoaDon.IdhoaDon, chiTietHoaDon.IdmatHang, chiTietHoaDon.SoLuong + 1,
                            _reMatHangService.GetListMatHangs().FirstOrDefault(c => c.Id == _idMatHang)?.DonGia *
                            (chiTietHoaDon.SoLuong + 1));
                }
                else
                {
                    var matHang = _reMatHangService.GetListMatHangs().FirstOrDefault(c => c.Id == _idMatHang);
                    if (matHang != null)
                        _chiTietHoaDonNhapService.AddChiTietHoaDonNhap(_iDHoaDon, _idMatHang, 1, matHang.DonGia);
                }

                double? sum = 0;
                foreach (var x in _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                    .Where(c => c.IdhoaDon == _iDHoaDon)) sum += x.DonGiaNhap;
                txt_TienThanhToan.Text = sum.ToString();
                FillDataChiTietHoaDon(_iDHoaDon);
            }
        }

        private void dgrid_ChiTietHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                .Count(c => c.IdhoaDon == _iDHoaDon) || e.RowIndex == -1) return;
            _idChiTietHoaDonNhap = Convert.ToInt32(dgrid_ChiTietHoaDonNhap.Rows[e.RowIndex].Cells[0].Value);
        }

        private void dgrid_ChiTietHoaDonNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrid_ChiTietHoaDonNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected &&
                dgrid_ChiTietHoaDonNhap.Columns[e.ColumnIndex].Name == "Xóa mặt hàng")
            {
                var chiTietHoaDon = _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                    .FirstOrDefault(c => c.IdchiTietHoaDonNhap == _idChiTietHoaDonNhap);
                if (chiTietHoaDon != null)
                {
                    _chiTietHoaDonNhapService.UpdateChiTietHoaDonNhap(chiTietHoaDon.IdchiTietHoaDonNhap,
                        chiTietHoaDon.IdhoaDon, chiTietHoaDon.IdmatHang, chiTietHoaDon.SoLuong - 1,
                        _reMatHangService.GetListMatHangs().FirstOrDefault(c => c.Id == chiTietHoaDon.IdmatHang)
                            ?.DonGia * (chiTietHoaDon.SoLuong - 1));
                    double? sum = 0;
                    foreach (var x in _chiTietHoaDonNhapService.GetListChiTietHoaDonNhaps()
                        .Where(c => c.IdhoaDon == _iDHoaDon)) sum += x.DonGiaNhap;
                    txt_TienThanhToan.Text = sum.ToString();
                    FillDataChiTietHoaDon(_iDHoaDon);
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            FillDataHangCanNhap(Convert.ToDateTime(dtp_NhapKho.Text));
        }

        private void btn_suattncc_Click(object sender, EventArgs e)
        {
            Frm_Main.loadNhacungcap();
        }
    }
}