namespace Lab_04
{
    partial class Bai02
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
            this.Post_btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.URL_txt = new System.Windows.Forms.TextBox();
            this.Data_txt = new System.Windows.Forms.TextBox();
            this.ContentHTML_richtxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Post_btn
            // 
            this.Post_btn.Location = new System.Drawing.Point(483, 68);
            this.Post_btn.Name = "Post_btn";
            this.Post_btn.Size = new System.Drawing.Size(195, 75);
            this.Post_btn.TabIndex = 0;
            this.Post_btn.Text = "Post";
            this.Post_btn.UseVisualStyleBackColor = true;
            this.Post_btn.Click += new System.EventHandler(this.Post_btn_Click);
            // 
            // URL_txt
            // 
            this.URL_txt.Location = new System.Drawing.Point(21, 68);
            this.URL_txt.Name = "URL_txt";
            this.URL_txt.Size = new System.Drawing.Size(397, 22);
            this.URL_txt.TabIndex = 1;
            // 
            // Data_txt
            // 
            this.Data_txt.Location = new System.Drawing.Point(21, 121);
            this.Data_txt.Name = "Data_txt";
            this.Data_txt.Size = new System.Drawing.Size(397, 22);
            this.Data_txt.TabIndex = 2;
            // 
            // ContentHTML_richtxt
            // 
            this.ContentHTML_richtxt.Location = new System.Drawing.Point(21, 180);
            this.ContentHTML_richtxt.Name = "ContentHTML_richtxt";
            this.ContentHTML_richtxt.Size = new System.Drawing.Size(710, 243);
            this.ContentHTML_richtxt.TabIndex = 3;
            this.ContentHTML_richtxt.Text = "";
            // 
            // Bai02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentHTML_richtxt);
            this.Controls.Add(this.Data_txt);
            this.Controls.Add(this.URL_txt);
            this.Controls.Add(this.Post_btn);
            this.Name = "Bai02";
            this.Text = "Bai02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Post_btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox URL_txt;
        private System.Windows.Forms.TextBox Data_txt;
        private System.Windows.Forms.RichTextBox ContentHTML_richtxt;
    }
}