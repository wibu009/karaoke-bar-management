using _2_BUS.BUS_Service;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class frm_QuenMatKhau : Form
    {
        private IBUS_Login_Service _ibus_Login_Service;

        string randomCode;
        public static string to;

        public frm_QuenMatKhau()
        {
            InitializeComponent();
            _ibus_Login_Service = new BUS_Login_Service();
            txt_MaCode.Enabled = false;
            btn_XacNhan.Enabled = false;
        }

        private void btn_GuiMail_Click(object sender, EventArgs e)
        {
            DialogResult dn;
            string from, pass, messagebody;
            Random rd = new Random();
            randomCode = (rd.Next(99999)).ToString();
            MailMessage message = new MailMessage();
            to = (txt_EmailQuenPass.Text).ToString();
            from = "phianhtuan31@gmail.com";
            pass = "anhtuan2002";
            messagebody = "Quán Karaoke Family 🤞🤞🤞\nMã code đặt lại của bạn là: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Dịch vụ quên mật khẩu 🤨";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            txt_EmailQuenPass.Enabled = false;
            btn_GuiMail.Enabled = false;
            try
            {
                smtp.Send(message);
                dn = MessageBox.Show("Gửi mã thành công 🤞🤞🤞 \nVui lòng kiểm tra lại email của bạn để lấy mã code.", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_MaCode.Enabled = true;
                btn_XacNhan.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            DialogResult dn;
            if (randomCode == (txt_MaCode.Text).ToString())
            {
                to = txt_EmailQuenPass.Text;
                dn = MessageBox.Show("Mã code chính xác 👍👍👍", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_DoiMatKhau reset = new frm_DoiMatKhau();
                this.Hide();
                reset.Show();
            }
            else
            {
                dn = MessageBox.Show("Mã code lấy lại mật khẩu sai !\n, Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_QuenMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_Login frmLogin = new frm_Login();
            frmLogin.Show();
            this.Hide();
        }
    }
}
