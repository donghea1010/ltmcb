namespace Bai04sever
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
            this.message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.Listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(107, 139);
            this.message.Margin = new System.Windows.Forms.Padding(4);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.message.Size = new System.Drawing.Size(509, 242);
            this.message.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP Address";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(107, 88);
            this.txtIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(509, 22);
            this.txtIp.TabIndex = 9;
            this.txtIp.Text = "192.168.176.1";
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(647, 69);
            this.Listen.Margin = new System.Windows.Forms.Padding(4);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(132, 60);
            this.Listen.TabIndex = 8;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.Listen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.Listen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button Listen;
    }
}

