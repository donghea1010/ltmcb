namespace Bai02
{
    partial class Form5
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
            this.ODia = new System.Windows.Forms.ComboBox();
            this.Go = new System.Windows.Forms.Button();
            this.ThuMuc = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.TenFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KichThuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DuoiMoRong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NgayTao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ODia
            // 
            this.ODia.FormattingEnabled = true;
            this.ODia.Location = new System.Drawing.Point(306, 119);
            this.ODia.Margin = new System.Windows.Forms.Padding(4);
            this.ODia.Name = "ODia";
            this.ODia.Size = new System.Drawing.Size(160, 24);
            this.ODia.TabIndex = 4;
            this.ODia.SelectedIndexChanged += new System.EventHandler(this.ODia_SelectedIndexChanged_1);
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(37, 86);
            this.Go.Margin = new System.Windows.Forms.Padding(4);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(197, 57);
            this.Go.TabIndex = 5;
            this.Go.Text = "Xuất FIle";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click_1);
            // 
            // ThuMuc
            // 
            this.ThuMuc.Location = new System.Drawing.Point(534, 121);
            this.ThuMuc.Margin = new System.Windows.Forms.Padding(4);
            this.ThuMuc.Name = "ThuMuc";
            this.ThuMuc.Size = new System.Drawing.Size(132, 22);
            this.ThuMuc.TabIndex = 6;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenFile,
            this.KichThuoc,
            this.DuoiMoRong,
            this.NgayTao});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(13, 176);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(759, 261);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // TenFile
            // 
            this.TenFile.Text = "Tên File";
            // 
            // KichThuoc
            // 
            this.KichThuoc.Text = "Kích Thước";
            // 
            // DuoiMoRong
            // 
            this.DuoiMoRong.Text = "Đuôi Mở Rộng";
            // 
            // NgayTao
            // 
            this.NgayTao.Text = "Ngày Tạo";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.ThuMuc);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.ODia);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ODia;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.TextBox ThuMuc;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader TenFile;
        private System.Windows.Forms.ColumnHeader KichThuoc;
        private System.Windows.Forms.ColumnHeader DuoiMoRong;
        private System.Windows.Forms.ColumnHeader NgayTao;
    }
}