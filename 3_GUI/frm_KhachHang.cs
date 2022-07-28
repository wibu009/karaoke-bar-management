using _1_DAL.Entities;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class frm_KhachHang : Form
    {
        private IBUS_HoaDonBanHang_Service _hoaDonBanHangService;
        private IBUS_KhachHang_Service _ibusKhachHang;
        private IBUS_LoaiPhong_Service _loaiPhongService;
        private HoaDonBanHang _hoaDonBanHang;
        private KhachHang _tblKhachHang;
        private IBUS_Phong_Service _phongService;
        private IBUS_CheckEverything _icheck;
        private string erorr = "CHÚ Ý 🤔🤔🤔";
        int x = 20, y = 9, a = 1;
        private int _idphong;
        Random ran = new Random();
        private string getmakhbygrid;
        public frm_KhachHang(int idPhong)
        {
            InitializeComponent();
            _hoaDonBanHangService = new BUS_HoaDonBanHang_Service();
            _hoaDonBanHang = new HoaDonBanHang();
            _ibusKhachHang = new BUS_KhachHang_Service();
            _loaiPhongService = new BUS_LoaiPhong_Service();
            _phongService = new BUS_Phong_Service();
            _tblKhachHang = new KhachHang();
            _icheck = new BUS_CheckEverything();
            _idphong = idPhong;
            getmakhbygrid = "";
            LoadDataKhachHang();
            khachquenclick();

        }
        void LoadDataKhachHang()
        {
            dgr_KhachHang.ColumnCount = 2;
            dgr_KhachHang.Columns[0].Name = "Mã KH";
            dgr_KhachHang.Columns[1].Name = "Họ tên";
            
            dgr_KhachHang.Rows.Clear();
            foreach (var x in _ibusKhachHang.GetlstKhachHangs())
            {
                dgr_KhachHang.Rows.Add(x.MaKh, x.Ho + " " + x.TenDem + " " + x.Ten);
            }
        }
        void FindNameKhachHang(string tenkh)
        {
            dgr_KhachHang.ColumnCount = 2;
            dgr_KhachHang.Columns[0].Name = "Mã KH";
            dgr_KhachHang.Columns[1].Name = "Họ tên";
            dgr_KhachHang.Rows.Clear();
            foreach (var x in _ibusKhachHang.FindNameKhachHang(tenkh))
            {
                dgr_KhachHang.Rows.Add(x.MaKh, x.Ho + " " + x.TenDem + " " + x.Ten);
            }
        }
        public bool checkLoi()
        {
            DialogResult dn;
            if (_icheck.CheckNull(txt_Ho.Text) || _icheck.CheckNull(txt_Ten.Text) ||
                _icheck.CheckNull(txt_TenDem.Text) || _icheck.CheckNull(txt_DienThoai.Text))
            {
                dn = MessageBox.Show("Dữ liệu đang để trống !!! \nVui lòng nhập lại 😉", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_icheck.CheckSo(txt_DienThoai.Text))
            {
                dn = MessageBox.Show("Số điện thoại không được phép có chữ cái !!! \nVui lòng nhập lại 😉", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_DienThoai.Focus();
                return false;
            }
            return true;
        }

        private void dgr_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == _ibusKhachHang.GetlstKhachHangs().Count() || rd == -1) return;
            _tblKhachHang = _ibusKhachHang.GetlstKhachHangs().FirstOrDefault(c => c.MaKh == dgr_KhachHang.Rows[rd].Cells[0].Value.ToString());
            getmakhbygrid = dgr_KhachHang.Rows[rd].Cells[0].Value.ToString();
            txt_Ho.Text = _tblKhachHang.Ho;
            txt_TenDem.Text = _tblKhachHang.TenDem;
            txt_Ten.Text = _tblKhachHang.Ten;
            rbtn_Nam.Checked = _tblKhachHang.GioiTinh == 1 ? true : false;
            rbtn_Nu.Checked = _tblKhachHang.GioiTinh == 2 ? true : false;
            txt_DienThoai.Text = _tblKhachHang.DienThoai;
            cbx_HĐ.Checked = _tblKhachHang.IdtranngThai == 1 ? true : false;
            cbx_KHĐ.Checked = _tblKhachHang.IdtranngThai == 2 ? true : false;
        }
        private void Clearform()
        {
            txt_Ho.Text = "";
            txt_TenDem.Text = "";
            txt_Ten.Text = "";
            rbtn_Nam.Checked = false;
            rbtn_Nu.Checked = false;
            txt_DienThoai.Text = "";
            cbx_HĐ.Checked = false;
            cbx_KHĐ.Checked = false;
        }

        int getmakh()
        {
            int max = 0;
            foreach (var x in _ibusKhachHang.GetlstKhachHangs())
            {
                if (int.Parse(x.MaKh)>max)
                {
                    max = int.Parse(x.MaKh);
                }
            }
            return max+1;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (checkLoi() == false)
            {
                return;
            }
            KhachHang kha = new KhachHang();
            kha.MaKh = "1";
            if (_ibusKhachHang.GetlstKhachHangs().ToList().Count!=0)
            {
                kha.MaKh = getmakh().ToString();
            }
            kha.Ho = txt_Ho.Text;
            kha.TenDem = txt_TenDem.Text;
            kha.Ten = txt_Ten.Text;
            kha.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            kha.DienThoai = txt_DienThoai.Text;
            kha.IdtranngThai = cbx_HĐ.Checked ? 1 : 0;
            if (MessageBox.Show("Bạn có muốn 🤔 Thêm Khách Hàng 🤔 không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_ibusKhachHang.GetlstKhachHangs().Where(c => c.MaKh == kha.MaKh).ToList().Count != 0)
                {
                    MessageBox.Show("MAKH đã tồn tại");
                    return;
                }
                _ibusKhachHang.Add(kha);
                LoadDataKhachHang();
                khachquenclick();
                getmakhbygrid = kha.MaKh;
            }
        }

        private void btn_khachmoi_Click(object sender, EventArgs e)
        {
            khachmoiclick();
        }

        private void khachmoiclick()
        {
            Clearform();
            textBox1.Visible = false;
            dgr_KhachHang.Visible = false;
            btn_Them.Visible = true;
            pictureBox2.Visible = true;
            btn_xacnhan.Visible = false;
            pictureBox1.Visible = false;
            txt_Ho.Enabled = true;
            txt_TenDem.Enabled = true;
            txt_Ten.Enabled = true;
            txt_DienThoai.Enabled = true;

        }
        private void btn_khachquen_Click(object sender, EventArgs e)
        {
           khachquenclick();
        }

        private void khachquenclick()
        {
            textBox1.Visible = true;
            dgr_KhachHang.Visible = true;
            btn_Them.Visible = false;
            pictureBox2.Visible = false;
            btn_xacnhan.Visible = true;
            pictureBox1.Visible = true;
            txt_Ho.Enabled = false;
            txt_TenDem.Enabled = false;
            txt_Ten.Enabled = false;
            txt_DienThoai.Enabled = false;
        }
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
           
        }


        private void btn_xacnhan_Click_1(object sender, EventArgs e)
        {
            DialogResult hoi;
            hoi = MessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (hoi == DialogResult.Yes)
            {
                if (getmakhbygrid=="") return;
                if (_hoaDonBanHangService.sendlstHoaDonBanHang().Count == 0)
                {
                    _hoaDonBanHang.IdhoaDon = 1;
                }
                else
                {
                    _hoaDonBanHang.IdhoaDon = _hoaDonBanHangService.sendlstHoaDonBanHang().Max(x => x.IdhoaDon + 1);
                }
                _hoaDonBanHang.Idphong = _idphong;
                _hoaDonBanHang.IdmaKh = getmakhbygrid;/*_ikhachHang_Service.GetlstKhachHangs().FirstOrDefault(x => x.MaKh == cmb_loaiPhong.Text).Id;*/
                _hoaDonBanHang.IdmaNv = Frm_Main.sendnhanvien().MaNv;
                _hoaDonBanHang.ThoiGianBatDau = DateTime.Now;
                _hoaDonBanHang.DonGiaPhong = _loaiPhongService.sendlstLoaiPhong().FirstOrDefault(x => x.Id == _phongService.sendlstPhong().FirstOrDefault(x => x.Id == _hoaDonBanHang.Idphong).IdloaiPhong).DonGia;
                _hoaDonBanHang.NguoiTao = Frm_Main.sendnhanvien().MaNv;
                _hoaDonBanHang.NgayTao = DateTime.Now;
                _hoaDonBanHang.NguoiCapNhap = Frm_Main.sendnhanvien().MaNv;
                _hoaDonBanHang.NgayCapNhap = DateTime.Now;
                _hoaDonBanHang.IdtranngThai = 1;
                _hoaDonBanHangService.Add(_hoaDonBanHang);
                var phong = _phongService.Find(_idphong).FirstOrDefault();
                phong.TrangThai = 3;
                _phongService.Update(phong);

                MessageBox.Show("Đặt phòng thành công", "Thông báo");
                this.Close();
                Frm_Main.load();
            }
        }
            private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            FindNameKhachHang(textBox1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                lbl_Timer.Location = new Point(x, y);
                if (x >= 704)
                {
                    a = -1;
                    lbl_Timer.ForeColor = Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
                }
                if (x <= 20)
                {
                    a = 1;
                    lbl_Timer.ForeColor = Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
