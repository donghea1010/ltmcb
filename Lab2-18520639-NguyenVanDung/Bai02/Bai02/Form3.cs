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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            ReadContent.Text = sr.ReadToEnd();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WriteFile_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("D://input.txt");
            //tách các dòng ra để tính
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            s1 = sr.ReadLine();
            string[] s11;
            s11 = s1.Split('+');
            float tong1 = float.Parse(s11[0]) + float.Parse(s11[1]);
            s2 = sr.ReadLine();
            string[] s22;
            s22 = s2.Split('-');
            float tong2 = float.Parse(s22[0]) - float.Parse(s22[1]);
            s3 = sr.ReadLine();
            string[] s33;
            s33 = s3.Split('*');
            float tong3 = float.Parse(s33[0]) * float.Parse(s33[1]);
            s4 = sr.ReadLine();
            string[] s44;
            s44 = s4.Split('/');
            float tong4 = float.Parse(s44[0]) / float.Parse(s44[1]);

            FileStream fs = new FileStream("D://output.txt", FileMode.Create);
            StreamWriter writeFile = new StreamWriter(fs, Encoding.UTF8);
            writeFile.WriteLine(s1 + " = " + tong1.ToString()); 
            writeFile.WriteLine(s2 + " = " + tong2.ToString()); 
            writeFile.WriteLine(s3 + " = " + tong3.ToString()); 
            writeFile.WriteLine(s4 + " = " + tong4.ToString()); 
            writeFile.Flush();
            writeFile.Close();
            string ss1 = s1 + "=" + tong1.ToString();
            string ss2 = s2 + "=" + tong2.ToString();
            string ss3 = s3 + "=" + tong3.ToString();
            WriteContent.Text = ss1 + "\n" + ss2 + "\n" + ss3;
            MessageBox.Show("tính toán đúng");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
