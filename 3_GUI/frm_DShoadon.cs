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
    public partial class frm_DShoadon : Form
    {
        private IBUS_HoaDonBanHang_Service _HoaDonBanHangService;
        private IBUS_Phong_Service _phongService;
        private IBUS_KhachHang_Service _khachHangService;
        private IBUS_NhanVien_Service _nhanVienService;
        public frm_DShoadon()
        {
            InitializeComponent();
            _HoaDonBanHangService = new BUS_HoaDonBanHang_Service();
            _phongService = new BUS_Phong_Service();
            _khachHangService = new BUS_KhachHang_Service();
            _nhanVienService = new BUS_NhanVien_Service();
            loaddata("");
        }

        private void loaddata(string tenkh)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Mã hóa đơn";
            dataGridView1.Columns[1].Name = "Phòng";
            dataGridView1.Columns[2].Name = "Khách hàng";
            dataGridView1.Columns[3].Name = "Thời gian bắt đầu";
            dataGridView1.Columns[4].Name = "Nhân viên";
            var data = 
                (from a in _HoaDonBanHangService.sendlstHoaDonBanHang().Where(z=>z.IdtranngThai==2)
                    join b in _khachHangService.GetlstKhachHangs().Where(m=>m.Ten.ToLower().Contains(tenkh.ToLower())) on a.IdmaKh equals b.MaKh
                    join c in _phongService.sendlstPhong() on a.Idphong equals c.Id
                    select new
                    {
                        a.IdhoaDon,
                        c.TenPhong,
                        b.Ho,
                        b.TenDem,
                        b.Ten,
                        a.ThoiGianBatDau,
                        a.IdmaNv,
                    }).ToList();
            foreach (var n in data)
            {
                var nhanvien = _nhanVienService.GetlstNhanViens().SingleOrDefault(c => c.MaNv == n.IdmaNv);
                dataGridView1.Rows.Add(n.IdhoaDon, n.TenPhong, n.Ho + " " + n.TenDem + " " + n.Ten, n.ThoiGianBatDau, nhanvien.Ho + " " + nhanvien.TenDem + " " + nhanvien.Ten);
            }
        }

        private void loadhoadon(int id)
        {
            panel1.Controls.Clear();
            frm_hoadon frmHoadon = new frm_hoadon(_HoaDonBanHangService.sendlstHoaDonBanHang().SingleOrDefault(c=>c.IdhoaDon==id));
            frmHoadon.TopLevel = false;
            panel1.Controls.Add(frmHoadon);
            frmHoadon.FormBorderStyle = FormBorderStyle.None;
            frmHoadon.Dock = DockStyle.Fill;
            frmHoadon.Show();
        }
        private DataGridViewRow r;
        private int idhoadon;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            r = dataGridView1.Rows[e.RowIndex];
            idhoadon = int.Parse(r.Cells[0].Value.ToString());
            loadhoadon(idhoadon);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            loaddata(textBox1.Text);
        }
    }
}
