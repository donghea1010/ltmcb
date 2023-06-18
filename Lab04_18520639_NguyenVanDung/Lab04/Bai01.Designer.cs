namespace Lab04
{
    partial class Bai01
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
            this.Send = new System.Windows.Forms.Button();
            this.URL_txt = new System.Windows.Forms.TextBox();
            this.ContentHTML_richtxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(523, 33);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(242, 73);
            this.Send.TabIndex = 0;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // URL_txt
            // 
            this.URL_txt.Location = new System.Drawing.Point(12, 58);
            this.URL_txt.Name = "URL_txt";
            this.URL_txt.Size = new System.Drawing.Size(443, 22);
            this.URL_txt.TabIndex = 1;
            // 
            // ContentHTML_richtxt
            // 
            this.ContentHTML_richtxt.Location = new System.Drawing.Point(12, 116);
            this.ContentHTML_richtxt.Name = "ContentHTML_richtxt";
            this.ContentHTML_richtxt.Size = new System.Drawing.Size(753, 322);
            this.ContentHTML_richtxt.TabIndex = 2;
            this.ContentHTML_richtxt.Text = "";
            // 
            // Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentHTML_richtxt);
            this.Controls.Add(this.URL_txt);
            this.Controls.Add(this.Send);
            this.Name = "Bai01";
            this.Text = "Bai01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox URL_txt;
        private System.Windows.Forms.RichTextBox ContentHTML_richtxt;
    }
}