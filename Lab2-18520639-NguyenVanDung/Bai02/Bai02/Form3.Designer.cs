namespace Bai02
{
    partial class Form3
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
            this.ReadFile = new System.Windows.Forms.Button();
            this.WriteFile = new System.Windows.Forms.Button();
            this.ReadContent = new System.Windows.Forms.RichTextBox();
            this.WriteContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(79, 56);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(175, 69);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "Đọc file";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // WriteFile
            // 
            this.WriteFile.Location = new System.Drawing.Point(79, 278);
            this.WriteFile.Name = "WriteFile";
            this.WriteFile.Size = new System.Drawing.Size(175, 80);
            this.WriteFile.TabIndex = 1;
            this.WriteFile.Text = "Ghi File";
            this.WriteFile.UseVisualStyleBackColor = true;
            this.WriteFile.Click += new System.EventHandler(this.WriteFile_Click);
            // 
            // ReadContent
            // 
            this.ReadContent.Location = new System.Drawing.Point(372, 56);
            this.ReadContent.Name = "ReadContent";
            this.ReadContent.Size = new System.Drawing.Size(359, 176);
            this.ReadContent.TabIndex = 2;
            this.ReadContent.Text = "";
            this.ReadContent.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // WriteContent
            // 
            this.WriteContent.Location = new System.Drawing.Point(372, 278);
            this.WriteContent.Name = "WriteContent";
            this.WriteContent.Size = new System.Drawing.Size(358, 182);
            this.WriteContent.TabIndex = 3;
            this.WriteContent.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 576);
            this.Controls.Add(this.WriteContent);
            this.Controls.Add(this.ReadContent);
            this.Controls.Add(this.WriteFile);
            this.Controls.Add(this.ReadFile);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Button WriteFile;
        private System.Windows.Forms.RichTextBox ReadContent;
        private System.Windows.Forms.RichTextBox WriteContent;
    }
}