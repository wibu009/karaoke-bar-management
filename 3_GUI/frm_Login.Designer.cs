
namespace _3_GUI
{
    partial class frm_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.txt_DangNhap = new System.Windows.Forms.TextBox();
            this.txt_Passwork = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbx_NhoAccount = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Captcha = new System.Windows.Forms.Label();
            this.txt_Captcha = new System.Windows.Forms.TextBox();
            this.p_eye = new System.Windows.Forms.PictureBox();
            this.p_hide = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_hide)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập hệ thống";
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.Black;
            this.btn_DangNhap.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_DangNhap.ForeColor = System.Drawing.Color.White;
            this.btn_DangNhap.Location = new System.Drawing.Point(208, 315);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(190, 58);
            this.btn_DangNhap.TabIndex = 1;
            this.btn_DangNhap.Text = "LOGIN";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.Black;
            this.btn_Thoat.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Thoat.ForeColor = System.Drawing.Color.White;
            this.btn_Thoat.Location = new System.Drawing.Point(404, 315);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(192, 58);
            this.btn_Thoat.TabIndex = 1;
            this.btn_Thoat.Text = "EXIT";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // txt_DangNhap
            // 
            this.txt_DangNhap.BackColor = System.Drawing.Color.White;
            this.txt_DangNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_DangNhap.Location = new System.Drawing.Point(208, 150);
            this.txt_DangNhap.Name = "txt_DangNhap";
            this.txt_DangNhap.PlaceholderText = "Email...";
            this.txt_DangNhap.Size = new System.Drawing.Size(449, 34);
            this.txt_DangNhap.TabIndex = 2;
            // 
            // txt_Passwork
            // 
            this.txt_Passwork.BackColor = System.Drawing.Color.White;
            this.txt_Passwork.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Passwork.Location = new System.Drawing.Point(208, 190);
            this.txt_Passwork.Name = "txt_Passwork";
            this.txt_Passwork.PasswordChar = '*';
            this.txt_Passwork.PlaceholderText = "Password...";
            this.txt_Passwork.Size = new System.Drawing.Size(449, 34);
            this.txt_Passwork.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.Location = new System.Drawing.Point(484, 239);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(173, 26);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbx_NhoAccount
            // 
            this.cbx_NhoAccount.AutoSize = true;
            this.cbx_NhoAccount.BackColor = System.Drawing.Color.Transparent;
            this.cbx_NhoAccount.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_NhoAccount.Location = new System.Drawing.Point(208, 237);
            this.cbx_NhoAccount.Name = "cbx_NhoAccount";
            this.cbx_NhoAccount.Size = new System.Drawing.Size(158, 29);
            this.cbx_NhoAccount.TabIndex = 8;
            this.cbx_NhoAccount.Text = "Nhớ tài khoản";
            this.cbx_NhoAccount.UseVisualStyleBackColor = false;
            this.cbx_NhoAccount.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(190, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(478, 53);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quán Karaoke Family\r\n";
            // 
            // lbl_Captcha
            // 
            this.lbl_Captcha.AutoSize = true;
            this.lbl_Captcha.BackColor = System.Drawing.Color.Aqua;
            this.lbl_Captcha.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Captcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_Captcha.Location = new System.Drawing.Point(508, 271);
            this.lbl_Captcha.Name = "lbl_Captcha";
            this.lbl_Captcha.Size = new System.Drawing.Size(143, 37);
            this.lbl_Captcha.TabIndex = 3;
            this.lbl_Captcha.Text = "Captcha ";
            // 
            // txt_Captcha
            // 
            this.txt_Captcha.BackColor = System.Drawing.Color.White;
            this.txt_Captcha.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Captcha.Location = new System.Drawing.Point(208, 272);
            this.txt_Captcha.Name = "txt_Captcha";
            this.txt_Captcha.PlaceholderText = "Code...";
            this.txt_Captcha.Size = new System.Drawing.Size(262, 34);
            this.txt_Captcha.TabIndex = 2;
            // 
            // p_eye
            // 
            this.p_eye.BackColor = System.Drawing.Color.Transparent;
            this.p_eye.Image = ((System.Drawing.Image)(resources.GetObject("p_eye.Image")));
            this.p_eye.Location = new System.Drawing.Point(615, 196);
            this.p_eye.Name = "p_eye";
            this.p_eye.Size = new System.Drawing.Size(35, 26);
            this.p_eye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_eye.TabIndex = 5;
            this.p_eye.TabStop = false;
            this.p_eye.Click += new System.EventHandler(this.p_eye_Click);
            // 
            // p_hide
            // 
            this.p_hide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.p_hide.Image = ((System.Drawing.Image)(resources.GetObject("p_hide.Image")));
            this.p_hide.Location = new System.Drawing.Point(615, 196);
            this.p_hide.Name = "p_hide";
            this.p_hide.Size = new System.Drawing.Size(35, 26);
            this.p_hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_hide.TabIndex = 5;
            this.p_hide.TabStop = false;
            this.p_hide.Click += new System.EventHandler(this.p_hide_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(190, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(482, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "----------------------------------------------------";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(679, 376);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_NhoAccount);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbl_Captcha);
            this.Controls.Add(this.txt_Captcha);
            this.Controls.Add(this.txt_DangNhap);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p_hide);
            this.Controls.Add(this.p_eye);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_Passwork);
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN KARAOKE";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_hide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.TextBox txt_DangNhap;
        private System.Windows.Forms.TextBox txt_Passwork;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox cbx_NhoAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Captcha;
        private System.Windows.Forms.TextBox txt_Captcha;
        private System.Windows.Forms.PictureBox p_eye;
        private System.Windows.Forms.PictureBox p_hide;
        private System.Windows.Forms.Label label2;
    }
}