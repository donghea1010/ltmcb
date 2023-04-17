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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void ReadFile_Click(object sender, EventArgs e)
        {
           
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                Content.Text = sr.ReadToEnd();

                FileNameResult.Text = ofd.SafeFileName.ToString();
                UrlResult.Text = ofd.FileName.ToString();
                CountCharacterResult.Text = Content.Text.Length.ToString();
                Content.Text = Content.Text.Replace("\r\n", "\n");
                CountLineResult.Text = Content.Lines.Count().ToString();
                String[] source = Content.Text.Split(new char[] { '!', '?', '.', ',', '(', ')', '&', '/', ' ', '[', ']', '{', '}', }, StringSplitOptions.RemoveEmptyEntries);
                CountWordResult.Text = source.Count().ToString();
                fs.Close();

            }
            catch(IOException )
            {
                MessageBox.Show("Nhập file không hợp lệ") ;
            }
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void CountCharater_Click(object sender, EventArgs e)
        {

        }

        private void CoutWord_Click(object sender, EventArgs e)
        {

        }

        private void FileName_Click(object sender, EventArgs e)
        {

        }

        private void Url_Click(object sender, EventArgs e)
        {

        }
    }
}
