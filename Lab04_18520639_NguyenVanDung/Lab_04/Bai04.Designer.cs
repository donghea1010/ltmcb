namespace Lab_04
{
    partial class Bai04
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Go_btn = new System.Windows.Forms.Button();
            this.URL_txt = new System.Windows.Forms.TextBox();
            this.DownlSource_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Back_btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Forward_btn = new System.Windows.Forms.Button();
            this.Refesh_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 46);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(776, 529);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Go_btn
            // 
            this.Go_btn.Location = new System.Drawing.Point(626, 7);
            this.Go_btn.Name = "Go_btn";
            this.Go_btn.Size = new System.Drawing.Size(162, 33);
            this.Go_btn.TabIndex = 1;
            this.Go_btn.Text = "Go";
            this.Go_btn.UseVisualStyleBackColor = true;
            this.Go_btn.Click += new System.EventHandler(this.Go_btn_Click);
            // 
            // URL_txt
            // 
            this.URL_txt.Location = new System.Drawing.Point(12, 12);
            this.URL_txt.Name = "URL_txt";
            this.URL_txt.Size = new System.Drawing.Size(430, 22);
            this.URL_txt.TabIndex = 2;
            // 
            // DownlSource_btn
            // 
            this.DownlSource_btn.Location = new System.Drawing.Point(448, 9);
            this.DownlSource_btn.Name = "DownlSource_btn";
            this.DownlSource_btn.Size = new System.Drawing.Size(151, 28);
            this.DownlSource_btn.TabIndex = 3;
            this.DownlSource_btn.Text = "Download Source";
            this.DownlSource_btn.UseVisualStyleBackColor = true;
            this.DownlSource_btn.Click += new System.EventHandler(this.DownlSource_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 578);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "lúc truy cập nếu có đòi hỏi phần chấp nhận các scrip , nhấp yes để đồng ý từng fi" +
    "le";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Back_btn
            // 
            this.Back_btn.Location = new System.Drawing.Point(794, 64);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(75, 23);
            this.Back_btn.TabIndex = 5;
            this.Back_btn.Text = "Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // Forward_btn
            // 
            this.Forward_btn.Location = new System.Drawing.Point(887, 64);
            this.Forward_btn.Name = "Forward_btn";
            this.Forward_btn.Size = new System.Drawing.Size(75, 23);
            this.Forward_btn.TabIndex = 6;
            this.Forward_btn.Text = "Forward";
            this.Forward_btn.UseVisualStyleBackColor = true;
            this.Forward_btn.Click += new System.EventHandler(this.Forward_btn_Click);
            // 
            // Refesh_btn
            // 
            this.Refesh_btn.Location = new System.Drawing.Point(838, 113);
            this.Refesh_btn.Name = "Refesh_btn";
            this.Refesh_btn.Size = new System.Drawing.Size(75, 44);
            this.Refesh_btn.TabIndex = 7;
            this.Refesh_btn.Text = "Refesh";
            this.Refesh_btn.UseVisualStyleBackColor = true;
            this.Refesh_btn.Click += new System.EventHandler(this.Refesh_btn_Click);
            // 
            // Bai04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 614);
            this.Controls.Add(this.Refesh_btn);
            this.Controls.Add(this.Forward_btn);
            this.Controls.Add(this.Back_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownlSource_btn);
            this.Controls.Add(this.URL_txt);
            this.Controls.Add(this.Go_btn);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Bai04";
            this.Text = "Bai04";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button Go_btn;
        private System.Windows.Forms.TextBox URL_txt;
        private System.Windows.Forms.Button DownlSource_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Back_btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Forward_btn;
        private System.Windows.Forms.Button Refesh_btn;
    }
}