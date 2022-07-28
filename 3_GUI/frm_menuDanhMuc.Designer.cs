
namespace _3_GUI
{
    partial class frm_menuDanhMuc
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
            this.components = new System.ComponentModel.Container();
            this.btn_Phong = new System.Windows.Forms.Button();
            this.btn_Nhanvien = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            loadform = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_thietbi = new System.Windows.Forms.Button();
            this.btn_ctt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Timer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Phong
            // 
            this.btn_Phong.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Phong.FlatAppearance.BorderSize = 0;
            this.btn_Phong.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Phong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Phong.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Phong.ForeColor = System.Drawing.Color.Black;
            this.btn_Phong.Location = new System.Drawing.Point(524, 0);
            this.btn_Phong.Name = "btn_Phong";
            this.btn_Phong.Size = new System.Drawing.Size(262, 90);
            this.btn_Phong.TabIndex = 0;
            this.btn_Phong.Text = "Phòng";
            this.btn_Phong.UseVisualStyleBackColor = false;
            this.btn_Phong.Click += new System.EventHandler(this.btn_Phong_Click);
            // 
            // btn_Nhanvien
            // 
            this.btn_Nhanvien.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Nhanvien.FlatAppearance.BorderSize = 0;
            this.btn_Nhanvien.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Nhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Nhanvien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Nhanvien.ForeColor = System.Drawing.Color.Black;
            this.btn_Nhanvien.Location = new System.Drawing.Point(786, 0);
            this.btn_Nhanvien.Name = "btn_Nhanvien";
            this.btn_Nhanvien.Size = new System.Drawing.Size(262, 90);
            this.btn_Nhanvien.TabIndex = 0;
            this.btn_Nhanvien.Text = "Nhân Viên";
            this.btn_Nhanvien.UseVisualStyleBackColor = false;
            this.btn_Nhanvien.Click += new System.EventHandler(this.btn_Nhanvien_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(262, 90);
            this.button3.TabIndex = 0;
            this.button3.Text = "Mặt Hàng";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // loadform
            // 
            loadform.Location = new System.Drawing.Point(0, 100);
            loadform.Name = "loadform";
            loadform.Size = new System.Drawing.Size(1310, 740);
            loadform.TabIndex = 1;
            // 
            // btn_thietbi
            // 
            this.btn_thietbi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_thietbi.FlatAppearance.BorderSize = 0;
            this.btn_thietbi.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_thietbi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thietbi.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_thietbi.ForeColor = System.Drawing.Color.Black;
            this.btn_thietbi.Location = new System.Drawing.Point(262, 0);
            this.btn_thietbi.Name = "btn_thietbi";
            this.btn_thietbi.Size = new System.Drawing.Size(262, 90);
            this.btn_thietbi.TabIndex = 1;
            this.btn_thietbi.Text = "Thiết bị";
            this.btn_thietbi.UseVisualStyleBackColor = false;
            this.btn_thietbi.Click += new System.EventHandler(this.btn_thietbi_Click);
            // 
            // btn_ctt
            // 
            this.btn_ctt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_ctt.FlatAppearance.BorderSize = 0;
            this.btn_ctt.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_ctt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ctt.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ctt.ForeColor = System.Drawing.Color.Black;
            this.btn_ctt.Location = new System.Drawing.Point(1048, 0);
            this.btn_ctt.Name = "btn_ctt";
            this.btn_ctt.Size = new System.Drawing.Size(262, 90);
            this.btn_ctt.TabIndex = 1;
            this.btn_ctt.Text = "Công thức tính";
            this.btn_ctt.UseVisualStyleBackColor = false;
            this.btn_ctt.Click += new System.EventHandler(this.btn_ctt_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ctt);
            this.panel1.Controls.Add(this.btn_thietbi);
            this.panel1.Controls.Add(this.btn_Nhanvien);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btn_Phong);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 100);
            this.panel1.TabIndex = 2;
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.AutoSize = true;
            this.lbl_Timer.Font = new System.Drawing.Font("Showcard Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Timer.ForeColor = System.Drawing.Color.Red;
            this.lbl_Timer.Location = new System.Drawing.Point(166, 9);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(882, 42);
            this.lbl_Timer.TabIndex = 22;
            this.lbl_Timer.Text = "KARAOKE FAMILY - 216 Phúc Tân - Hoàn Kiếm - Hà Nội";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Timer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 840);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1310, 60);
            this.panel2.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_menuDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1310, 900);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(loadform);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_menuDanhMuc";
            this.Text = "frm_menuDanhMuc";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Phong;
        private System.Windows.Forms.Button btn_Nhanvien;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_thietbi;
        private System.Windows.Forms.Button btn_ctt;
        private System.Windows.Forms.Panel panel1;
        public static System.Windows.Forms.Panel loadform;
        private System.Windows.Forms.Label lbl_Timer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
    }
}