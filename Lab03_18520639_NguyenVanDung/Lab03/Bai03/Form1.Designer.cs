namespace Bai03
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
            this.sever_btn = new System.Windows.Forms.Button();
            this.client_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sever_btn
            // 
            this.sever_btn.Location = new System.Drawing.Point(95, 105);
            this.sever_btn.Name = "sever_btn";
            this.sever_btn.Size = new System.Drawing.Size(425, 64);
            this.sever_btn.TabIndex = 0;
            this.sever_btn.Text = "Open TCP Sever";
            this.sever_btn.UseVisualStyleBackColor = true;
            this.sever_btn.Click += new System.EventHandler(this.sever_btn_Click);
            // 
            // client_btn
            // 
            this.client_btn.Location = new System.Drawing.Point(95, 204);
            this.client_btn.Name = "client_btn";
            this.client_btn.Size = new System.Drawing.Size(425, 64);
            this.client_btn.TabIndex = 1;
            this.client_btn.Text = "Open new TCP client";
            this.client_btn.UseVisualStyleBackColor = true;
            this.client_btn.Click += new System.EventHandler(this.client_btn_Click);
            // 
            // Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.client_btn);
            this.Controls.Add(this.sever_btn);
            this.Name = "Bai03";
            this.Text = "Bài 03";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sever_btn;
        private System.Windows.Forms.Button client_btn;
    }
}

