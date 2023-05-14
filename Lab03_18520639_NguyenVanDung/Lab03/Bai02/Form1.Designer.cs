namespace Bai02
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
            this.Listen_btn = new System.Windows.Forms.Button();
            this.listViewCommand = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Listen_btn
            // 
            this.Listen_btn.Location = new System.Drawing.Point(362, 31);
            this.Listen_btn.Name = "Listen_btn";
            this.Listen_btn.Size = new System.Drawing.Size(123, 23);
            this.Listen_btn.TabIndex = 0;
            this.Listen_btn.Text = "Listen";
            this.Listen_btn.UseVisualStyleBackColor = true;
            this.Listen_btn.Click += new System.EventHandler(this.Listen_btn_Click);
            // 
            // listViewCommand
            // 
            this.listViewCommand.HideSelection = false;
            this.listViewCommand.Location = new System.Drawing.Point(83, 74);
            this.listViewCommand.Name = "listViewCommand";
            this.listViewCommand.Size = new System.Drawing.Size(402, 331);
            this.listViewCommand.TabIndex = 1;
            this.listViewCommand.UseCompatibleStateImageBehavior = false;
            this.listViewCommand.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 438);
            this.Controls.Add(this.listViewCommand);
            this.Controls.Add(this.Listen_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Listen_btn;
        private System.Windows.Forms.ListView listViewCommand;
    }
}

