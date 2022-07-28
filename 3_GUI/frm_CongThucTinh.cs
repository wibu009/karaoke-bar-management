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
    public partial class frm_CongThucTinh : Form
    {
        private IBUS_CongThucTinh_Service _congThucTinhService;
        private int _iD;

        int x = 20, y = 9, a = 1;
        Random ran = new Random();

        public frm_CongThucTinh()
        {
            InitializeComponent();
            _congThucTinhService = new BUS_CongThucTinh_Service();
            FillDataToGrid();
        }

        public void FillDataToGrid()
        {
            dgrid_DataOfCTT.Columns.Clear();
            dgrid_DataOfCTT.ColumnCount = 10;
            dgrid_DataOfCTT.Columns[0].Name = "ID";
            dgrid_DataOfCTT.Columns[1].Name = "Time sale 1";
            dgrid_DataOfCTT.Columns[2].Name = "Ưu đãi 1";
            dgrid_DataOfCTT.Columns[3].Name = "Time sale 2";
            dgrid_DataOfCTT.Columns[4].Name = "Ưu đãi 2";
            dgrid_DataOfCTT.Columns[5].Name = "Time sale 3";
            dgrid_DataOfCTT.Columns[6].Name = "Ưu đãi 3";
            dgrid_DataOfCTT.Columns[7].Name = "Giá phòng thường";
            dgrid_DataOfCTT.Columns[8].Name = "Giá phòng VIP";
            dgrid_DataOfCTT.Columns[9].Name = "Ghi chú";
            dgrid_DataOfCTT.Columns[0].Visible = false;
            foreach (var x in _congThucTinhService.GetListCongThucTinhsFromDAL())
            {
                dgrid_DataOfCTT.Rows.Add(x.IdcongThucTinh, x.ThoiGianNhanUuDai1, x.UuDai1, x.ThoiGianNhanUuDai2,
                    x.UuDai2, x.ThoiGianNhanUuDai3, x.UuDai3, x.GiaPhong, x.GiaPhongVIP, x.GhiChu);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (_congThucTinhService.AddCongThucTinh(Convert.ToDouble(txt_UD1.Text), Convert.ToDouble(txt_UD2.Text),
                    Convert.ToDouble(txt_TGUD3.Text), Convert.ToDouble(txt_TGUD1.Text),
                    Convert.ToDouble(txt_TGUD2.Text), Convert.ToDouble(txt_TGUD3.Text),
                    Convert.ToDouble(txt_PriceOfRoom.Text), Convert.ToDouble(txt_PriceOfVIPRoom.Text), txt_Note.Text))
                {
                    MessageBox.Show("Thêm thành công!", "Admin said", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataToGrid();
                    return;
                }

                MessageBox.Show("Thêm thất bại!", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if(_congThucTinhService.UpdateCongThucTinh(_iD, Convert.ToDouble(txt_UD1.Text), Convert.ToDouble(txt_UD2.Text),
                    Convert.ToDouble(txt_TGUD3.Text), Convert.ToDouble(txt_TGUD1.Text),
                    Convert.ToDouble(txt_TGUD2.Text), Convert.ToDouble(txt_TGUD3.Text),
                    Convert.ToDouble(txt_PriceOfRoom.Text), Convert.ToDouble(txt_PriceOfVIPRoom.Text), txt_Note.Text))
                {
                    MessageBox.Show("Sửa thành công!", "Admin said", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataToGrid();
                    return;
                }

                MessageBox.Show("Sửa thất bại!", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_congThucTinhService.DeleteCongThucTinh(_iD))
                {
                    MessageBox.Show("Xóa thành công!", "Admin said", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataToGrid();
                    return;
                }

                MessageBox.Show("Xóa thất bại!", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                txt_TGUD1.Text = null;
                txt_TGUD2.Text = null;
                txt_TGUD3.Text = null;
                txt_UD1.Text = null;
                txt_UD2.Text = null;
                txt_UD3.Text = null;
                txt_PriceOfRoom.Text = null;
                txt_PriceOfVIPRoom.Text = null;
                txt_Note.Text = null;
                FillDataToGrid();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void dgrid_DataOfCTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == _congThucTinhService.GetListCongThucTinhsFromDAL().Count  || e.RowIndex == -1) return;
                _iD = Convert.ToInt32(dgrid_DataOfCTT.Rows[e.RowIndex].Cells[0].Value);
                txt_TGUD1.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_UD1.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_TGUD2.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_UD2.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_TGUD3.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_UD3.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_PriceOfRoom.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt_PriceOfVIPRoom.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[8].Value.ToString();
                txt_Note.Text = dgrid_DataOfCTT.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }
        }

        
    }
}
