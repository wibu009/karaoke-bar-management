using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using _2_BUS.IBUS_Service;
using _2_BUS.BUS_Service;

namespace _3_GUI
{
    public partial class frm_DoiMatKhau : Form
    {
        private IBUS_Login_Service _ibus_Login_Service;
        string username;
        public frm_DoiMatKhau()
        {
            InitializeComponent();
            _ibus_Login_Service = new BUS_Login_Service();
            username = frm_QuenMatKhau.to;
            button2.Visible = true;
            button3.Visible = false;
        }
        public frm_DoiMatKhau(string usernamee)
        {
            InitializeComponent();
            _ibus_Login_Service = new BUS_Login_Service();
            username = usernamee;
            txt_taikhoan.Text = usernamee;
            button2.Visible = false;
            button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dn;
            if (txt_NhapPassNew.Text == txt_NhapLaiPassNew.Text)
            {
                SqlConnection _con = new SqlConnection("Data Source=DESKTOP-V4BEME9\\SQLEXPRESS01;Initial Catalog=QLBH_DuAn1_Karaoke;User ID=tuanpa03;Password=2002");
                SqlCommand _cmd = new SqlCommand("UPDATE [dbo].[NhanVien] SET [Password] = '"+_ibus_Login_Service.MaHoaPass(txt_NhapLaiPassNew.Text)+ "' WHERE Username = '"+username+"'", _con);
                _con.Open();
                _cmd.ExecuteNonQuery();
                _con.Close();
                dn = MessageBox.Show("Đổi mật khẩu thành công 🤗🤗🤗", "Thông Báo ❗", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mật khẩu không khớp, vui lòng kiểm tra lại !");
                txt_NhapLaiPassNew.Focus();
            }
        }

        private void cbx_Show_Pass_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_NhapPassNew.PasswordChar == '*' && txt_NhapLaiPassNew.PasswordChar == '*')
            {
                txt_NhapLaiPassNew.PasswordChar = '\0';
                txt_NhapPassNew.PasswordChar = '\0';
            }
            else
            {
                txt_NhapLaiPassNew.PasswordChar = '*';
                txt_NhapPassNew.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Login lg = new frm_Login();
            this.Hide();
            lg.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_Login lg = new frm_Login();
            this.Hide();
            lg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
