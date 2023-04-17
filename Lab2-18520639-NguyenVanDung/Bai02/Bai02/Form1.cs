using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WriteFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog ofd = new SaveFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                string content = richTextBox1.Text.ToString();
                richTextBox1.Text += content.ToUpper();
                sw.WriteLine(content.ToUpper());
                MessageBox.Show("Ghi vào file thành công");
                sw.Close();
                fs.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Có lỗi khi lưu file");
            }
           
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                string content = sr.ReadToEnd();
                richTextBox1.Text = content;
                fs.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Có lỗi khi chọn file");
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
