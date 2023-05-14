namespace Bai01_TCP
{
    partial class TCPsever
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
            this.Listen_button = new System.Windows.Forms.Button();
            this.ContentReceived_View = new System.Windows.Forms.ListView();
            this.Port_txt = new System.Windows.Forms.TextBox();
            this.ContentRecevied_lable = new System.Windows.Forms.Label();
            this.Port_lable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Listen_button
            // 
            this.Listen_button.Location = new System.Drawing.Point(531, 49);
            this.Listen_button.Name = "Listen_button";
            this.Listen_button.Size = new System.Drawing.Size(139, 36);
            this.Listen_button.TabIndex = 14;
            this.Listen_button.Text = "Listen";
            this.Listen_button.UseVisualStyleBackColor = true;
            this.Listen_button.Click += new System.EventHandler(this.Listen_button_Click);
            // 
            // ContentReceived_View
            // 
            this.ContentReceived_View.HideSelection = false;
            this.ContentReceived_View.Location = new System.Drawing.Point(134, 145);
            this.ContentReceived_View.Name = "ContentReceived_View";
            this.ContentReceived_View.Size = new System.Drawing.Size(536, 266);
            this.ContentReceived_View.TabIndex = 13;
            this.ContentReceived_View.UseCompatibleStateImageBehavior = false;
            // 
            // Port_txt
            // 
            this.Port_txt.Location = new System.Drawing.Point(222, 40);
            this.Port_txt.Name = "Port_txt";
            this.Port_txt.Size = new System.Drawing.Size(100, 22);
            this.Port_txt.TabIndex = 12;
            // 
            // ContentRecevied_lable
            // 
            this.ContentRecevied_lable.AutoSize = true;
            this.ContentRecevied_lable.Location = new System.Drawing.Point(131, 107);
            this.ContentRecevied_lable.Name = "ContentRecevied_lable";
            this.ContentRecevied_lable.Size = new System.Drawing.Size(128, 17);
            this.ContentRecevied_lable.TabIndex = 11;
            this.ContentRecevied_lable.Text = "Recevied message";
            // 
            // Port_lable
            // 
            this.Port_lable.AutoSize = true;
            this.Port_lable.Location = new System.Drawing.Point(131, 40);
            this.Port_lable.Name = "Port_lable";
            this.Port_lable.Size = new System.Drawing.Size(34, 17);
            this.Port_lable.TabIndex = 10;
            this.Port_lable.Text = "Port";
            // 
            // TCPsever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Listen_button);
            this.Controls.Add(this.ContentReceived_View);
            this.Controls.Add(this.Port_txt);
            this.Controls.Add(this.ContentRecevied_lable);
            this.Controls.Add(this.Port_lable);
            this.Name = "TCPsever";
            this.Text = "TCP Sever";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Listen_button;
        private System.Windows.Forms.ListView ContentReceived_View;
        private System.Windows.Forms.TextBox Port_txt;
        private System.Windows.Forms.Label ContentRecevied_lable;
        private System.Windows.Forms.Label Port_lable;
    }
}