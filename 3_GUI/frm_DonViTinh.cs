using _2_BUS.BUS_MatHang_Service;
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
using _2_BUS.IBUS_MatHang_Service;
using _3_GUI;

namespace _3_GUI_PresentationLayer
{
    public partial class frm_DonViTinh : Form
    {
        private IBUS_DonViTinh_Service _dvtservice;
        public frm_DonViTinh()
        {
            InitializeComponent();
            _dvtservice = new BUS_DonViTinh_Service();
        }

        private void frm_DonViTinh_Load(object sender, EventArgs e)
        {
            showdata();
            dgv_DvTInh.Columns["Id"].HeaderText = "Mã DVT";
            dgv_DvTInh.Columns["Id"].Width = 100;//độ rộng cột ID
            dgv_DvTInh.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn giữa
            dgv_DvTInh.Columns["TenDVT"].HeaderText = "Tên DVT";
            dgv_DvTInh.Columns["NguoiTao"].HeaderText = "Người tạo";
            dgv_DvTInh.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgv_DvTInh.Columns["NguoiCapNhap"].HeaderText = "Người cập nhật";
            dgv_DvTInh.Columns["NgayCapNhap"].HeaderText = "Ngày cập nhật";
            /*dgv_DvTInh.Columns["TenDVT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;*///bề rộng tự động còn lại
        }

        private void showdata()
        {
            var data = (from a in _dvtservice.GetlstDonViTinhs()
                select new
                {
                    a.Id,
                    a.TenDvt,
                    a.NguoiTao,
                    a.NgayTao,
                    a.NguoiCapNhap,
                    a.NgayCapNhap
                }).ToList();
                dgv_DvTInh.DataSource = data;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDVT.Text)) // nếu text box k null
            {
                DonViTinh dvt = new DonViTinh();
                dvt.Id = 1;
                if (_dvtservice.GetlstDonViTinhs().Count!=0)
                {
                    dvt.Id = _dvtservice.GetlstDonViTinhs().Max(c => c.Id) + 1;
                }
                dvt.TenDvt = txtDVT.Text;
                dvt.NguoiTao = Frm_Main.sendnhanvien().Ten;
                dvt.NgayTao = DateTime.Now;
                _dvtservice.AddDonviTinh(dvt);
                MessageBox.Show("Thêm đơn vị tính thành công", "hoàn thành", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                showdata();
                txtDVT.Text = null;//thêm xong thì textbox rỗng
            }
            else
            {
                MessageBox.Show("vui lòng nhập đơn vị tính", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataGridViewRow r;
        private void dgv_DvTInh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
            if (e.RowIndex==-1) return;
            r = dgv_DvTInh.Rows[e.RowIndex];
            txtDVT.Text = r.Cells["TenDVT"].Value.ToString();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần cập nhật", "chứ ý!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtDVT.Text))
            {
                var dvt = _dvtservice.GetlstDonViTinhs()
                    .SingleOrDefault(x => x.Id ==int.Parse(r.Cells["Id"].Value.ToString()));
                dvt.TenDvt = txtDVT.Text;
                dvt.NgayCapNhap = DateTime.Now;
                dvt.NguoiCapNhap = Frm_Main.sendnhanvien().Ten;
                _dvtservice.EditDonviTinh(dvt);
                MessageBox.Show("Sửa đơn vị tính thành công", "hoàn thành", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                showdata();
                r = null;
                txtDVT.Text = null;
            }
            else
            {
                MessageBox.Show("vui lòng nhập đơn vị tính", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần xóa", "chứ ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("bạn muốn xóa đơn vị tính '"+ r.Cells["TenDVT"].Value.ToString()+"' ?","xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                var dvt = _dvtservice.GetlstDonViTinhs()
                    .SingleOrDefault(x => x.Id == int.Parse(r.Cells["Id"].Value.ToString()));
                dvt.TenDvt = txtDVT.Text;
                _dvtservice.RemoveDonviTinh(dvt);
                MessageBox.Show("Xóa đơn vị tính thành công", "hoàn thành", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                showdata();
                r = null;
                txtDVT.Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_menuDanhMuc.loadmathang();
        }
    }
}
