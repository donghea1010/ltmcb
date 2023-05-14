namespace Bai03
{
    partial class TCPclient
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Send_button
            // 
            this.Send_button.Location = new System.Drawing.Point(183, 184);
            this.Send_button.Name = "Send_button";
            this.Send_button.Size = new System.Drawing.Size(354, 59);
            this.Send_button.TabIndex = 21;
            this.Send_button.Text = "Send messgae";
            this.Send_button.UseVisualStyleBackColor = true;
            this.Send_button.Click += new System.EventHandler(this.Send_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(354, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "Quit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TCPclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Send_button);
            this.Name = "TCPclient";
            this.Text = "TCPclient";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Send_button;
        private System.Windows.Forms.Button button1;
    }
}