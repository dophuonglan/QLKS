namespace KS
{
    partial class fLichLamViec
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
            this.dtgvLichLamViec = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTimLichLamViec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichLamViec)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvLichLamViec
            // 
            this.dtgvLichLamViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLichLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichLamViec.Location = new System.Drawing.Point(1, 148);
            this.dtgvLichLamViec.Name = "dtgvLichLamViec";
            this.dtgvLichLamViec.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgvLichLamViec.Size = new System.Drawing.Size(1037, 148);
            this.dtgvLichLamViec.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lịch Làm Việc";
            // 
            // txbTimLichLamViec
            // 
            this.txbTimLichLamViec.Location = new System.Drawing.Point(422, 102);
            this.txbTimLichLamViec.Name = "txbTimLichLamViec";
            this.txbTimLichLamViec.Size = new System.Drawing.Size(100, 20);
            this.txbTimLichLamViec.TabIndex = 2;
            this.txbTimLichLamViec.TextChanged += new System.EventHandler(this.txbTimLichLamViec_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm kiếm";
            // 
            // fLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTimLichLamViec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvLichLamViec);
            this.Name = "fLichLamViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLichLamViec";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fLichLamViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichLamViec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvLichLamViec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTimLichLamViec;
        private System.Windows.Forms.Label label2;
    }
}