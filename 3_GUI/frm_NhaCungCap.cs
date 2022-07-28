using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_Service;

namespace _3_GUI
{
    public partial class frm_NhaCungCap : Form
    {
        private IBUS_NhaCungCap_Service _nhaCungCapService;
        private string _idNhanVien;
        private int _iD;

        int x = 20, y = 9, a = 1;
        Random ran = new Random();

        public frm_NhaCungCap()
        {
            InitializeComponent();
            _nhaCungCapService = new BUS_NhaCungCap_Service();
            _idNhanVien = "admin";
            FillDataToGrid();
        }

        public frm_NhaCungCap(string idNhanVien)
        {
            InitializeComponent();
            _nhaCungCapService = new BUS_NhaCungCap_Service();
            _idNhanVien = idNhanVien;
            FillDataToGrid();
        }

        public void FillDataToGrid()
        {
            dgrid_DataOfNCC.Columns.Clear();
            dgrid_DataOfNCC.ColumnCount = 9;
            dgrid_DataOfNCC.Columns[0].Name = "ID";
            dgrid_DataOfNCC.Columns[1].Name = "Tên nhà cung cấp";
            dgrid_DataOfNCC.Columns[2].Name = "Địa chỉ";
            dgrid_DataOfNCC.Columns[3].Name = "SĐT";
            dgrid_DataOfNCC.Columns[4].Name = "Email";
            dgrid_DataOfNCC.Columns[5].Name = "Ngày tạo";
            dgrid_DataOfNCC.Columns[6].Name = "Người tạo";
            dgrid_DataOfNCC.Columns[7].Name = "Ngày cập nhập";
            dgrid_DataOfNCC.Columns[8].Name = "Người cập nhật";
            dgrid_DataOfNCC.Columns[0].Visible = false;
            foreach (var x in _nhaCungCapService.GetListnNhaCungCapsFromDAL())
            {
                dgrid_DataOfNCC.Rows.Add(x.Id, x.TenNcc, x.DiaChi, x.DienThoai, x.Email, x.NgayTao, x.NguoiTao,
                    x.NgayCapNhap, x.NguoiCapNhap);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (_nhaCungCapService.AddNhaCungCap(txt_NameOfNcc.Text, "Admin", "Admin", txt_NumberPhone.Text,
                txt_Email.Text,
                txt_Address.Text))
            {
                MessageBox.Show("Thêm thành công!", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataToGrid();
                return;
            }

            MessageBox.Show("Thêm thất bại", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (_nhaCungCapService.UpdateNhaCungCap(_iD, txt_NameOfNcc.Text, "Admin", txt_Address.Text, txt_Email.Text,
                txt_NumberPhone.Text))
            {
                MessageBox.Show("Sửa thành công", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataToGrid();
                return;
            }

            MessageBox.Show("Sửa thất bại", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (_nhaCungCapService.DeleteNhaCungCap(_iD))
            {
                MessageBox.Show("Xóa thành công", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDataToGrid();
                return;
            }

            MessageBox.Show("Xóa thất bại", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Address.Text = null;
            txt_NameOfNcc.Text = null;
            txt_NumberPhone.Text = null;
            txt_Email.Text = null;
            FillDataToGrid();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Frm_Main.loadHoadonnhap();
        }

        private void dgrid_DataOfNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == _nhaCungCapService.GetListnNhaCungCapsFromDAL().Count || e.RowIndex == -1) return;
            _iD = Convert.ToInt32(dgrid_DataOfNCC.Rows[e.RowIndex].Cells[0].Value);
            txt_NameOfNcc.Text = dgrid_DataOfNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Address.Text = dgrid_DataOfNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_NumberPhone.Text = dgrid_DataOfNCC.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Email.Text = dgrid_DataOfNCC.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        
    }
}
