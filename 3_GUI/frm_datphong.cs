using _1_DAL.Entities;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_Service;
using _3_GUI_PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class frm_datphong : Form
    {
        private IBUS_Phong_Service _iBUS_Phong_Service;
        private IBUS_Tang_Service _iBUS_Tang_Service;
        private IBUS_HoaDonBanHang_Service _ihoaDonBanHang_Service;
        private IBUS_KhachHang_Service _ibUS_KhachHang_Service;

        Label lb;
        int x = 20, y = 9, a = 1;
        Random ran = new Random();

        string _tenPhong;
        int _idPhongDatPhong;
        int _idPhongCapNhapPhong;
        int _idPhongDonPhong;
        string _idHoaDonTruyenThanhToan;
        string _idPhongTruyenThanhToan;
        //string _giodonphong;
        List<Phong> _lstPhong = new List<Phong>();
        private System.Windows.Forms.Timer aTimer;
        private int counter = 600;
        public frm_datphong()
        {
            InitializeComponent();
            _iBUS_Phong_Service = new BUS_Phong_Service();
            _lstPhong = _iBUS_Phong_Service.sendlstPhong();
            _iBUS_Tang_Service = new BUS_Tang_Service();
            _ihoaDonBanHang_Service = new BUS_HoaDonBanHang_Service();
            _ibUS_KhachHang_Service = new BUS_KhachHang_Service();
            showRoom();

        }
        public frm_datphong(string idHoaDon111 /*, string khachHang111, string tgianBD111*/, string idPhong111)
        {
            InitializeComponent();
            _iBUS_Phong_Service = new BUS_Phong_Service();
            _lstPhong = _iBUS_Phong_Service.sendlstPhong();
            _iBUS_Tang_Service = new BUS_Tang_Service();
            _ihoaDonBanHang_Service = new BUS_HoaDonBanHang_Service();
            _ibUS_KhachHang_Service = new BUS_KhachHang_Service();
            _idHoaDonTruyenThanhToan = idHoaDon111;
            _idPhongTruyenThanhToan = idHoaDon111;
            showRoom();
        }
        void showRoom()
        {

            tableLayoutPanel1.Controls.Clear();
            int tang = Convert.ToInt32((_iBUS_Phong_Service.sendlstPhong().Count) / 5 + 0.9 + 2);
            //int tang = Convert.ToInt32(_iBUS_Phong_Service.sendlstPhong().Max(x=>x.TenPhong.Substring(0, 1)));
            //int tang = Convert.ToInt32;
            int tang1 = Convert.ToInt32( _iBUS_Tang_Service.sendlstTang().Where(x => x.IdtrangThai == 1).ToList().Count);
            //tableLayoutPanel1.RowCount = tang;
            for (int i = 0; i < tang1; i++)
            {
                for (int j = 0; j < _iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1 && Convert.ToInt32( x.IdtranngThai) ==1).ToList().Count; j++)
                {
                    //Label
                    lb = new Label();
                    lb.Size = new Size(250, 150);
                    string tenPhong = "Phòng " + _iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1 && Convert.ToInt32(x.IdtranngThai) == 1).ToList()[j].TenPhong;
                    lb.Name = Convert.ToString(_iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1 && Convert.ToInt32(x.IdtranngThai) == 1).ToList()[j].Id);
                    string maKh;
                    string gioVao;
                    string str = tenPhong + "\n" + "Mã khách hàng" /*+ maKh*/ + "\n" + "Giờ Bắt Đầu" /*+ gioVao*/;
                    lb.Text = str;
                    lb.Text = tenPhong;
                    lb.BackColor = Color.Red;
                    lb.Font = new Font("Arial", 12, FontStyle.Regular);
                    lb.Padding = new Padding(10, 10, 10, 10);
                    int _trangThai = Convert.ToInt32(_iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1).ToList()[j].TrangThai);
                    if (_trangThai == 1)
                    {
                        lb.BackColor = Color.Red;//phòng trống
                    }
                    else if (_trangThai == 2)
                    {
                        lb.BackColor = Color.Yellow;//đang dọn
                        lb.ForeColor = Color.Gray;//màu chữ
                    }
                    else if (_trangThai == 3)
                    {
                        lb.BackColor = Color.Blue;//có khách
                    }
                    else if (_trangThai == 4)
                    {
                        lb.BackColor = Color.Gray;//Phòng cần sửa
                    }
                    tableLayoutPanel1.Controls.Add(lb, j, i);
                    lb.Margin = new Padding(5, 5, 5, 5);
                    tableLayoutPanel1.ColumnCount++;

                    //dọn phòng
                    if (lb.Name == _idPhongDonPhong.ToString())//dọn phòng
                    {
                        //string thoiGian = counter.ToString();
                        DateTime thoiGianbg = DateTime.Now;
                        lb.Text = tenPhong + "\n" + "Tgian bắt đầu dọn:" + thoiGianbg + "\n" + "Thời gian dọn:" + 10 /*counter*/ + "phút" /*+ "\n" + "Thời gian còn lại:"+_giodonphong*/;
                    }
                    if (_lstPhong.FirstOrDefault(x => x.TrangThai == 2) == null)
                    {
                        
                    }else
                    {
                        var phongDon = _lstPhong.FirstOrDefault(x => x.TrangThai == 2);
                        if (lb.Name == phongDon.Id.ToString())
                        {
                            lb.Text = phongDon.TenPhong + "\n" + "Tgian bắt đầu dọn:" + phongDon.NgayCapNhap + "\n" + "Thời gian dọn:" + 10 /*counter*/ + "phút" /*+ "\n" + "Thời gian còn lại:"+_giodonphong*/;
                            var tongthoigianDaDon = DateTime.Now - phongDon.NgayCapNhap.Value;
                            //MessageBox.Show(thoigianDon.ToString());
                            int soGiayDaDon = (tongthoigianDaDon.Hours * 60 * 60) + (tongthoigianDaDon.Minutes * 60 )+ tongthoigianDaDon.Seconds;
                            if (600 < soGiayDaDon)
                            {          
                                phongDon.TrangThai = 1;
                                _iBUS_Phong_Service.Update(phongDon);
                                MessageBox.Show("Phòng " + phongDon.TenPhong.ToString() + "đã dọn xong");
                            }
                            else
                            {

                            }

                        }

                    }
                    //if (_lstPhong.Where(x=>x.Id == Convert.ToInt32(lb.Name)).FirstOrDefault().TrangThai == 2)//dọn phòng
                    //{
                    //   // DateTime thoiGianbg = DateTime.Now;
                    //    lb.Text = tenPhong + "\n" + "Tgian bắt đầu dọn:" + thoiGianbg + "\n" + "Thời gian dọn:" + 600 /*counter*/ + "giây" /*+ "\n" + "Thời gian còn lại:"+_giodonphong*/;
                    //}
                    //tableLayoutPanel1.RowCount++;
                    foreach (var x in _lstPhong)
                    {
                        if (_lstPhong.FirstOrDefault(x => x.Id.ToString() == lb.Name).TrangThai == 3)
                        {

                            var hoaDon = _ihoaDonBanHang_Service.sendlstHoaDonBanHang().FirstOrDefault(y => y.Idphong.ToString() == lb.Name && y.IdtranngThai == 1);
                            var khachHang = _ibUS_KhachHang_Service.GetlstKhachHangs().FirstOrDefault(x => x.MaKh == hoaDon.IdmaKh);
                            lb.Text = tenPhong + "\n" + "Khách hàng :\n" + khachHang.Ho + khachHang.TenDem + khachHang.Ten + "\n" + "Thời gian vào :\n" + hoaDon.ThoiGianBatDau + "\n";

                        }
                    }
                }
            }
        }
        private void stripMenu_datPhong_Click(object sender, EventArgs e)
        {
            try
            {
                var index = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
                if (tableLayoutPanel1.GetControlFromPosition(index.X, index.Y) == null)
                {
                    return;
                }
                _idPhongDatPhong = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(index.X, index.Y).Name);

                //MessageBox.Show(_idPhongDatPhong.ToString());

                var phongload = _lstPhong.FirstOrDefault(x => x.Id == _idPhongDatPhong);
                if (phongload.TrangThai == 2)
                {
                    MessageBox.Show("Phòng đang dọn, không thể Đặt phòng", "Thông báo");
                    return;
                }
                if (phongload.TrangThai == 3)
                {
                    MessageBox.Show("Phòng đang có khách, không thể Đặt phòng", "Thông báo");
                    return;
                }
                if (phongload.TrangThai == 4)
                {
                    MessageBox.Show("Phòng chưa dọn, không thể Đặt phòng", "Thông báo");
                    return;
                }
                //frm_DatPhongKhachHang frm_DatPhongKhachHang = new frm_DatPhongKhachHang(_idPhongDatPhong.ToString());
                ////frm_Login.MdiParent = this.MdiParent;
                //frm_DatPhongKhachHang.Show();
                frm_KhachHang frmKhachHang = new frm_KhachHang(_idPhongDatPhong);
                frmKhachHang.Show();
            }
            catch (Exception ex)
            {
            }



        }
        private void stripMenu_capNhap_Click(object sender, EventArgs e)
        {
            try
            {
                var index = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
                if (tableLayoutPanel1.GetControlFromPosition(index.X, index.Y) == null)
                {
                    return;
                }
                _idPhongCapNhapPhong = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(index.X, index.Y).Name);


                var phongload = _lstPhong.FirstOrDefault(x => x.Id == _idPhongCapNhapPhong);
                if (phongload.TrangThai == 2)
                {
                    MessageBox.Show("Phòng đang dọn, không thể Cập nhập phòng", "Thông báo");
                    return;
                }
                if (phongload.TrangThai == 1)
                {
                    MessageBox.Show("Phòng chưa được đặt, không thể Cập nhập phòng", "Thông báo");
                    return;
                }
                if (phongload.TrangThai == 4)
                {
                    MessageBox.Show("Phòng chưa dọn, không thể Cập nhập phòng", "Thông báo");
                    return;
                }

                Frm_Main.loadthanhtoan(_idPhongCapNhapPhong);
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        private void stripMenu_donPhong_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var x in _lstPhong)
                {
                    if (Convert.ToInt32(x.TrangThai) == 2)
                    {
                        MessageBox.Show("Không thể dọn ! Có Phòng đang dọn", "Thông báo");
                        return;
                    }
                }
                var index = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
                if (tableLayoutPanel1.GetControlFromPosition(index.X, index.Y) == null)
                {
                    return;
                }
                _idPhongDonPhong = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(index.X, index.Y).Name);
                if (Convert.ToInt32(_lstPhong.FirstOrDefault(x => x.Id == _idPhongDonPhong).TrangThai) == 2)
                {
                    MessageBox.Show("Phòng đang dọn", "Thông báo"/*,Thread.Sleep(3000)*/);
                    return;
                }

                var phongload = _lstPhong.FirstOrDefault(x => x.Id == _idPhongDonPhong);

                if (phongload.TrangThai == 3)
                {
                    MessageBox.Show("Phòng đang có khách, không thể Dọn phòng phòng", "Thông báo");
                    return;
                }

                foreach (var x in _lstPhong)
                {
                    if (Convert.ToInt32(x.TrangThai) == 2)
                    {
                        MessageBox.Show("Không thể dọn ! Có Phòng đang dọn", "Thông báo");
                        return;
                    }
                }
                var phong = _iBUS_Phong_Service.Find(_idPhongDonPhong).FirstOrDefault();
                phong.TrangThai = 2;
                phong.NgayCapNhap = DateTime.Now;
                _iBUS_Phong_Service.Update(phong);
                //showRoom();
                aTimer = new System.Windows.Forms.Timer();

                aTimer.Tick += new EventHandler(aTimer_Tick);

                aTimer.Interval = 1000; // 1 second

                aTimer.Start();

                // label1.Text = counter.ToString();
                counter = 600;
                showRoom();
                counter = 600;
                //_tgianChayNguoc = 10.ToString();
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }
        private void aTimer_Tick(object sender, EventArgs e)

        {
            counter--;
            if (counter == 0 || counter == -600 || counter == -1200)
            {
                aTimer.Stop();
                MessageBox.Show("Phòng" + _lstPhong.FirstOrDefault(x => x.Id == _idPhongDonPhong).TenPhong + "đã dọn phòng xong", "Thông báo");
                var phong = _iBUS_Phong_Service.Find(_idPhongDonPhong).FirstOrDefault();
                phong.TrangThai = 1;
                _iBUS_Phong_Service.Update(phong);
                showRoom();
            }
            btn_phongDangDon.Text = "Phòng đang dọn: " + counter.ToString()/* + "giây"*/;
        }

        private void đătPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frm_Phong frm_phong = new frm_Phong();
                //frm_Login.MdiParent = this.MdiParent;
                frm_phong.Show();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
        private void loadDonPhong()
        {
            var phongDon = _lstPhong.FirstOrDefault(x => x.TrangThai == 2);
            if (phongDon.TrangThai == 2)
            {
                //int thoigianDon = DateTime.Now - phongDon.NgayCapNhap;
            }

        }
        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            var index = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
            _idPhongDatPhong = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(index.X, index.Y).Name);
            MessageBox.Show(Convert.ToString(_idPhongDatPhong));

        }
        public Point GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return new Point(0, 0);

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }
        private void thongKe(int a)
        {
            tableLayoutPanel1.Controls.Clear();
            int tang = Convert.ToInt32((_iBUS_Phong_Service.sendlstPhong().Count) / 5 + 0.9 + 2);
            int tang1 = Convert.ToInt32(_iBUS_Tang_Service.sendlstTang().Where(x => x.IdtrangThai == 1).ToList().Count);
            //tableLayoutPanel1.RowCount = tang;
            for (int i = 0; i < tang1; i++)
            {
                for (int j = 0; j < _iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1 && Convert.ToInt32(x.TrangThai) == a && Convert.ToInt32(x.IdtranngThai) == 1).ToList().Count; j++)
                {
                    Label lb = new Label();
                    lb.Size = new Size(250, 150);
                    string tenPhong = "Phòng" + _iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1 && Convert.ToInt32(x.TrangThai) == a && Convert.ToInt32(x.IdtranngThai) == 1).ToList()[j].TenPhong;
                    string maKh = "Mã khách hàng";
                    string gioVao = "Giờ Bắt Đầu";
                    string str = tenPhong + "\n" + maKh + "\n" + gioVao;
                    lb.Text = str;
                    lb.Text = _tenPhong;
                    lb.Name = Convert.ToString(_iBUS_Phong_Service.sendlstPhong().Where(x => x.Idtang == i + 1 && Convert.ToInt32(x.TrangThai) == a && Convert.ToInt32(x.IdtranngThai) == 1).ToList()[j].Id);
                    tableLayoutPanel1.Controls.Add(lb, j, i);
                    lb.Margin = new Padding(5, 5, 5, 5);
                    if (a == 1)
                    {
                        lb.BackColor = Color.Red;//phòng trống
                    }
                    else if (a == 2)
                    {
                        lb.BackColor = Color.Yellow;//đang dọn
                        lb.ForeColor = Color.Gray;
                    }
                    else if (a == 3)
                    {
                        lb.BackColor = Color.Blue;//có khách
                    }
                    else if (a == 4)
                    {
                        lb.BackColor = Color.Gray;//đang sửa chữa
                    }


                    //dọn phòng
                    if (lb.Name == _idPhongDonPhong.ToString())//dọn phòng
                    {
                        //string thoiGian = counter.ToString();
                        DateTime thoiGianbg = DateTime.Now;
                        lb.Text = tenPhong + /*"\n" + "Tgian bắt đầu dọn:" + thoiGianbg + */"\n" + "Thời gian dọn:" + 10 /*counter*/ + "phút" /*+ "\n" + "Thời gian còn lại:"+_giodonphong*/;
                    }
                    foreach (var x in _lstPhong)
                    {
                        if (_lstPhong.FirstOrDefault(x => x.Id.ToString() == lb.Name).TrangThai == 3)
                        {

                            var hoaDon = _ihoaDonBanHang_Service.sendlstHoaDonBanHang().FirstOrDefault(y => y.Idphong.ToString() == lb.Name && y.IdtranngThai == 1);
                            var khachHang = _ibUS_KhachHang_Service.GetlstKhachHangs().FirstOrDefault(x => x.MaKh == hoaDon.IdmaKh);
                            lb.Text = tenPhong + "\n" + "Khách hàng :" + khachHang.Ho + khachHang.TenDem + khachHang.Ten + "\n" + "Thời gian vào:" + hoaDon.ThoiGianBatDau + "\n";

                        }
                    }
                    foreach (var x in _lstPhong)
                    {
                        if (_lstPhong.FirstOrDefault(x => x.Id.ToString() == lb.Name).TrangThai == 1)
                        {
                            lb.Text = tenPhong;
                        }
                        if (_lstPhong.FirstOrDefault(x => x.Id.ToString() == lb.Name).TrangThai == 4)
                        {
                            lb.Text = tenPhong;
                        }
                        if (_lstPhong.FirstOrDefault(x => x.Id.ToString() == lb.Name).TrangThai == 2)
                        {
                            lb.Text = tenPhong +  "\n" + "Thời gian dọn:" + 10 /*counter*/ + "phút";
                        }
                    }
                }
            }
        }


        private void btn_sanSangDonKhach_Click(object sender, EventArgs e)
        {
            thongKe(1);
        }

        private void btn_phongDangDon_Click(object sender, EventArgs e)
        {
            thongKe(2);
        }
        private void btn_phongCoKhach_Click(object sender, EventArgs e)
        {
            thongKe(3);
        }

        private void btn_phongdangSuaChua_Click(object sender, EventArgs e)
        {
            thongKe(4);
        }

        private void frm_datphong_Load(object sender, EventArgs e)
        {
            showRoom();
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {


        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right /*e.Location == MouseButtons.Right*/)
            //{

            //    int idphong;
            //    var index = GetRowColIndex(tableLayoutPanel1, tableLayoutPanel1.PointToClient(Cursor.Position));
            //    //if (index == null || index == new Point(0,0))
            //    //{
            //    //    return;
            //    //}
            //    //else
            //    //{
            //        idphong = Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(index.X, index.Y).Name);
            //        this.tableLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
            //        if (_lstPhong.FirstOrDefault(x => x.Id == idphong).TrangThai == 1)

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
    }
}
