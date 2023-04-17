namespace Bai02
{
    partial class Form2
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
            this.ReadFile = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.Label();
            this.Url = new System.Windows.Forms.Label();
            this.CoutLine = new System.Windows.Forms.Label();
            this.CoutWord = new System.Windows.Forms.Label();
            this.CountCharater = new System.Windows.Forms.Label();
            this.FileNameResult = new System.Windows.Forms.TextBox();
            this.UrlResult = new System.Windows.Forms.TextBox();
            this.CountLineResult = new System.Windows.Forms.TextBox();
            this.CountWordResult = new System.Windows.Forms.TextBox();
            this.CountCharacterResult = new System.Windows.Forms.TextBox();
            this.Content = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Location = new System.Drawing.Point(28, 55);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(215, 99);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "Đọc File";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(60, 190);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(55, 17);
            this.FileName.TabIndex = 1;
            this.FileName.Text = "Tên file";
            this.FileName.Click += new System.EventHandler(this.FileName_Click);
            // 
            // Url
            // 
            this.Url.AutoSize = true;
            this.Url.Location = new System.Drawing.Point(60, 241);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(26, 17);
            this.Url.TabIndex = 2;
            this.Url.Text = "Url";
            this.Url.Click += new System.EventHandler(this.Url_Click);
            // 
            // CoutLine
            // 
            this.CoutLine.AutoSize = true;
            this.CoutLine.Location = new System.Drawing.Point(60, 299);
            this.CoutLine.Name = "CoutLine";
            this.CoutLine.Size = new System.Drawing.Size(61, 17);
            this.CoutLine.TabIndex = 3;
            this.CoutLine.Text = "Số dòng";
            this.CoutLine.Click += new System.EventHandler(this.label3_Click);
            // 
            // CoutWord
            // 
            this.CoutWord.AutoSize = true;
            this.CoutWord.Location = new System.Drawing.Point(60, 338);
            this.CoutWord.Name = "CoutWord";
            this.CoutWord.Size = new System.Drawing.Size(41, 17);
            this.CoutWord.TabIndex = 4;
            this.CoutWord.Text = "Số từ";
            this.CoutWord.Click += new System.EventHandler(this.CoutWord_Click);
            // 
            // CountCharater
            // 
            this.CountCharater.AutoSize = true;
            this.CountCharater.Location = new System.Drawing.Point(60, 384);
            this.CountCharater.Name = "CountCharater";
            this.CountCharater.Size = new System.Drawing.Size(59, 17);
            this.CountCharater.TabIndex = 5;
            this.CountCharater.Text = "Số ký tự";
            this.CountCharater.Click += new System.EventHandler(this.CountCharater_Click);
            // 
            // FileNameResult
            // 
            this.FileNameResult.Location = new System.Drawing.Point(167, 187);
            this.FileNameResult.Name = "FileNameResult";
            this.FileNameResult.Size = new System.Drawing.Size(100, 22);
            this.FileNameResult.TabIndex = 6;
            // 
            // UrlResult
            // 
            this.UrlResult.Location = new System.Drawing.Point(167, 238);
            this.UrlResult.Name = "UrlResult";
            this.UrlResult.Size = new System.Drawing.Size(100, 22);
            this.UrlResult.TabIndex = 7;
            // 
            // CountLineResult
            // 
            this.CountLineResult.Location = new System.Drawing.Point(167, 294);
            this.CountLineResult.Name = "CountLineResult";
            this.CountLineResult.Size = new System.Drawing.Size(100, 22);
            this.CountLineResult.TabIndex = 8;
            // 
            // CountWordResult
            // 
            this.CountWordResult.Location = new System.Drawing.Point(167, 338);
            this.CountWordResult.Name = "CountWordResult";
            this.CountWordResult.Size = new System.Drawing.Size(100, 22);
            this.CountWordResult.TabIndex = 9;
            // 
            // CountCharacterResult
            // 
            this.CountCharacterResult.Location = new System.Drawing.Point(167, 379);
            this.CountCharacterResult.Name = "CountCharacterResult";
            this.CountCharacterResult.Size = new System.Drawing.Size(100, 22);
            this.CountCharacterResult.TabIndex = 10;
            // 
            // Content
            // 
            this.Content.Location = new System.Drawing.Point(352, 49);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(779, 382);
            this.Content.TabIndex = 11;
            this.Content.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 559);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.CountCharacterResult);
            this.Controls.Add(this.CountWordResult);
            this.Controls.Add(this.CountLineResult);
            this.Controls.Add(this.UrlResult);
            this.Controls.Add(this.FileNameResult);
            this.Controls.Add(this.CountCharater);
            this.Controls.Add(this.CoutWord);
            this.Controls.Add(this.CoutLine);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.ReadFile);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label Url;
        private System.Windows.Forms.Label CoutLine;
        private System.Windows.Forms.Label CoutWord;
        private System.Windows.Forms.Label CountCharater;
        private System.Windows.Forms.TextBox FileNameResult;
        private System.Windows.Forms.TextBox UrlResult;
        private System.Windows.Forms.TextBox CountLineResult;
        private System.Windows.Forms.TextBox CountWordResult;
        private System.Windows.Forms.TextBox CountCharacterResult;
        private System.Windows.Forms.RichTextBox Content;
    }
}