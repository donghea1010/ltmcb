namespace Bai02
{
    partial class Form1
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
            this.Data = new System.Windows.Forms.TextBox();
            this.KetQua = new System.Windows.Forms.TextBox();
            this.Doc = new System.Windows.Forms.Button();
            this.Xoa = new System.Windows.Forms.Button();
            this.Thoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(501, 35);
            this.Data.Margin = new System.Windows.Forms.Padding(4);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(132, 22);
            this.Data.TabIndex = 0;
            this.Data.TextChanged += new System.EventHandler(this.Data_TextChanged);
            // 
            // KetQua
            // 
            this.KetQua.Location = new System.Drawing.Point(112, 388);
            this.KetQua.Margin = new System.Windows.Forms.Padding(4);
            this.KetQua.Name = "KetQua";
            this.KetQua.Size = new System.Drawing.Size(132, 22);
            this.KetQua.TabIndex = 1;
            this.KetQua.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Doc
            // 
            this.Doc.Location = new System.Drawing.Point(725, 117);
            this.Doc.Margin = new System.Windows.Forms.Padding(4);
            this.Doc.Name = "Doc";
            this.Doc.Size = new System.Drawing.Size(100, 28);
            this.Doc.TabIndex = 2;
            this.Doc.Text = "Đọc";
            this.Doc.UseVisualStyleBackColor = true;
            this.Doc.Click += new System.EventHandler(this.button1_Click);
            // 
            // Xoa
            // 
            this.Xoa.Location = new System.Drawing.Point(725, 256);
            this.Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(100, 28);
            this.Xoa.TabIndex = 3;
            this.Xoa.Text = "Xóa";
            this.Xoa.UseVisualStyleBackColor = true;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // Thoat
            // 
            this.Thoat.Location = new System.Drawing.Point(725, 362);
            this.Thoat.Margin = new System.Windows.Forms.Padding(4);
            this.Thoat.Name = "Thoat";
            this.Thoat.Size = new System.Drawing.Size(100, 28);
            this.Thoat.TabIndex = 4;
            this.Thoat.Text = "Thoát";
            this.Thoat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 79);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhập số nguyên từ 0 đến 9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 335);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kết quả";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Thoat);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.Doc);
            this.Controls.Add(this.KetQua);
            this.Controls.Add(this.Data);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Data;
        private System.Windows.Forms.TextBox KetQua;
        private System.Windows.Forms.Button Doc;
        private System.Windows.Forms.Button Xoa;
        private System.Windows.Forms.Button Thoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

