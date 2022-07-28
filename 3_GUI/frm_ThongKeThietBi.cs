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
    public partial class frm_ThongKeThietBi : Form
    {
        public frm_ThongKeThietBi()
        {
            InitializeComponent();
            _ThietBi_Service = new BUS_ThietBi_Service();
            _LoaiThietBi_Service = new BUS_LoaiThietBi_Service();
            LoadCBB();
            LoadData();
            comboBox1.SelectedIndex = 0;
        }
        private IBUS_LoaiThietBi_Service _LoaiThietBi_Service;
        private IBUS_ThietBi_Service _ThietBi_Service;
        private void LoadData()
        {
            var data =
                (from a in _ThietBi_Service.GetlstThietBis()
                 join b in _LoaiThietBi_Service.GetlstLoaiThietBis() on a.IdmaLoaiTb equals b.MaLoaiTb
                 select new
                 {
                     a.TenTb,
                     b.TenLoai,
                     b.XuatXu,
                     a.SoLuong,
                     a.DonGia,
                     Tongtien = a.SoLuong * a.DonGia
                 }).ToList();
            dataGridView1.DataSource = data;
            LoadText();
        }
        private void LoadCBB()
        {
            comboBox1.Items.Add("Tất cả");
            foreach (var x in _ThietBi_Service.GetlstThietBis())
            {
                comboBox1.Items.Add(x.TenTb);
            }
        }
        private void btn_thongke_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tất cả")
            {
                LoadData();
            }
            else
            {
                var data = (from a in _ThietBi_Service.GetlstThietBis()
                            from b in _LoaiThietBi_Service.GetlstLoaiThietBis()
                            where a.IdmaLoaiTb.Equals(b.MaLoaiTb)
                            && a.TenTb.Equals(comboBox1.Text)
                            select new
                            {
                                a.TenTb,
                                b.TenLoai,
                                b.XuatXu,
                                a.SoLuong,
                                a.DonGia,
                                Tongtien = a.SoLuong * a.DonGia
                            }).ToList();
                dataGridView1.DataSource = data;
                LoadText();
            }
        }
        private void LoadText()
        {
            dataGridView1.Columns["TenTb"].HeaderText = "Tên thiết bị";
            dataGridView1.Columns["TenLoai"].HeaderText = "Tên loại";
            dataGridView1.Columns["Dongia"].HeaderText = "Đơn giá";
            dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView1.Columns["Tongtien"].HeaderText = "Tổng tiền";
            dataGridView1.Columns["XuatXu"].HeaderText = "Xuất xứ";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
