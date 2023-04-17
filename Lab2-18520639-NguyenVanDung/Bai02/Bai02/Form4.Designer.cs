namespace Bai02
{
    partial class Form4
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
            this.ChangData = new System.Windows.Forms.Button();
            this.Handling = new System.Windows.Forms.Button();
            this.ReadContent = new System.Windows.Forms.RichTextBox();
            this.WriteContent = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangData
            // 
            this.ChangData.Location = new System.Drawing.Point(12, 49);
            this.ChangData.Name = "ChangData";
            this.ChangData.Size = new System.Drawing.Size(306, 164);
            this.ChangData.TabIndex = 0;
            this.ChangData.Text = "Chuyển đổi dữ liệu ";
            this.ChangData.UseVisualStyleBackColor = true;
            this.ChangData.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // Handling
            // 
            this.Handling.Location = new System.Drawing.Point(12, 232);
            this.Handling.Name = "Handling";
            this.Handling.Size = new System.Drawing.Size(306, 164);
            this.Handling.TabIndex = 1;
            this.Handling.Text = "Tính Điểm Trung Bình";
            this.Handling.UseVisualStyleBackColor = true;
            this.Handling.Click += new System.EventHandler(this.WriteFile_Click);
            // 
            // ReadContent
            // 
            this.ReadContent.Location = new System.Drawing.Point(366, 39);
            this.ReadContent.Name = "ReadContent";
            this.ReadContent.Size = new System.Drawing.Size(361, 164);
            this.ReadContent.TabIndex = 2;
            this.ReadContent.Text = "";
            this.ReadContent.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // WriteContent
            // 
            this.WriteContent.Location = new System.Drawing.Point(366, 232);
            this.WriteContent.Name = "WriteContent";
            this.WriteContent.Size = new System.Drawing.Size(360, 163);
            this.WriteContent.TabIndex = 3;
            this.WriteContent.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập thông tin học viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kết quả trung bình";
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(355, 439);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(261, 62);
            this.SaveFile.TabIndex = 6;
            this.SaveFile.Text = "Lưu File";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 523);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WriteContent);
            this.Controls.Add(this.ReadContent);
            this.Controls.Add(this.Handling);
            this.Controls.Add(this.ChangData);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangData;
        private System.Windows.Forms.Button Handling;
        private System.Windows.Forms.RichTextBox ReadContent;
        private System.Windows.Forms.RichTextBox WriteContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveFile;
    }
}