namespace Lab_04
{
    partial class Menu
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
            this.Bai01_btn = new System.Windows.Forms.Button();
            this.Bai02_btn = new System.Windows.Forms.Button();
            this.Bai03_btn = new System.Windows.Forms.Button();
            this.Bai04_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Bai01_btn
            // 
            this.Bai01_btn.Location = new System.Drawing.Point(107, 93);
            this.Bai01_btn.Name = "Bai01_btn";
            this.Bai01_btn.Size = new System.Drawing.Size(170, 42);
            this.Bai01_btn.TabIndex = 0;
            this.Bai01_btn.Text = "Bài 01";
            this.Bai01_btn.UseVisualStyleBackColor = true;
            this.Bai01_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bai02_btn
            // 
            this.Bai02_btn.Location = new System.Drawing.Point(326, 93);
            this.Bai02_btn.Name = "Bai02_btn";
            this.Bai02_btn.Size = new System.Drawing.Size(170, 29);
            this.Bai02_btn.TabIndex = 1;
            this.Bai02_btn.Text = "Bài 02";
            this.Bai02_btn.UseVisualStyleBackColor = true;
            this.Bai02_btn.Click += new System.EventHandler(this.Bai02_btn_Click);
            // 
            // Bai03_btn
            // 
            this.Bai03_btn.Location = new System.Drawing.Point(121, 219);
            this.Bai03_btn.Name = "Bai03_btn";
            this.Bai03_btn.Size = new System.Drawing.Size(170, 29);
            this.Bai03_btn.TabIndex = 2;
            this.Bai03_btn.Text = "Bài 03";
            this.Bai03_btn.UseVisualStyleBackColor = true;
            this.Bai03_btn.Click += new System.EventHandler(this.Bai03_btn_Click);
            // 
            // Bai04_btn
            // 
            this.Bai04_btn.Location = new System.Drawing.Point(326, 219);
            this.Bai04_btn.Name = "Bai04_btn";
            this.Bai04_btn.Size = new System.Drawing.Size(170, 29);
            this.Bai04_btn.TabIndex = 3;
            this.Bai04_btn.Text = "Bài 04";
            this.Bai04_btn.UseVisualStyleBackColor = true;
            this.Bai04_btn.Click += new System.EventHandler(this.Bai04_btn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Bai04_btn);
            this.Controls.Add(this.Bai03_btn);
            this.Controls.Add(this.Bai02_btn);
            this.Controls.Add(this.Bai01_btn);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bai01_btn;
        private System.Windows.Forms.Button Bai02_btn;
        private System.Windows.Forms.Button Bai03_btn;
        private System.Windows.Forms.Button Bai04_btn;
    }
}

