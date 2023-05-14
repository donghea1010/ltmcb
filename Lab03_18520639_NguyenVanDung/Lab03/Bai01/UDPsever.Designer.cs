namespace Bai01
{
    partial class UDPsever
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ContentRC_listview = new System.Windows.Forms.ListView();
            this.Port_txt = new System.Windows.Forms.TextBox();
            this.Listen_btn = new System.Windows.Forms.Button();
            this.Port_lable = new System.Windows.Forms.Label();
            this.Mess_lable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContentRC_listview
            // 
            this.ContentRC_listview.HideSelection = false;
            this.ContentRC_listview.Location = new System.Drawing.Point(62, 106);
            this.ContentRC_listview.Margin = new System.Windows.Forms.Padding(4);
            this.ContentRC_listview.Name = "ContentRC_listview";
            this.ContentRC_listview.Size = new System.Drawing.Size(675, 317);
            this.ContentRC_listview.TabIndex = 5;
            this.ContentRC_listview.UseCompatibleStateImageBehavior = false;
            this.ContentRC_listview.View = System.Windows.Forms.View.List;
            // 
            // Port_txt
            // 
            this.Port_txt.Location = new System.Drawing.Point(62, 51);
            this.Port_txt.Margin = new System.Windows.Forms.Padding(4);
            this.Port_txt.Name = "Port_txt";
            this.Port_txt.Size = new System.Drawing.Size(175, 22);
            this.Port_txt.TabIndex = 4;
            // 
            // Listen_btn
            // 
            this.Listen_btn.Location = new System.Drawing.Point(622, 28);
            this.Listen_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Listen_btn.Name = "Listen_btn";
            this.Listen_btn.Size = new System.Drawing.Size(117, 25);
            this.Listen_btn.TabIndex = 3;
            this.Listen_btn.Text = "Listen";
            this.Listen_btn.UseVisualStyleBackColor = true;
            this.Listen_btn.Click += new System.EventHandler(this.Listen_btn_Click);
            // 
            // Port_lable
            // 
            this.Port_lable.AutoSize = true;
            this.Port_lable.Location = new System.Drawing.Point(59, 28);
            this.Port_lable.Name = "Port_lable";
            this.Port_lable.Size = new System.Drawing.Size(34, 17);
            this.Port_lable.TabIndex = 6;
            this.Port_lable.Text = "Port";
            // 
            // Mess_lable
            // 
            this.Mess_lable.AutoSize = true;
            this.Mess_lable.Location = new System.Drawing.Point(59, 85);
            this.Mess_lable.Name = "Mess_lable";
            this.Mess_lable.Size = new System.Drawing.Size(65, 17);
            this.Mess_lable.TabIndex = 7;
            this.Mess_lable.Text = "Message";
            // 
            // UDPsever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Mess_lable);
            this.Controls.Add(this.Port_lable);
            this.Controls.Add(this.ContentRC_listview);
            this.Controls.Add(this.Port_txt);
            this.Controls.Add(this.Listen_btn);
            this.Name = "UDPsever";
            this.Text = "UDPsever";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView ContentRC_listview;
        private System.Windows.Forms.TextBox Port_txt;
        private System.Windows.Forms.Button Listen_btn;
        private System.Windows.Forms.Label Port_lable;
        private System.Windows.Forms.Label Mess_lable;
    }
}