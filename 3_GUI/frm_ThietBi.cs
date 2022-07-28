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
    public partial class frm_ThietBi : Form
    {
        private IBUS_ThietBi_Service _service;
        private IBUS_LoaiThietBi_Service _lTBservice;
        private List<LoaiThietBi> _ltb;
        public frm_ThietBi()
        {
            InitializeComponent();
            _service = new BUS_ThietBi_Service();
            _lTBservice = new BUS_LoaiThietBi_Service();
            _ltb = new List<LoaiThietBi>();
            LoadData();
            loadcmbIDDVT();
        }
        private void frm_QLThietBi_Load(object sender, EventArgs e)
        {
            LoadData();
            loadcmbIDDVT();
            //dgv_QLThietBi.Columns["Id"].Visible = false;
        }
        private void LoadData()
        {
            var data =
                (from a in _service.GetlstThietBis()
                 join b in _lTBservice.GetlstLoaiThietBis()
                     on a.IdmaLoaiTb equals b.MaLoaiTb
                 select new
                 {
                     a.MaTb,
                     a.TenTb,
                     b.TenLoai,
                     a.DonGia,
                     a.SoLuong,
                     a.TinhTrang,
                     b.XuatXu
                 }).ToList();
            dgv_QLThietBi.DataSource = data;
            dgv_QLThietBi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_QLThietBi.Columns["TenLoai"].HeaderText = "Tên Loại";
            dgv_QLThietBi.Columns["MaTb"].HeaderText = "Mã thiết bị";
            dgv_QLThietBi.Columns["TenTb"].HeaderText = "Tên thiết bị";
            dgv_QLThietBi.Columns["DonGia"].HeaderText = "Đơn giá";
            dgv_QLThietBi.Columns["SoLuong"].HeaderText = "Số lượng";
            dgv_QLThietBi.Columns["TinhTrang"].HeaderText = "Trạng thái";
            dgv_QLThietBi.Columns["XuatXu"].HeaderText = "Xuất xứ";

        }
        private void loadcmbIDDVT()
        {
            _ltb = _lTBservice.GetlstLoaiThietBis();
            foreach (var x in _lTBservice.GetlstLoaiThietBis())
            {
                cmb_mltb.Items.Add(x.TenLoai);
            }
        }
        private DataGridViewRow data;
        

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_tentb.Text) || !string.IsNullOrEmpty(txt_dongia.Text) ||
                !string.IsNullOrEmpty(txt_soluong.Text) || !string.IsNullOrEmpty(txt_tinhtrang.Text) || !string.IsNullOrEmpty(cmb_mltb.Text))
                {
                    ThietBi tb = new ThietBi();
                    tb.MaTb = "1";
                    if (_service.GetlstThietBis().Count != 0)
                    {
                        tb.MaTb = _service.GetlstThietBis().Max(c => Convert.ToInt32(c.MaTb) + 1).ToString();
                    }
                    tb.IdmaLoaiTb = _ltb[_ltb.FindIndex(x => x.TenLoai == cmb_mltb.Text)].MaLoaiTb;
                    tb.TenTb = txt_tentb.Text;
                    tb.DonGia = Convert.ToInt32(txt_dongia.Text);
                    tb.SoLuong = Convert.ToInt32(txt_soluong.Text);
                    tb.TinhTrang = Convert.ToInt32(txt_tinhtrang.Text);
                    _service.AddThietBi(tb);
                    MessageBox.Show("Thêm thành công", "Hoàn thành", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    LoadData();
                    txt_tentb.Text = null;
                    txt_dongia.Text = null;
                    txt_tinhtrang.Text = null;
                    txt_soluong.Text = null;
                }
                else
                {
                    MessageBox.Show("Nhập hộ cái dữ liệu vào", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập hộ cái dữ liệu vào", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private ThietBi Gets()
        {
            var tb = _service.GetlstThietBis()
                .SingleOrDefault(x => x.MaTb == (data.Cells["MaTb"].Value.ToString()));
            return tb;
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (data == null)
                {
                    MessageBox.Show("Bạn chưa chọn thiết bị", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure about that " + data.Cells["TenTb"].Value.ToString() + " ?!", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_service.RemoveThietBi(Gets()))
                    {
                        MessageBox.Show("Xóa thành công", "Hoàn thành", MessageBoxButtons.OK);
                        LoadData();
                        data = null;
                        txt_tentb.Text = null;
                        txt_dongia.Text = null;
                        txt_tinhtrang.Text = null;
                        txt_soluong.Text = null;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn chưa chọn thiết bị", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (data == null)
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu", "chú ý", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(txt_tentb.Text) || !string.IsNullOrEmpty(txt_dongia.Text) ||
                    !string.IsNullOrEmpty(txt_soluong.Text) || !string.IsNullOrEmpty(txt_tinhtrang.Text) || !string.IsNullOrEmpty(cmb_mltb.Text))
                {
                    var tb = Gets();
                    tb.IdmaLoaiTb = _ltb.FirstOrDefault(x => x.TenLoai == cmb_mltb.Text).MaLoaiTb;
                    tb.TenTb = txt_tentb.Text;
                    tb.DonGia = Convert.ToInt32(txt_dongia.Text);
                    tb.SoLuong = Convert.ToInt32(txt_soluong.Text);
                    tb.TinhTrang = Convert.ToInt32(txt_tinhtrang.Text);
                    _service.EditThietBi(tb);
                    MessageBox.Show("Sửa thành công", "Hoàn thành", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    LoadData();
                    data = null;
                    txt_tentb.Text = null;
                    txt_dongia.Text = null;
                    txt_tinhtrang.Text = null;
                    txt_soluong.Text = null;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu", "chú ý", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "chú ý", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            _service.SaveThietBi();
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void btn_themloaithietbi_Click(object sender, EventArgs e)
        {
            frm_menuDanhMuc.loadloaithietbi();
        }

        private void dgv_QLThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            data = dgv_QLThietBi.Rows[e.RowIndex];
            txt_tentb.Text = data.Cells["TenTb"].Value.ToString();
            txt_dongia.Text = data.Cells["DonGia"].Value.ToString();
            txt_tinhtrang.Text = data.Cells["TinhTrang"].Value.ToString();
            txt_soluong.Text = data.Cells["SoLuong"].Value.ToString();
            cmb_mltb.Text = data.Cells["TenLoai"].Value.ToString();
        }
    }
}
