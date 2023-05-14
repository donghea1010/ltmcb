namespace Bai01
{
    partial class UDP
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
            this.Sever_start = new System.Windows.Forms.Button();
            this.Client_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sever_start
            // 
            this.Sever_start.Location = new System.Drawing.Point(68, 62);
            this.Sever_start.Name = "Sever_start";
            this.Sever_start.Size = new System.Drawing.Size(162, 62);
            this.Sever_start.TabIndex = 0;
            this.Sever_start.Text = "UDP sever";
            this.Sever_start.UseVisualStyleBackColor = true;
            this.Sever_start.Click += new System.EventHandler(this.Sever_start_Click);
            // 
            // Client_start
            // 
            this.Client_start.Location = new System.Drawing.Point(310, 62);
            this.Client_start.Name = "Client_start";
            this.Client_start.Size = new System.Drawing.Size(144, 62);
            this.Client_start.TabIndex = 1;
            this.Client_start.Text = "UDP Client";
            this.Client_start.UseVisualStyleBackColor = true;
            this.Client_start.Click += new System.EventHandler(this.Client_start_Click);
            // 
            // UDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Client_start);
            this.Controls.Add(this.Sever_start);
            this.Name = "UDP";
            this.Text = "UDP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Sever_start;
        private System.Windows.Forms.Button Client_start;
    }
}