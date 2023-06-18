namespace Lab_04
{
    partial class Bai03
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
            this.Download_btn = new System.Windows.Forms.Button();
            this.URL_txt = new System.Windows.Forms.TextBox();
            this.NameHTML_txt = new System.Windows.Forms.TextBox();
            this.ContentRich_txt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Download_btn
            // 
            this.Download_btn.Location = new System.Drawing.Point(603, 34);
            this.Download_btn.Name = "Download_btn";
            this.Download_btn.Size = new System.Drawing.Size(169, 101);
            this.Download_btn.TabIndex = 1;
            this.Download_btn.Text = "Download";
            this.Download_btn.UseVisualStyleBackColor = true;
            this.Download_btn.Click += new System.EventHandler(this.Download_btn_Click);
            // 
            // URL_txt
            // 
            this.URL_txt.Location = new System.Drawing.Point(28, 56);
            this.URL_txt.Name = "URL_txt";
            this.URL_txt.Size = new System.Drawing.Size(487, 22);
            this.URL_txt.TabIndex = 2;
            // 
            // NameHTML_txt
            // 
            this.NameHTML_txt.Location = new System.Drawing.Point(28, 113);
            this.NameHTML_txt.Name = "NameHTML_txt";
            this.NameHTML_txt.Size = new System.Drawing.Size(487, 22);
            this.NameHTML_txt.TabIndex = 3;
            // 
            // ContentRich_txt
            // 
            this.ContentRich_txt.Location = new System.Drawing.Point(28, 164);
            this.ContentRich_txt.Name = "ContentRich_txt";
            this.ContentRich_txt.Size = new System.Drawing.Size(744, 274);
            this.ContentRich_txt.TabIndex = 4;
            this.ContentRich_txt.Text = "";
            // 
            // Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentRich_txt);
            this.Controls.Add(this.NameHTML_txt);
            this.Controls.Add(this.URL_txt);
            this.Controls.Add(this.Download_btn);
            this.Name = "Bai03";
            this.Text = "Bai03";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Download_btn;
        private System.Windows.Forms.TextBox URL_txt;
        private System.Windows.Forms.TextBox NameHTML_txt;
        private System.Windows.Forms.RichTextBox ContentRich_txt;
    }
}