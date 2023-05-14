namespace Bai03
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Sever running on 127.0.0.1 : 8080");
            this.Listen_button = new System.Windows.Forms.Button();
            this.ContentReceived_View = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Listen_button
            // 
            this.Listen_button.Location = new System.Drawing.Point(529, 44);
            this.Listen_button.Name = "Listen_button";
            this.Listen_button.Size = new System.Drawing.Size(139, 36);
            this.Listen_button.TabIndex = 16;
            this.Listen_button.Text = "Listen";
            this.Listen_button.UseVisualStyleBackColor = true;
            this.Listen_button.Click += new System.EventHandler(this.Listen_button_Click);
            // 
            // ContentReceived_View
            // 
            this.ContentReceived_View.HideSelection = false;
            this.ContentReceived_View.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ContentReceived_View.Location = new System.Drawing.Point(132, 140);
            this.ContentReceived_View.Name = "ContentReceived_View";
            this.ContentReceived_View.Size = new System.Drawing.Size(536, 266);
            this.ContentReceived_View.TabIndex = 15;
            this.ContentReceived_View.UseCompatibleStateImageBehavior = false;
            this.ContentReceived_View.View = System.Windows.Forms.View.List;
            this.ContentReceived_View.SelectedIndexChanged += new System.EventHandler(this.ContentReceived_View_SelectedIndexChanged);
            // 
            // TCPsever
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Listen_button);
            this.Controls.Add(this.ContentReceived_View);
            this.Name = "TCPsever";
            this.Text = "TCPsever";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Listen_button;
        private System.Windows.Forms.ListView ContentReceived_View;
    }
}