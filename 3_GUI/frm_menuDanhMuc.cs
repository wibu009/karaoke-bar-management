using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3_GUI_PresentationLayer;

namespace _3_GUI
{
    public partial class frm_menuDanhMuc : Form
    {
        public frm_menuDanhMuc()
        {
            InitializeComponent();
            loadchucvu();
        }
        private void loadchucvu()
        {
            int chucvu = Frm_Main.staticnhanVien.IdchucVu.Value;
            if (chucvu == 1)
            {
                button3.Enabled = true;
                btn_thietbi.Enabled = true;
                btn_Phong.Enabled = true;
                btn_Nhanvien.Enabled = true;
                btn_ctt.Enabled = true;
            }
            if (chucvu == 2)
            {
                button3.Enabled = true;
                btn_thietbi.Enabled = true;
                btn_Phong.Enabled = false;
                btn_Nhanvien.Enabled = true;
                btn_ctt.Enabled = true;
            }
            if (chucvu == 3)
            {
                button3.Enabled = true;
                btn_thietbi.Enabled = false;
                btn_Phong.Enabled = false;
                btn_Nhanvien.Enabled = true;
                btn_ctt.Enabled = false;
            }
        }
        int x = 20, y = 9, a = 1;
        Random ran = new Random();

        private void btn_Phong_Click(object sender, EventArgs e)
        {
            buttomcolor();
            btn_Phong.BackColor = SystemColors.HotTrack;
            loadphong();
        }

        public static void loadphong()
        {
            loadform.Controls.Clear();
            frm_Phong frmPhong = new frm_Phong();
            frmPhong.TopLevel = false;
            loadform.Controls.Add(frmPhong);
            frmPhong.FormBorderStyle = FormBorderStyle.None;
            frmPhong.Dock = DockStyle.Fill;
            frmPhong.Show();
        }

        public static void loadloaiphong()
        {
            loadform.Controls.Clear();
            frm_LoaiPhong frmLoaiPhong = new frm_LoaiPhong();
            frmLoaiPhong.TopLevel = false;
            loadform.Controls.Add(frmLoaiPhong);
            frmLoaiPhong.FormBorderStyle = FormBorderStyle.None;
            frmLoaiPhong.Dock = DockStyle.Fill;
            frmLoaiPhong.Show();
        }
        private void btn_Nhanvien_Click(object sender, EventArgs e)
        {
            buttomcolor();
            btn_Nhanvien.BackColor = SystemColors.HotTrack;
            loadform.Controls.Clear();
            frm_NhanVien frmNhanVien = new frm_NhanVien();
            frmNhanVien.TopLevel = false;
            loadform.Controls.Add(frmNhanVien);
            frmNhanVien.FormBorderStyle = FormBorderStyle.None;
            frmNhanVien.Dock = DockStyle.Fill;
            frmNhanVien.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttomcolor();
            button3.BackColor = SystemColors.HotTrack;
            loadmathang();
        }
        public static void loadmathang()
        {
            loadform.Controls.Clear();
            frm_QLMatHang frmQlMatHang = new frm_QLMatHang();
            frmQlMatHang.TopLevel = false;
            loadform.Controls.Add(frmQlMatHang);
            frmQlMatHang.FormBorderStyle = FormBorderStyle.None;
            frmQlMatHang.Dock = DockStyle.Fill;
            frmQlMatHang.Show();
        }

        public static void loadDVT()
        {
            loadform.Controls.Clear();
            frm_DonViTinh frmDonViTinh = new frm_DonViTinh();
            frmDonViTinh.TopLevel = false;
            loadform.Controls.Add(frmDonViTinh);
            frmDonViTinh.FormBorderStyle = FormBorderStyle.None;
            frmDonViTinh.Dock = DockStyle.Fill;
            frmDonViTinh.Show();
        }
        private void btn_thietbi_Click(object sender, EventArgs e)
        {
            buttomcolor();
            btn_thietbi.BackColor = SystemColors.HotTrack;
            loadthietbi();
        }

        public static void loadthietbi()
        {
            loadform.Controls.Clear();
            frm_ThietBi frmThietBi = new frm_ThietBi();
            frmThietBi.TopLevel = false;
            loadform.Controls.Add(frmThietBi);
            frmThietBi.FormBorderStyle = FormBorderStyle.None;
            frmThietBi.Dock = DockStyle.Fill;
            frmThietBi.Show();
        }

        public static void loadloaithietbi()
        {
            loadform.Controls.Clear();
            frm_LoaiThietBi frmLoaiThietBi = new frm_LoaiThietBi();
            frmLoaiThietBi.TopLevel = false;
            loadform.Controls.Add(frmLoaiThietBi);
            frmLoaiThietBi.FormBorderStyle = FormBorderStyle.None;
            frmLoaiThietBi.Dock = DockStyle.Fill;
            frmLoaiThietBi.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                lbl_Timer.Location = new Point(x, y);
                if (x >= 790)
                {
                    a = -1;
                    lbl_Timer.ForeColor = Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
                }
                if (x <= 19)
                {
                    a = 1;
                    lbl_Timer.ForeColor = Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_ctt_Click(object sender, EventArgs e)
        {
            buttomcolor();
            btn_ctt.BackColor = SystemColors.HotTrack;
            loadform.Controls.Clear();
            frm_CongThucTinh frmCongThucTinh = new frm_CongThucTinh();
            frmCongThucTinh.TopLevel = false;
            loadform.Controls.Add(frmCongThucTinh);
            frmCongThucTinh.FormBorderStyle = FormBorderStyle.None;
            frmCongThucTinh.Dock = DockStyle.Fill;
            frmCongThucTinh.Show();
        }

        
        void buttomcolor()
        {
            panel1.BackColor = SystemColors.HotTrack;
            btn_Phong.BackColor = SystemColors.MenuHighlight;
            btn_Nhanvien.BackColor = SystemColors.MenuHighlight;
            button3.BackColor = SystemColors.MenuHighlight;
            btn_thietbi.BackColor = SystemColors.MenuHighlight;
            btn_ctt.BackColor = SystemColors.MenuHighlight;
        }

       
    }
}
