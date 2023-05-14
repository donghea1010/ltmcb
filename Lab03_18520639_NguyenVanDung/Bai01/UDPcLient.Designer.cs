namespace Bai01
{
    partial class UDPcLient
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
            this.Send_button = new System.Windows.Forms.Button();
            this.Content_lable = new System.Windows.Forms.Label();
            this.Port_lable = new System.Windows.Forms.Label();
            this.IP_lable = new System.Windows.Forms.Label();
            this.Content_txt = new System.Windows.Forms.RichTextBox();
            this.Port_txt = new System.Windows.Forms.MaskedTextBox();
            this.IP_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Send_button
            // 
            this.Send_button.Location = new System.Drawing.Point(169, 352);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(146, 59);
            this.Send_button.TabIndex = 13;
            this.Send_button.Text = "Send";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // Content_lable
            // 
            this.Content_lable.AutoSize = true;
            this.Content_lable.Location = new System.Drawing.Point(166, 153);
            this.Content_lable.Name = "Content_lable";
            this.Content_lable.Size = new System.Drawing.Size(65, 17);
            this.Content_lable.TabIndex = 12;
            this.Content_lable.Text = "Message";
            // 
            // Port_lable
            // 
            this.Port_lable.AutoSize = true;
            this.Port_lable.Location = new System.Drawing.Point(532, 40);
            this.Port_lable.Name = "Port_lable";
            this.Port_lable.Size = new System.Drawing.Size(34, 17);
            this.Port_lable.TabIndex = 11;
            this.Port_lable.Text = "Port";
            // 
            // IP_lable
            // 
            this.IP_lable.AutoSize = true;
            this.IP_lable.Location = new System.Drawing.Point(166, 40);
            this.IP_lable.Name = "IP_lable";
            this.IP_lable.Size = new System.Drawing.Size(104, 17);
            this.IP_lable.TabIndex = 10;
            this.IP_lable.Text = "IP Remote host";
            // 
            // Content_txt
            // 
            this.Content_txt.Location = new System.Drawing.Point(169, 186);
            this.Content_txt.Name = "Content_txt";
            this.Content_txt.Size = new System.Drawing.Size(466, 132);
            this.Content_txt.TabIndex = 9;
            this.Content_txt.Text = "";
            // 
            // Port_txt
            // 
            this.Port_txt.Location = new System.Drawing.Point(535, 72);
            this.Port_txt.Name = "Port_txt";
            this.Port_txt.Size = new System.Drawing.Size(100, 22);
            this.Port_txt.TabIndex = 8;
            // 
            // IP_txt
            // 
            this.IP_txt.Location = new System.Drawing.Point(169, 72);
            this.IP_txt.Name = "IP_txt";
            this.IP_txt.Size = new System.Drawing.Size(177, 22);
            this.IP_txt.TabIndex = 7;
            // 
            // UDPcLient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Send_button);
            this.Controls.Add(this.Content_lable);
            this.Controls.Add(this.Port_lable);
            this.Controls.Add(this.IP_lable);
            this.Controls.Add(this.Content_txt);
            this.Controls.Add(this.Port_txt);
            this.Controls.Add(this.IP_txt);
            this.Name = "UDPcLient";
            this.Text = "UDPcLient";
            this.Load += new System.EventHandler(this.UDPcLient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.Label Content_lable;
        private System.Windows.Forms.Label Port_lable;
        private System.Windows.Forms.Label IP_lable;
        private System.Windows.Forms.RichTextBox Content_txt;
        private System.Windows.Forms.MaskedTextBox Port_txt;
        private System.Windows.Forms.TextBox IP_txt;
    }
}