using _1_DAL.Entities;
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
    public partial class frm_Login : Form
    {
        private IBUS_Login_Service _ibus_Login_Service;
        private IBUS_NhanVien_Service _ibus_NhanVien_Service;
        public frm_Login()
        {
            InitializeComponent();
            _ibus_Login_Service = new BUS_Login_Service();
            _ibus_NhanVien_Service = new BUS_NhanVien_Service();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            DialogResult dn;
            string username = txt_DangNhap.Text;
            string passwork = _ibus_Login_Service.MaHoaPass(txt_Passwork.Text);
            if (lbl_Captcha.Text == txt_Captcha.Text)
            {
                dn = MessageBox.Show("Mã code chính xác 🤗🤗🤗", "Thông Báo ❗");
            }
            else
            {
                dn = MessageBox.Show("Mã code không chính xác 🤗🤗🤗\nVui lòng nhập lại ", "Thông Báo ❗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnLoad(e);
                return;
            }
            if (_ibus_Login_Service.NhanVienLogin(username, passwork))
            {
                Frm_Main main = new Frm_Main(username);
                dn = MessageBox.Show("Đăng nhập thành công 🤗🤗🤗", "Thông Báo ❗", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main.Show();
                this.Hide();
            }
            else
            {
                dn = MessageBox.Show("Đăng nhập thất bại 🤨🤨🤨 ! \nVui lòng kiểm tra lại Email hoặc mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn 🤔 Thoát form LOGIN 🤔 ra khỏi chương trình không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_QuenMatKhau quen = new frm_QuenMatKhau();
            this.Hide();
            quen.Show();
        }

        //Nhớ account
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_DangNhap.Text != "" && txt_Passwork.Text != "")
            {
                if (cbx_NhoAccount.Checked == true)
                {
                    string user = txt_DangNhap.Text;
                    Properties.Settings.Default.username = user;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }
        private void frm_Login_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int numb = rand.Next(6, 8);
            int total = 0;
            string captcha = "";
            txt_DangNhap.Text = Properties.Settings.Default.username;
            if (Properties.Settings.Default.username != "")
            {
                cbx_NhoAccount.Checked = true;
            }
            do
            {
                int chr = rand.Next(48, 132);
                if ((chr >= 48 && chr <=57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    total++;
                    if (total == numb)
                        break;
                    {

                    }
                }

            } while (true);
            lbl_Captcha.Text = captcha;
        }

        private void p_hide_Click(object sender, EventArgs e)
        {
            if (txt_Passwork.PasswordChar == '*')
            {
                p_eye.BringToFront();
                txt_Passwork.PasswordChar = '\0';
            }
        }
        private void p_eye_Click(object sender, EventArgs e)
        {
            if (txt_Passwork.PasswordChar == '\0')
            {
                p_hide.BringToFront();
                txt_Passwork.PasswordChar = '*';
            }
        }
    }
}
