using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1_DAL.Entities;
using _2_BUS.BUS_MatHang_Service;
using _2_BUS.BUS_Service;
using _2_BUS.IBUS_MatHang_Service;
using _2_BUS.IBUS_Service;
using _3_GUI;

namespace _3_GUI_PresentationLayer
{
    public partial class frm_QLMatHang : Form
    {
        private IBUS_MatHang_Service _matHangService;
        private static IBUS_DonViTinh_Service _donViTinhService;
        private IBUS_NhanVien_Service _nhanVienService;
        private List<DonViTinh> _dvt;
        private string _nhanvien;

        int x = 20, y = 9, a = 1;
        Random ran = new Random();

        public frm_QLMatHang()
        {
            InitializeComponent();
            _matHangService = new BUS_MatHang_Service();
            _donViTinhService = new BUS_DonViTinh_Service();
            _dvt = new List<DonViTinh>();
            lb_nhanvien.Text = Frm_Main.sendnhanvien().Ho + " " + Frm_Main.sendnhanvien().TenDem + " " +
                          Frm_Main.sendnhanvien().Ten;
        }
        private void frm_QLMatHang_Load(object sender, EventArgs e)
        {
            showdata();
            loadcmbIDDVT();
            dgv_QLMatHang.Columns["Id"].Visible = false;
            dgv_QLMatHang.Columns["TenMatHang"].HeaderText = "Tên mặt hàng";
            dgv_QLMatHang.Columns["DonGia"].HeaderText = "Đơn giá";
            dgv_QLMatHang.Columns["TenDvt"].HeaderText = "Tên DVT";
            dgv_QLMatHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_TenMH.Text)||!string.IsNullOrEmpty(txt_DonGia.Text)) // nếu text box k null
            {
                MatHang matHang = new MatHang();
                matHang.Id = 1;
                if (_matHangService.GetlstMatHangs().Count != 0)
                {
                    matHang.Id = _matHangService.GetlstMatHangs().Max(c => c.Id) + 1;
                }
                matHang.TenMatHang = txt_TenMH.Text;
                matHang.DonGia =Convert.ToInt32(txt_DonGia.Text);
                matHang.SoLuong = int.Parse(txt_soluong.Text);
                matHang.IddonViTinh = _donViTinhService.GetlstDonViTinhs().SingleOrDefault(c=>c.TenDvt==cmb_IDDvTinh.Text).Id;
                matHang.NguoiTao = Frm_Main.sendnhanvien().Ten;
                matHang.NgayTao = DateTime.Now;
                _matHangService.AddMatHangh(matHang);
                MessageBox.Show("Thêm mặt hàng thành công", "hoàn thành", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                showdata();
                txt_TenMH.Text = null;//thêm xong thì textbox rỗng
                txt_DonGia.Text = null;
            }
            else
            {
                MessageBox.Show("vui lòng nhập dữ liệu", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DataGridViewRow r;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            r = dgv_QLMatHang.Rows[e.RowIndex];
            txt_TenMH.Text = r.Cells["TenMatHang"].Value.ToString();
            txt_DonGia.Text = r.Cells["DonGia"].Value.ToString();
            cmb_IDDvTinh.Text = r.Cells["TenDvt"].Value.ToString();
            txt_soluong.Text = r.Cells["Soluong"].Value.ToString();
        }

        private MatHang findMatHang()
        {
            var mh = _matHangService.GetlstMatHangs()
                .SingleOrDefault(x => x.Id == int.Parse(r.Cells["Id"].Value.ToString()));
            return mh;
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("vui lòng chọn mặt hàng cần sửa", "chú ý", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txt_DonGia.Text)||!string.IsNullOrEmpty(txt_TenMH.Text))
            {
                var mh = findMatHang();
                mh.TenMatHang = txt_TenMH.Text;
                mh.DonGia =int.Parse(txt_DonGia.Text);
                mh.IddonViTinh = _donViTinhService.GetlstDonViTinhs().SingleOrDefault(c => c.TenDvt == cmb_IDDvTinh.Text).Id;
                mh.SoLuong = int.Parse(txt_soluong.Text);
                mh.NgayCapNhap=DateTime.Now;
                mh.NguoiCapNhap = Frm_Main.sendnhanvien().Ten;
                if (_matHangService.EditMatHang(mh))
                {
                    MessageBox.Show("Sửa mặt hàng thành công", "thông báo", MessageBoxButtons.OK);
                }
                showdata();
                r = null;
                txt_TenMH.Text = null;
                txt_DonGia.Text = null;
            }
            else
            {
                MessageBox.Show("vui lòng nhập thông tin mặt hàng", "chú ý", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (r==null)
            {
                MessageBox.Show("vui lòng chọn mặt hàng", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn muốn xóa?!","chú ý",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (_matHangService.RemoveMatHang(findMatHang()))
                {
                    MessageBox.Show("Xóa mặt hàng thành công", "thông báo", MessageBoxButtons.OK);
                    showdata();
                    r = null;
                    txt_TenMH.Text = null;
                    txt_DonGia.Text = null;
                }
            }
        }

       
        
       
        private void showdata()
        {
            var data =
                (from a in _matHangService.GetlstMatHangs()
                join b in _donViTinhService.GetlstDonViTinhs()
                    on a.IddonViTinh equals b.Id
                select new
                {
                    a.Id,
                    a.TenMatHang,
                    a.SoLuong,
                    a.DonGia,
                    b.TenDvt,
                }).ToList();
            dgv_QLMatHang.DataSource = data;
        }
        public void loadcmbIDDVT()
        {
            foreach (var x in _donViTinhService.GetlstDonViTinhs())
            {
                cmb_IDDvTinh.Items.Add(x.TenDvt);
            }
        }

        private void btn_themdvt_Click(object sender, EventArgs e)
        {
            frm_menuDanhMuc.loadDVT();
        }
    }
}
