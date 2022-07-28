using _1_DAL.DBContext;
using _1_DAL.Entities;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_MatHang_Service;
using _2_BUS.IBUS_Service;
using _2_BUS.Model;
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
    public partial class frm_ThongKeMatHang : Form
    {
        public frm_ThongKeMatHang()
        {
            InitializeComponent();
            _ChiTietHoaDonBan_Service = new BUS_ChiTietHoaDonBan_Service();
            _MatHang_Service = new BUS_MatHang_Service();
            LoadMBT();
            LoadCBB();
            LoadData();
            comboBox1.SelectedIndex = 0;
        }
        private IBUS_ChiTietHoaDonBan_Service _ChiTietHoaDonBan_Service;
        private IBUS_MatHang_Service _MatHang_Service;

        private void LoadData()
        {
            var data =
                            (from a in _MatHang_Service.GetlstMatHangs()
                             select new
                             {
                                 TenMatHang = a.TenMatHang,
                                 DonGia = a.DonGia,
                                 SoLuong = a.SoLuong,
                                 Ngay = a.NgayTao,
                                 Tongtien = a.DonGia * a.SoLuong

                             }).ToList();
            dataGridView1.DataSource = data;
            LoadText();
        }
        private void btn_thongke_Click(object sender, EventArgs e)
        {
            DateTime tungay, toingay;
            try
            {
                tungay = DateTime.ParseExact(mtb_tungay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                toingay = DateTime.ParseExact(mtb_toingay.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Thời gian không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (comboBox1.Text == "Tất cả")
                {                   
                    {
                        try
                        {
                            var data =
                            (from a in _MatHang_Service.GetlstMatHangs().Where(x => x.NgayTao >= tungay && x.NgayCapNhap <= toingay)
                             select new
                             {
                                 TenMatHang = a.TenMatHang,
                                 DonGia = a.DonGia,
                                 SoLuong = a.SoLuong,
                                 Ngay = a.NgayTao,
                                 Tongtien = a.DonGia * a.SoLuong

                             }).ToList();
                            dataGridView1.DataSource = data;
                            LoadText();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    var data = (from a in _MatHang_Service.GetlstMatHangs().Where(x => x.NgayTao >= tungay && x.NgayCapNhap <= toingay)
                                where a.Id.Equals(a.Id)
                                && a.TenMatHang.Equals(comboBox1.Text)
                                select new
                                {
                                    TenMatHang = a.TenMatHang,
                                    DonGia = a.DonGia,
                                    SoLuong = a.SoLuong,
                                    Ngay = a.NgayTao,
                                    Tongtien = a.DonGia * a.SoLuong
                                }).ToList();
                    dataGridView1.DataSource = data;
                    LoadText();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void LoadMBT()
        {
            mtb_tungay.Text = DateTime.Now.ToString("01/01/2000");
            mtb_toingay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void LoadCBB()
        {
            comboBox1.Items.Add("Tất cả");
            foreach (var x in _MatHang_Service.GetlstMatHangs())
            {
                comboBox1.Items.Add(x.TenMatHang);
            }
        }
        private void LoadText()
        {
            dataGridView1.Columns["TenMatHang"].HeaderText = "Tên mặt hàng";
            dataGridView1.Columns["Dongia"].HeaderText = "Đơn giá";
            dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
            dataGridView1.Columns["Ngay"].HeaderText = "Ngày nhập";
            dataGridView1.Columns["Tongtien"].HeaderText = "Tổng tiền";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}