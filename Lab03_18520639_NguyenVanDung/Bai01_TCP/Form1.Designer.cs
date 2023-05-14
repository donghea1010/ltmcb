namespace Bai01_TCP
{
    partial class Dashbroad
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
            this.TCPsever_btn = new System.Windows.Forms.Button();
            this.TCPclient_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TCPsever_btn
            // 
            this.TCPsever_btn.Location = new System.Drawing.Point(78, 100);
            this.TCPsever_btn.Name = "TCPsever_btn";
            this.TCPsever_btn.Size = new System.Drawing.Size(199, 44);
            this.TCPsever_btn.TabIndex = 0;
            this.TCPsever_btn.Text = "TCP Sever";
            this.TCPsever_btn.UseVisualStyleBackColor = true;
            this.TCPsever_btn.Click += new System.EventHandler(this.TCPsever_btn_Click);
            // 
            // TCPclient_btn
            // 
            this.TCPclient_btn.Location = new System.Drawing.Point(350, 100);
            this.TCPclient_btn.Name = "TCPclient_btn";
            this.TCPclient_btn.Size = new System.Drawing.Size(226, 44);
            this.TCPclient_btn.TabIndex = 1;
            this.TCPclient_btn.Text = "TCP Client";
            this.TCPclient_btn.UseVisualStyleBackColor = true;
            this.TCPclient_btn.Click += new System.EventHandler(this.TCPclient_btn_Click);
            // 
            // Dashbroad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TCPclient_btn);
            this.Controls.Add(this.TCPsever_btn);
            this.Name = "Dashbroad";
            this.Text = "Dashbroad";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TCPsever_btn;
        private System.Windows.Forms.Button TCPclient_btn;
    }
}

