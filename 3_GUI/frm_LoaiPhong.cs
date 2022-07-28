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
    public partial class frm_LoaiPhong : Form
    {
        private IBUS_LoaiPhong_Service _iBUS_LoaiPhong_Service;
        private IBUS_Tang_Service _iBUS_Tang_Service;
        private LoaiPhong _loaiPhong;
        private Tang _tang;
        private int _idLoaiPhong;
        private int _idTang;

        int x = 20, y = 9, a = 1;
        Random ran = new Random();

        public frm_LoaiPhong()
        {
            InitializeComponent();
            _iBUS_LoaiPhong_Service = new BUS_LoaiPhong_Service();
            _iBUS_Tang_Service = new BUS_Tang_Service();
            _loaiPhong = new LoaiPhong();
            LoadDataLoaiPhong();
            LoadDataTang();
        }
        private void LoadDataLoaiPhong()
        {
            dgv_loaiPhong.ColumnCount = 4;
            dgv_loaiPhong.Columns[0].Name = "Tên Loại Phòng";
            dgv_loaiPhong.Columns[1].Name = "Đơn Giá";
            dgv_loaiPhong.Columns[2].Name = "Trạng thái";
            dgv_loaiPhong.Columns[3].Name = "ID";
            dgv_loaiPhong.Columns[3].Visible = false;
            dgv_loaiPhong.Rows.Clear();
            foreach (var x in _iBUS_LoaiPhong_Service.sendlstLoaiPhong())
            {
                dgv_loaiPhong.Rows.Add(x.TenLoaiPhong, x.DonGia, Convert.ToInt32(x.IdtranngThai) == 1 ? "Hoạt Động" : "Không Hoạt Động", x.Id);
            }
        }
        private void LoadDataTang()
        {
            dgv_tang.ColumnCount = 4;
            dgv_tang.Columns[0].Name = "Tên Tầng";
            dgv_tang.Columns[1].Name = "Số Lượng Phòng";
            dgv_tang.Columns[2].Name = "Trạng thái";
            dgv_tang.Columns[3].Name = "ID";
            dgv_tang.Columns[3].Visible = false;
            dgv_tang.Rows.Clear();
            foreach (var x in _iBUS_Tang_Service.sendlstTang())
            {
                dgv_tang.Rows.Add(x.TenTang, x.SoLuongPhong, x.IdtrangThai == 1 ? "Hoạt Động" : "Không Hoạt Động", x.Idtang);
            }
        }
        private bool checkFormLoaiPhong()
        {
            if (tbx_tenLoaiPhong.Text.Length == 0 || tbx_donGia.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống thông tin Loại Phòng");
                return true;
            }
            return false;
        }
        private bool checkFormTang()
        {
            if (tbx_tenTang.Text.Length == 0 || tbx_soLuongPhong.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống thông tin Tầng");
                return true;
            }
            return false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow < 0) return;
            var row = dgv_loaiPhong.Rows[indexRow];
            tbx_tenLoaiPhong.Text = row.Cells[0].Value + "";
            tbx_donGia.Text = row.Cells[1].Value + "";
            _idLoaiPhong = Convert.ToInt32(row.Cells[3].Value);
            btn_themLoaiPhong.Enabled = false;
        }
        private void ClearFormLoaiPhong()
        {
            tbx_donGia.Text = "";
            tbx_tenLoaiPhong.Text = "";
            btn_themLoaiPhong.Enabled = true;
        }
        private void ClearFormTang()
        {
            tbx_soLuongPhong.Text = "";
            tbx_tenTang.Text = "";
            btn_ThemTang.Enabled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    if (checkFormLoaiPhong()) return;

                    _loaiPhong = new LoaiPhong();
                    _loaiPhong.Id = Convert.ToInt32(_iBUS_LoaiPhong_Service.sendlstLoaiPhong().Max(x => x.Id) + 1);
                    _loaiPhong.TenLoaiPhong = tbx_tenLoaiPhong.Text;
                    _loaiPhong.DonGia = Convert.ToDouble(tbx_donGia.Text);
                    _loaiPhong.NgayTao = DateTime.Now;
                    _loaiPhong.IdtranngThai = "1";
                    _iBUS_LoaiPhong_Service.Add(_loaiPhong);
                    MessageBox.Show("Thêm loại phòng thành công ", "Thông báo");
                    LoadDataLoaiPhong();
                    ClearFormLoaiPhong();
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
                    if (checkFormLoaiPhong()) return;
                    var loaiPhong = _iBUS_LoaiPhong_Service.Find(_idLoaiPhong).FirstOrDefault();//tìm kiếm
                    loaiPhong.TenLoaiPhong = tbx_tenLoaiPhong.Text;
                    loaiPhong.DonGia = Convert.ToDouble(tbx_donGia.Text);
                    loaiPhong.NgayCapNhap = DateTime.Now;
                    _iBUS_LoaiPhong_Service.Update(loaiPhong);
                    MessageBox.Show("Sửa loại phòng thành công ", "Thông báo");
                    LoadDataLoaiPhong();
                    ClearFormLoaiPhong();
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    var loaiPhong = _iBUS_LoaiPhong_Service.Find(_idLoaiPhong).FirstOrDefault();//tìm kiếm

                    if ((loaiPhong.IdtranngThai == "0") == true)
                    {
                        loaiPhong.IdtranngThai = "1";
                        _iBUS_LoaiPhong_Service.Update(loaiPhong);
                        LoadDataLoaiPhong();
                        ClearFormLoaiPhong();
                        return;
                    }

                    loaiPhong.IdtranngThai = "0";
                    _iBUS_LoaiPhong_Service.Update(loaiPhong);

                    MessageBox.Show("Loại phòng đã chuyển tình trạng thành không hoạt động", "Thông báo");
                    LoadDataLoaiPhong();
                    ClearFormLoaiPhong();
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tbx_donGia.Text = "";
            tbx_tenLoaiPhong.Text = "";
        }

        private void dgv_tang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow < 0) return;
            var row = dgv_tang.Rows[indexRow];
            tbx_tenTang.Text = row.Cells[0].Value + "";
            tbx_soLuongPhong.Text = row.Cells[1].Value + "";
            _idTang = Convert.ToInt32(row.Cells[3].Value);
            btn_ThemTang.Enabled = false;
        }

        private void btn_ThemTang_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    if (checkFormTang()) return;

                    _tang = new Tang();
                    _tang.Idtang = Convert.ToInt32(_iBUS_Tang_Service.sendlstTang().Max(x => x.Idtang) + 1);
                    _tang.TenTang = _tang.Idtang.ToString();
                    _tang.SoLuongPhong = Convert.ToInt32(tbx_soLuongPhong.Text);
                    _tang.IdtrangThai = 1;
                    _iBUS_Tang_Service.Add(_tang);
                    MessageBox.Show("Thêm tầng thành công ", "Thông báo");
                    LoadDataTang();
                    ClearFormTang();
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void btn_SuaTang_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    if (checkFormTang()) return;
                    var tang = _iBUS_Tang_Service.Find(_idTang).FirstOrDefault();//tìm kiếm
                                                                                 //tang.IdtrangThai = tbx_TrangThaiTang.Text;
                    tang.SoLuongPhong = Convert.ToInt32(tbx_soLuongPhong.Text);
                    _iBUS_Tang_Service.Update(tang);
                    MessageBox.Show("Sửa tầng thành công ", "Thông báo");
                    LoadDataTang();
                    ClearFormTang();
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void btn_XoaTang_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoi;
                hoi = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
                if (hoi == DialogResult.Yes)
                {
                    var tang = _iBUS_Tang_Service.Find(_idTang).FirstOrDefault();//tìm kiếm

                    if (( Convert.ToInt32(tang.IdtrangThai) == 0) == true)
                    {
                        tang.IdtrangThai = 1;
                        _iBUS_Tang_Service.Update(tang);
                        LoadDataTang();
                        ClearFormTang();
                        return;
                    }

                    tang.IdtrangThai = 0;
                    _iBUS_Tang_Service.Update(tang).ToString();
                    MessageBox.Show("Tầng đã chuyển trạng thái thành không hoạt động", "Thông báo");
                    LoadDataTang();
                    ClearFormTang();
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_menuDanhMuc.loadphong();
        }

        private void btn_ClearTang_Click(object sender, EventArgs e)
        {
            tbx_tenTang.Text = "";
            tbx_soLuongPhong.Text = "";
        }

        
    }
}

