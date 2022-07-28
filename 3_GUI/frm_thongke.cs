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
    public partial class frm_thongke : Form
    {
        public frm_thongke()
        {
            InitializeComponent();
            loadchucvu();
        }
        private void loadchucvu()
        {
            int chucvu = Frm_Main.staticnhanVien.IdchucVu.Value;
            if (chucvu == 1)
            {
                button4.Enabled = true;
                button1.Enabled = true;
                btn_sanpham.Enabled = true;
                btn_dshoadon.Enabled = true;
            }
            if (chucvu == 2)
            {
                button4.Enabled = false;
                button1.Enabled = false;
                btn_sanpham.Enabled = false;
                btn_dshoadon.Enabled = true;
            }
            if (chucvu == 3)
            {
                button4.Enabled = true;
                button1.Enabled = true;
                btn_sanpham.Enabled = true;
                btn_dshoadon.Enabled = false;
            }
        }
            private void btn_sanpham_Click(object sender, EventArgs e)
        {
            pl_load.Controls.Clear();
            frm_ThongKeMatHang frmThongKeMatHang = new frm_ThongKeMatHang();
            frmThongKeMatHang.TopLevel = false;
            pl_load.Controls.Add(frmThongKeMatHang);
            frmThongKeMatHang.FormBorderStyle = FormBorderStyle.None;
            frmThongKeMatHang.Dock = DockStyle.Fill;
            frmThongKeMatHang.Show();
        }

        private void btn_thietbi_Click(object sender, EventArgs e)
        {
            pl_load.Controls.Clear();
            frm_ThongKeThietBi frmThongKeThietBi = new frm_ThongKeThietBi();
            frmThongKeThietBi.TopLevel = false;
            pl_load.Controls.Add(frmThongKeThietBi);
            frmThongKeThietBi.FormBorderStyle = FormBorderStyle.None;
            frmThongKeThietBi.Dock = DockStyle.Fill;
            frmThongKeThietBi.Show();
        }

        private void btn_dshoadon_Click(object sender, EventArgs e)
        {
            pl_load.Controls.Clear();
            frm_DShoadon frmDShoadon = new frm_DShoadon();
            frmDShoadon.TopLevel = false;
            pl_load.Controls.Add(frmDShoadon);
            frmDShoadon.FormBorderStyle = FormBorderStyle.None;
            frmDShoadon.Dock = DockStyle.Fill;
            frmDShoadon.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pl_load.Controls.Clear();
            frm_ThongKeThietBi frmThongKeThietBi = new frm_ThongKeThietBi();
            frmThongKeThietBi.TopLevel = false;
            pl_load.Controls.Add(frmThongKeThietBi);
            frmThongKeThietBi.FormBorderStyle = FormBorderStyle.None;
            frmThongKeThietBi.Dock = DockStyle.Fill;
            frmThongKeThietBi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pl_load.Controls.Clear();
            frm_ThongKeThuChi frmThongKeThuChi = new frm_ThongKeThuChi();
            frmThongKeThuChi.TopLevel = false;
            pl_load.Controls.Add(frmThongKeThuChi);
            frmThongKeThuChi.FormBorderStyle = FormBorderStyle.None;
            frmThongKeThuChi.Dock = DockStyle.Fill;
            frmThongKeThuChi.Show();
        }
    }
}
