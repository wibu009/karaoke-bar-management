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
    public partial class frm_Phong : Form
    {
        private IBUS_Phong_Service _iBUS_Phong_Service;
        private IBUS_LoaiPhong_Service _iBUS_LoaiPhong_Service;
        private IBUS_Tang_Service _iBUS_Tang_Service;
        private Phong _phong;
        private int _idPhong;
        private IBUS_NhanVien_Service _nhanVienService;
        private string _tennhanvien;
        int x = 20, y = 9, a = 1;
        Random ran = new Random();
        public frm_Phong()
        {
            InitializeComponent();
            _iBUS_Phong_Service = new BUS_Phong_Service();
            _iBUS_LoaiPhong_Service = new BUS_LoaiPhong_Service();
            _iBUS_Tang_Service = new BUS_Tang_Service();
            _phong = new Phong();
            cbb_trangThai.Enabled = false;
            LoadData();
            loadcmbLoaiPhong();
            loadcmbTang();
            loadcmbTrangThai();
            groupBox2.Text = Frm_Main.sendnhanvien().Ho + " " + Frm_Main.sendnhanvien().TenDem + " " +
                               Frm_Main.sendnhanvien().Ten;
            //tbx_ngayCapNhap.Visible = false;
            //tbx_ngayTao.Visible = false;
        }
        private void LoadData()
        {
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Loại Phòng";
            dataGridView1.Columns[2].Name = "Tầng";
            dataGridView1.Columns[3].Name = "Tên Phòng";
            dataGridView1.Columns[4].Name = "Trạng thái";
            dataGridView1.Columns[5].Name = "Sức chứa";
            dataGridView1.Columns[6].Name = "Người Tạo";
            dataGridView1.Columns[7].Name = "Ngày tạo";
            dataGridView1.Columns[8].Name = "Người cập nhập";
            dataGridView1.Columns[9].Name = "Ngày cập nhập";
            dataGridView1.Columns[10].Name = "Tình trạng";
            dataGridView1.Rows.Clear();
            foreach (var x in _iBUS_Phong_Service.sendlstPhong())
            {
                dataGridView1.Rows.Add(x.Id, _iBUS_LoaiPhong_Service.sendlstLoaiPhong().FirstOrDefault(y => y.Id == x.IdloaiPhong).TenLoaiPhong, x.Idtang, x.TenPhong, x.TrangThai, x.SucChua, x.NguoiTao, x.NgayTao, x.NguoiCapNhap, x.NgayCapNhap, Convert.ToInt32( x.IdtranngThai) == 1 ? "Hoạt động" : "Không hoạt động");
            }
        }
        private void loadcmbLoaiPhong()
        {
            foreach (var x in _iBUS_LoaiPhong_Service.sendlstLoaiPhong())
            {
                cmb_loaiPhong.Items.Add(x.TenLoaiPhong);
            }
        }
        private void loadcmbTrangThai()
        {

            cbb_trangThai.Items.Add("1-Phòng trống");
            cbb_trangThai.Items.Add("2-Phòng đang dọn");
            cbb_trangThai.Items.Add("3-Phòng có khách");
            cbb_trangThai.Items.Add("4-Phòng cần dọn");

        }
        private void loadcmbTang()
        {
            foreach (var x in _iBUS_Tang_Service.sendlstTang())
            {
                cbb_idtang.Items.Add(x.Idtang);
            }
        }
        private bool checkForm()
        {
            if (tbx_tenPhong.Text.Length == 0 || tbx_SucChua.Text.Length == 0 || cmb_loaiPhong.Text.Length == 0 || cbb_idtang.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống thông tin");
                return true;
            }
            if (cmb_loaiPhong.Text == null)
            {
                MessageBox.Show("Bạn chưa chọn Loại Phòng");
                return true;
            }
            if (cbb_idtang.Text == null)
            {
                MessageBox.Show("Bạn chưa chọn Tầng");
                return true;
            }

            return false;
        }
        private void ClearForm()
        {
            tbx_tenPhong.Text = "";
            tbx_SucChua.Text = "";
            cbb_idtang.Text = "";
            cmb_loaiPhong.Text = "";
            btn_them.Enabled = true;
            cbb_trangThai.Enabled = false;


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow < 0||indexRow>= _iBUS_Phong_Service.sendlstPhong().Count) return;
            var row = dataGridView1.Rows[indexRow];
            //tbx_maLoaiPhong.Text = row.Cells[1].Value + "";
            cmb_loaiPhong.Text = row.Cells[1].Value + "";
            cbb_idtang.Text = row.Cells[2].Value + "";
            tbx_tenPhong.Text = row.Cells[3].Value + "";
            cbb_trangThai.Text = row.Cells[4].Value + "";
            tbx_SucChua.Text = row.Cells[5].Value + "";


            _idPhong = Convert.ToInt32(row.Cells[0].Value + "");
            // Enabled button
            btn_them.Enabled = false;
            cbb_trangThai.Enabled = true;

        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    if (checkForm()) return;

                    _phong = new Phong();
                    _phong.Id = _iBUS_Phong_Service.sendlstPhong().Max(x => x.Id + 1);
                    _phong.TenPhong = tbx_tenPhong.Text;
                    _phong.IdloaiPhong = _iBUS_LoaiPhong_Service.sendlstLoaiPhong().FirstOrDefault(x => x.TenLoaiPhong == cmb_loaiPhong.Text).Id;

                    if (_iBUS_Phong_Service.sendlstPhong().FirstOrDefault(x => x.TenPhong == tbx_tenPhong.Text) != null)
                    {
                        MessageBox.Show("Tên phòng đã tồn tại");
                        return;
                    }
                    _phong.TrangThai = 1;
                    _phong.Idtang = Convert.ToInt32(cbb_idtang.Text);
                    _phong.SucChua = Convert.ToInt32(tbx_SucChua.Text);
                    _phong.NguoiTao = _tennhanvien;
                    _phong.NgayTao = DateTime.Now;
                    _phong.NguoiCapNhap = _tennhanvien;
                    _phong.NgayCapNhap = DateTime.Now;
                    _phong.IdtranngThai = "1";

                    if ((_iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == Convert.ToInt32(cbb_idtang.Text)).ToList().Count >=
                        _iBUS_Tang_Service.sendlstTang().FirstOrDefault(x => x.Idtang == Convert.ToInt32(cbb_idtang.Text)).SoLuongPhong) == true)
                    {
                        MessageBox.Show("Tầng đã đủ phòng không thể thêm");
                        return;
                    }
                    else
                    {
                        _iBUS_Phong_Service.Add(_phong);
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        LoadData();
                        ClearForm();
                    }
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    if (checkForm()) return;
                    var phong = _iBUS_Phong_Service.Find(_idPhong).FirstOrDefault();//tìm kiếm
                    phong.IdloaiPhong = _iBUS_LoaiPhong_Service.sendlstLoaiPhong().FirstOrDefault(x => x.TenLoaiPhong == cmb_loaiPhong.Text).Id;
                    phong.TenPhong = tbx_tenPhong.Text;
                    phong.Idtang = Convert.ToInt32(cbb_idtang.Text);
                    phong.SucChua = Convert.ToInt32(tbx_SucChua.Text);
                    phong.NguoiCapNhap = _tennhanvien;
                    phong.NgayCapNhap = DateTime.Now;
                    if (cbb_trangThai.Text == "1-Phòng trống")
                    {
                        phong.TrangThai = 1;
                    }
                    else if (cbb_trangThai.Text == "2-Phòng đang dọn")
                    {
                        phong.TrangThai = 2;
                    }
                    else if (cbb_trangThai.Text == "3-Phòng có khách")
                    {
                        phong.TrangThai = 3;
                    }
                    else if (cbb_trangThai.Text == "4-Phòng cần dọn")
                    {
                        phong.TrangThai = 4;
                    }
                    _iBUS_Phong_Service.Update(phong);
                    MessageBox.Show("Sửa phòng thành công", "Thông báo");
                    LoadData();
                    ClearForm();
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void btn_xóa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    var phong = _iBUS_Phong_Service.Find(_idPhong).FirstOrDefault();//tìm kiếm
                    if ((phong.IdtranngThai == "0") == true)
                    {
                        phong.IdtranngThai = "1";
                        _iBUS_Phong_Service.Update(phong);
                        LoadData();
                        ClearForm();
                        return;
                    }
                    phong.IdtranngThai = "0";
                    phong.TrangThai = 1;
                    _iBUS_Phong_Service.Update(phong);
                    MessageBox.Show("Phòng đã chuyển trạng thái thành không hoạt động", "thông báo");

                    LoadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_loaiphong_Click(object sender, EventArgs e)
        {
            frm_menuDanhMuc.loadloaiphong();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void frm_Phong_Load(object sender, EventArgs e)
        {

        }
    }
}