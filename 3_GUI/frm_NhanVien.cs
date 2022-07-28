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
    public partial class frm_NhanVien : Form
    {
        private IBUS_NhanVien_Service _ibusNhanVien;
        private IBUS_CheckEverything _icheck;
        private IBUS_Login_Service _ibus_Login_Service;
        private NhanVien _tblNhanVien;
        private string erorr = "Aiizaaa... Lỗi rồi kìa 😂";
        int x = 20, y = 9, a = 1;
        Random ran = new Random();
        public frm_NhanVien()
        {
            InitializeComponent();
            _ibusNhanVien = new BUS_NhanVien_Service();
            _icheck = new BUS_CheckEverything();
            _tblNhanVien = new NhanVien();
            _ibus_Login_Service = new BUS_Login_Service();
            LoadCbxChucVu();
            loadquyen();
            LoadDgrNhanVien();
            checkBox1.Checked = true;
        }
        void loadquyen()
        {
            if (Frm_Main.sendnhanvien().IdchucVu != 1)
            {
                groupBox1.Visible = false;
                panel1.Visible = false;
                panel_dgr_NhanVien.Dock = DockStyle.Fill;
            }
        }
        void LoadCbxChucVu()
        {
            foreach (var x in _ibusNhanVien.GetlstChucVus())
            {
                cbox_ChucVu.Items.Add(x.TenChucVu);
            }
            cbox_ChucVu.SelectedIndex = -1;
        }
        void LoadDgrNhanVien()
        {
            dgr_NhanVien.ColumnCount = 8;
            dgr_NhanVien.Columns[0].Name = "Mã NV";
            dgr_NhanVien.Columns[1].Name = "Họ Và Tên";
            dgr_NhanVien.Columns[2].Name = "Email";
            dgr_NhanVien.Columns[3].Name = "Giới Tính";
            dgr_NhanVien.Columns[4].Name = "Chức Vụ";
            dgr_NhanVien.Columns[5].Name = "Điện Thoại";
            dgr_NhanVien.Columns[6].Name = "CCCD";
            dgr_NhanVien.Columns[7].Name = "Địa Chỉ";
            dgr_NhanVien.Rows.Clear();
            foreach (var x in _ibusNhanVien.GetlstNhanViens().Where(c=>c.IdtranngThai==1))
            {
                var chucvu = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.Id == x.IdchucVu);
                dgr_NhanVien.Rows.Add(x.MaNv, x.Ho + " " + x.TenDem + " " + x.Ten, x.Username ,x.GioiTinh == 1 ? "Nam" : "Nữ", chucvu.TenChucVu, x.DienThoai,
                                        x.Cmnd, x.DiaChi);
            }
        }
        void LoadDgrNhanVienByFindName(string tennv)
        {
            dgr_NhanVien.ColumnCount = 8;
            dgr_NhanVien.Columns[0].Name = "Mã NV";
            dgr_NhanVien.Columns[1].Name = "Họ Và Tên";
            dgr_NhanVien.Columns[2].Name = "Email";
            dgr_NhanVien.Columns[3].Name = "Giới Tính";
            dgr_NhanVien.Columns[4].Name = "Chức Vụ";
            dgr_NhanVien.Columns[5].Name = "Điện Thoại";
            dgr_NhanVien.Columns[6].Name = "CCCD";
            dgr_NhanVien.Columns[7].Name = "Địa Chỉ";
            dgr_NhanVien.Rows.Clear();
            foreach (var x in _ibusNhanVien.FindName(tennv))
            {
                var chucvu = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.Id == x.IdchucVu);
                dgr_NhanVien.Rows.Add(x.MaNv, x.Ho + " " + x.TenDem + " " + x.Ten, x.Username, x.GioiTinh == 1 ? "Nam" : "Nữ",
                                        chucvu.TenChucVu, x.DienThoai, x.Cmnd, x.DiaChi);
            }
        }
        private void ClearForm()
        {
            
            txt_Ho.Text = "";
            txt_TenDem.Text = "";
            txt_Ten.Text = "";
            txt_EmailLogin.Text = "";
            rbtn_Nam.Checked = false;
            rbtn_Nu.Checked = false;
            txt_CCCD.Text = "";
            txt_DiaChi.Text = "";
            txt_DienThoai.Text = "";
            cbox_ChucVu.Text = "";
        }

        #region CRUD Nhân Viên
        private void dgr_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == _ibusNhanVien.GetlstNhanViens().Count || rd == -1) return;
            _tblNhanVien = _ibusNhanVien.GetlstNhanViens().FirstOrDefault(c => c.MaNv ==
                    dgr_NhanVien.Rows[rd].Cells[0].Value.ToString());

            
            txt_Ho.Text = _tblNhanVien.Ho.ToString();
            txt_TenDem.Text = _tblNhanVien.TenDem.ToString();
            txt_Ten.Text = _tblNhanVien.Ten.ToString();
            txt_EmailLogin.Text = dgr_NhanVien.Rows[rd].Cells[2].Value.ToString();
            rbtn_Nam.Checked = dgr_NhanVien.Rows[rd].Cells[3].Value.ToString() == "Nam" ? true : false;
            rbtn_Nu.Checked = dgr_NhanVien.Rows[rd].Cells[3].Value.ToString() == "Nữ" ? true : false;
            cbox_ChucVu.Text = dgr_NhanVien.Rows[rd].Cells[4].Value.ToString();
            txt_DienThoai.Text = dgr_NhanVien.Rows[rd].Cells[5].Value.ToString();
            txt_CCCD.Text = dgr_NhanVien.Rows[rd].Cells[6].Value.ToString();
            txt_DiaChi.Text = dgr_NhanVien.Rows[rd].Cells[7].Value.ToString();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckLoiEverything() == false)
            {
                return;
            }
            NhanVien nva = new NhanVien();
            nva.MaNv = "1";
            if (_ibusNhanVien.GetlstNhanViens().Count!=0)
            {
                nva.MaNv = _ibusNhanVien.GetlstNhanViens().Max(c => Convert.ToInt32(c.MaNv)+1).ToString();
            }
            nva.Ho = txt_Ho.Text;
            nva.TenDem = txt_TenDem.Text;
            nva.Ten = txt_Ten.Text;
            nva.Username = txt_EmailLogin.Text;
            nva.Password = _ibus_Login_Service.MaHoaPass(_tblNhanVien.Password);
            nva.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            nva.IdchucVuNavigation = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.TenChucVu == cbox_ChucVu.Text);
            nva.DienThoai = txt_DienThoai.Text;
            nva.Cmnd = txt_CCCD.Text;
            nva.DiaChi = txt_DiaChi.Text;
            nva.IdtranngThai = checkBox1.Checked ? 1 : 0;
            if (MessageBox.Show("Bạn có muốn 🤔 Thêm Nhân viên 🤔 không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ibusNhanVien.Add(nva);
                MessageBox.Show("Thêm thành công 😉😉😉!", "Thông báo 😁😁😁");
            }
            LoadDgrNhanVien();
            ClearForm();
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (CheckLoiEverything() == false)
            {
                return;
            }
            _tblNhanVien.Ho = txt_Ho.Text;
            _tblNhanVien.TenDem = txt_TenDem.Text;
            _tblNhanVien.Ten = txt_Ten.Text;
            _tblNhanVien.Username = txt_EmailLogin.Text;
            _tblNhanVien.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            _tblNhanVien.IdchucVuNavigation = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.TenChucVu == cbox_ChucVu.Text);
            _tblNhanVien.DienThoai = txt_DienThoai.Text;
            _tblNhanVien.Cmnd = txt_CCCD.Text;
            _tblNhanVien.DiaChi = txt_DiaChi.Text;
            _tblNhanVien.IdtranngThai = checkBox1.Checked?1:0;
            if (MessageBox.Show("Bạn có muốn 🤔 Sửa Nhân viên 🤔 không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ibusNhanVien.Update(_tblNhanVien);
                MessageBox.Show("Sửa thành công 😉😉😉!", "Thông báo 😁😁😁");
            }
            LoadDgrNhanVien();
            ClearForm();
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn 🤔 Xóa Nhân viên 🤔 không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _tblNhanVien.IdtranngThai = 0;
                _ibusNhanVien.Update(_tblNhanVien);
                MessageBox.Show("Xóa thành công 😉😉😉!", "Thông báo 😁😁😁");
            }
            LoadDgrNhanVien();
            ClearForm();
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            _ibusNhanVien.Save(_tblNhanVien);
            ClearForm();
        }
        private void txt_SearchNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDgrNhanVienByFindName(txt_SearchNhanVien.Text);
        }
        private void btn_THOAT_Click(object sender, EventArgs e)
        {
            DialogResult dn;
            dn = MessageBox.Show("Bạn có muốn 🤔 Thoát Nhân Viên 🤔 ra khỏi chương trình không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dn == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        #region Check lỗi everything
        public bool CheckLoiEverything()
        {
            DialogResult dn;
            if (_icheck.CheckNull(txt_Ho.Text) || _icheck.CheckNull(txt_TenDem.Text) ||
                _icheck.CheckNull(txt_Ten.Text) || _icheck.CheckNull(cbox_ChucVu.Text) || _icheck.CheckNull(txt_DienThoai.Text) ||
                _icheck.CheckNull(txt_CCCD.Text) || _icheck.CheckNull(txt_DiaChi.Text) || _icheck.CheckNull(txt_EmailLogin.Text))
            {
                dn = MessageBox.Show("Dữ liệu đang để trống !!! \nVui lòng nhập lại 😉", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_icheck.CheckSo(txt_DienThoai.Text) || _icheck.CheckSo(txt_CCCD.Text))
            {
                dn = MessageBox.Show("Số điện thoại 😵 hoặc\nCăn cước công dân 😵 \n 👉 KHÔNG ĐƯỢC PHÉP NHẬP CHỮ !!! \nVui lòng nhập lại 😉", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_DienThoai.Focus();
                txt_CCCD.Focus();
                return false;
            }
            if (_icheck.CheckString(txt_Ho.Text) || _icheck.CheckString(txt_TenDem.Text) || _icheck.CheckString(txt_Ten.Text))
            {
                dn = MessageBox.Show("Họ nhân viên 😵 \n Tên đệm của nhân viên 😵 \n Tên của nhân viên 😵 \n Không được phép nhập số !!!\nVui lòng nhập lại 😉", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Lọc quyền chức vụ
        private void rbtn_LocNone_CheckedChanged(object sender, EventArgs e)
        {
            var loc = (from a in _ibusNhanVien.GetlstNhanViens()
                       where a.IdchucVu == 1 || a.IdchucVu == 2 || a.IdchucVu == 3
                       select new { a.MaNv, a.Ho, a.TenDem, a.Ten, a.Username, a.GioiTinh, a.IdchucVu, 
                                    a.DienThoai, a.Cmnd, a.DiaChi }).ToList();

            dgr_NhanVien.ColumnCount = 8;
            dgr_NhanVien.Columns[0].Name = "Mã NV";
            dgr_NhanVien.Columns[1].Name = "Họ Và Tên";
            dgr_NhanVien.Columns[2].Name = "Email";
            dgr_NhanVien.Columns[3].Name = "Giới Tính";
            dgr_NhanVien.Columns[4].Name = "Chức Vụ";
            dgr_NhanVien.Columns[5].Name = "Điện Thoại";
            dgr_NhanVien.Columns[6].Name = "CCCD";
            dgr_NhanVien.Columns[7].Name = "Địa Chỉ";
            dgr_NhanVien.Rows.Clear();
            foreach (var x in loc)
            {
                var chucvu = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.Id == x.IdchucVu);
                dgr_NhanVien.Rows.Add(x.MaNv, x.Ho + " " + x.TenDem + " " + x.Ten, x.Username, x.GioiTinh == 1 ? "Nam" : "Nữ", chucvu.TenChucVu, x.DienThoai,
                                        x.Cmnd, x.DiaChi);
            }
        }
        private void rbtn_LocChucVu_CheckedChanged(object sender, EventArgs e)
        {
            var loc = (from a in _ibusNhanVien.GetlstNhanViens()
                       where a.IdchucVu == 1 
                       select new { a.MaNv, a.Ho, a.TenDem, a.Ten, a.Username, a.GioiTinh, a.IdchucVu, 
                                    a.DienThoai, a.Cmnd, a.DiaChi }).ToList();

            dgr_NhanVien.ColumnCount = 8;
            dgr_NhanVien.Columns[0].Name = "Mã NV";
            dgr_NhanVien.Columns[1].Name = "Họ Và Tên";
            dgr_NhanVien.Columns[2].Name = "Email";
            dgr_NhanVien.Columns[3].Name = "Giới Tính";
            dgr_NhanVien.Columns[4].Name = "Chức Vụ";
            dgr_NhanVien.Columns[5].Name = "Điện Thoại";
            dgr_NhanVien.Columns[6].Name = "CCCD";
            dgr_NhanVien.Columns[7].Name = "Địa Chỉ";
            dgr_NhanVien.Rows.Clear();
            foreach (var x in loc)
            {
                //var chucvu = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.Id == x.IdchucVu);
                dgr_NhanVien.Rows.Add(x.MaNv, x.Ho + " " + x.TenDem + " " + x.Ten, x.Username, x.GioiTinh == 1 ? "Nam" : "Nữ",
                                        x.IdchucVu == 1 ? "Admin" : "Nhân viên", x.DienThoai, x.Cmnd, x.DiaChi);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void rbtn_LocNhanvien_CheckedChanged(object sender, EventArgs e)
        {
            var loc = (from a in _ibusNhanVien.GetlstNhanViens()
                       where a.IdchucVu == 2
                       select new { a.MaNv, a.Ho, a.TenDem, a.Ten, a.Username, a.GioiTinh, a.IdchucVu, 
                                    a.DienThoai, a.Cmnd, a.DiaChi }).ToList();

            dgr_NhanVien.ColumnCount = 8;
            dgr_NhanVien.Columns[0].Name = "Mã NV";
            dgr_NhanVien.Columns[1].Name = "Họ Và Tên";
            dgr_NhanVien.Columns[2].Name = "Email";
            dgr_NhanVien.Columns[3].Name = "Giới Tính";
            dgr_NhanVien.Columns[4].Name = "Chức Vụ";
            dgr_NhanVien.Columns[5].Name = "Điện Thoại";
            dgr_NhanVien.Columns[6].Name = "CCCD";
            dgr_NhanVien.Columns[7].Name = "Địa Chỉ";
            dgr_NhanVien.Rows.Clear();
            foreach (var x in loc)
            {
                //var chucvu = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.Id == x.IdchucVu);
                dgr_NhanVien.Rows.Add(x.MaNv, x.Ho + " " + x.TenDem + " " + x.Ten, x.Username, x.GioiTinh == 1 ? "Nam" : "Nữ", 
                                        x.IdchucVu == 2 ? "Nhân viên" : "Admin", x.DienThoai, x.Cmnd, x.DiaChi);
            }   
        }
        private void rbtn_BoiBan_CheckedChanged(object sender, EventArgs e)
        {
            var loc = (from a in _ibusNhanVien.GetlstNhanViens()
                       where a.IdchucVu == 3
                       select new { a.MaNv, a.Ho, a.TenDem, a.Ten, a.Username, a.GioiTinh, a.IdchucVu, 
                                    a.DienThoai, a.Cmnd, a.DiaChi }).ToList();
            dgr_NhanVien.ColumnCount = 8;
            dgr_NhanVien.Columns[0].Name = "Mã NV";
            dgr_NhanVien.Columns[1].Name = "Họ Và Tên";
            dgr_NhanVien.Columns[2].Name = "Email";
            dgr_NhanVien.Columns[3].Name = "Giới Tính";
            dgr_NhanVien.Columns[4].Name = "Chức Vụ";
            dgr_NhanVien.Columns[5].Name = "Điện Thoại";
            dgr_NhanVien.Columns[6].Name = "CCCD";
            dgr_NhanVien.Columns[7].Name = "Địa Chỉ";
            dgr_NhanVien.Rows.Clear();
            foreach (var x in loc)
            {
                //var chucvu = _ibusNhanVien.GetlstChucVus().FirstOrDefault(c => c.Id == x.IdchucVu);
                dgr_NhanVien.Rows.Add(x.MaNv, x.Ho + " " + x.TenDem + " " + x.Ten, x.Username, x.GioiTinh == 1 ? "Nam" : "Nữ",
                                        x.IdchucVu == 3 ? "Nhân viên kho" : "Admin", x.DienThoai, x.Cmnd, x.DiaChi);
            }
        }

        #endregion
        
    }
}
