namespace KS
{
    partial class fAddThongTinPhg
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
            this.txbAddGiaPhg = new System.Windows.Forms.TextBox();
            this.txbAddLoaiPhg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSubMitAddPhg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txbAddTenPhg = new System.Windows.Forms.TextBox();
            this.labTBSaiTenPhg = new System.Windows.Forms.Label();
            this.labTBSaiLoaiPhg = new System.Windows.Forms.Label();
            this.labTBSaiGiaPhg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbAddDonViTT = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbThongBaoDonViTienTe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDonViTienTe = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbAddGiaPhg
            // 
            this.txbAddGiaPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddGiaPhg.Location = new System.Drawing.Point(358, 64);
            this.txbAddGiaPhg.Name = "txbAddGiaPhg";
            this.txbAddGiaPhg.Size = new System.Drawing.Size(157, 24);
            this.txbAddGiaPhg.TabIndex = 4;
            // 
            // txbAddLoaiPhg
            // 
            this.txbAddLoaiPhg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txbAddLoaiPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddLoaiPhg.FormattingEnabled = true;
            this.txbAddLoaiPhg.Items.AddRange(new object[] {
            "Cao Cấp",
            "Tiêu Chuẩn"});
            this.txbAddLoaiPhg.Location = new System.Drawing.Point(89, 136);
            this.txbAddLoaiPhg.Name = "txbAddLoaiPhg";
            this.txbAddLoaiPhg.Size = new System.Drawing.Size(157, 26);
            this.txbAddLoaiPhg.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên Phòng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Loại Phòng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Giá Phòng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Mô tả";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 14;
            // 
            // btnSubMitAddPhg
            // 
            this.btnSubMitAddPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubMitAddPhg.Location = new System.Drawing.Point(244, 306);
            this.btnSubMitAddPhg.Name = "btnSubMitAddPhg";
            this.btnSubMitAddPhg.Size = new System.Drawing.Size(72, 33);
            this.btnSubMitAddPhg.TabIndex = 15;
            this.btnSubMitAddPhg.Text = "Thêm";
            this.btnSubMitAddPhg.UseVisualStyleBackColor = true;
            this.btnSubMitAddPhg.Click += new System.EventHandler(this.btnSubMitAddPhg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(191, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 29);
            this.label7.TabIndex = 16;
            this.label7.Text = "THÊM PHÒNG MỚI";
            // 
            // txbAddTenPhg
            // 
            this.txbAddTenPhg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddTenPhg.Location = new System.Drawing.Point(89, 64);
            this.txbAddTenPhg.Name = "txbAddTenPhg";
            this.txbAddTenPhg.Size = new System.Drawing.Size(157, 24);
            this.txbAddTenPhg.TabIndex = 17;
            // 
            // labTBSaiTenPhg
            // 
            this.labTBSaiTenPhg.ForeColor = System.Drawing.Color.Red;
            this.labTBSaiTenPhg.Location = new System.Drawing.Point(86, 96);
            this.labTBSaiTenPhg.Name = "labTBSaiTenPhg";
            this.labTBSaiTenPhg.Size = new System.Drawing.Size(160, 23);
            this.labTBSaiTenPhg.TabIndex = 19;
            this.labTBSaiTenPhg.Text = "Không được bỏ trống phần này";
            this.labTBSaiTenPhg.Visible = false;
            // 
            // labTBSaiLoaiPhg
            // 
            this.labTBSaiLoaiPhg.ForeColor = System.Drawing.Color.Red;
            this.labTBSaiLoaiPhg.Location = new System.Drawing.Point(86, 172);
            this.labTBSaiLoaiPhg.Name = "labTBSaiLoaiPhg";
            this.labTBSaiLoaiPhg.Size = new System.Drawing.Size(160, 23);
            this.labTBSaiLoaiPhg.TabIndex = 20;
            this.labTBSaiLoaiPhg.Text = "Không được bỏ trống phần này";
            this.labTBSaiLoaiPhg.Visible = false;
            // 
            // labTBSaiGiaPhg
            // 
            this.labTBSaiGiaPhg.ForeColor = System.Drawing.Color.Red;
            this.labTBSaiGiaPhg.Location = new System.Drawing.Point(350, 96);
            this.labTBSaiGiaPhg.Name = "labTBSaiGiaPhg";
            this.labTBSaiGiaPhg.Size = new System.Drawing.Size(160, 23);
            this.labTBSaiGiaPhg.TabIndex = 21;
            this.labTBSaiGiaPhg.Text = "Không được bỏ trống phần này";
            this.labTBSaiGiaPhg.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbThongBaoDonViTienTe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbDonViTienTe);
            this.panel1.Controls.Add(this.txbAddDonViTT);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labTBSaiGiaPhg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbAddTenPhg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labTBSaiLoaiPhg);
            this.panel1.Controls.Add(this.txbAddGiaPhg);
            this.panel1.Controls.Add(this.btnSubMitAddPhg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labTBSaiTenPhg);
            this.panel1.Controls.Add(this.txbAddLoaiPhg);
            this.panel1.Location = new System.Drawing.Point(29, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 364);
            this.panel1.TabIndex = 25;
            // 
            // txbAddDonViTT
            // 
            this.txbAddDonViTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddDonViTT.Location = new System.Drawing.Point(89, 213);
            this.txbAddDonViTT.Multiline = true;
            this.txbAddDonViTT.Name = "txbAddDonViTT";
            this.txbAddDonViTT.Size = new System.Drawing.Size(426, 54);
            this.txbAddDonViTT.TabIndex = 25;
            this.txbAddDonViTT.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::KS.Properties.Resources._489a7166;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(438, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(81, 82);
            this.panel2.TabIndex = 25;
            // 
            // lbThongBaoDonViTienTe
            // 
            this.lbThongBaoDonViTienTe.ForeColor = System.Drawing.Color.Red;
            this.lbThongBaoDonViTienTe.Location = new System.Drawing.Point(350, 172);
            this.lbThongBaoDonViTienTe.Name = "lbThongBaoDonViTienTe";
            this.lbThongBaoDonViTienTe.Size = new System.Drawing.Size(160, 23);
            this.lbThongBaoDonViTienTe.TabIndex = 32;
            this.lbThongBaoDonViTienTe.Text = "Không được bỏ trống phần này";
            this.lbThongBaoDonViTienTe.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "DVTT";
            // 
            // cbbDonViTienTe
            // 
            this.cbbDonViTienTe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDonViTienTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDonViTienTe.FormattingEnabled = true;
            this.cbbDonViTienTe.Items.AddRange(new object[] {
            "VNĐ"});
            this.cbbDonViTienTe.Location = new System.Drawing.Point(358, 136);
            this.cbbDonViTienTe.Name = "cbbDonViTienTe";
            this.cbbDonViTienTe.Size = new System.Drawing.Size(157, 26);
            this.cbbDonViTienTe.TabIndex = 30;
            // 
            // fAddThongTinPhg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(622, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.MinimizeBox = false;
            this.Name = "fAddThongTinPhg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAddThongTinPhg";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbAddGiaPhg;
        private System.Windows.Forms.ComboBox txbAddLoaiPhg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSubMitAddPhg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbAddTenPhg;
        private System.Windows.Forms.Label labTBSaiTenPhg;
        private System.Windows.Forms.Label labTBSaiLoaiPhg;
        private System.Windows.Forms.Label labTBSaiGiaPhg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbAddDonViTT;
        private System.Windows.Forms.Label lbThongBaoDonViTienTe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDonViTienTe;
    }
}