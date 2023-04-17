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
using System.Runtime.Serialization.Formatters.Binary;

namespace Bai02
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Chọn File để lưu dữ liệu chuyển đổi");
                string Data = ReadContent.Text;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);

                BinaryFormatter BF = new BinaryFormatter();
                BF.Serialize(fs, Data);
                fs.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Xảy ra lỗi");
            }
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void WriteFile_Click(object sender, EventArgs e)
        {
            float diemtoan, diemvan;

            try
            {
                MessageBox.Show("Chọn file input");
                BinaryFormatter BF = new BinaryFormatter();

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);

                WriteContent.Text = (string)BF.Deserialize(fs);

               
                
                
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    diemtoan = float.Parse(sr.ReadLine());
                    diemvan = float.Parse(sr.ReadLine());
                    
                
                float dtb = diemtoan + diemvan;
                WriteContent.Text += "\n";
                WriteContent.Text += dtb.ToString();
                fs.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Xảy ra lỗi");
            }
           
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
           try
            {
                MessageBox.Show("chọn file để lưu");
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(WriteContent.Text);
                sw.Close();
                fs.Close();
            }
            catch(IOException)
            {
                MessageBox.Show("Xảy ra lỗi");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
