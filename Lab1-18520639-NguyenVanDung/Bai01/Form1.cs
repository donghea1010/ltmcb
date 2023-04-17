using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void So_thu_nhat(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1Text = Sothunhat.Text;
            string s2Text = textBox2.Text;
            string s3Text = textBox3.Text;

            int s1Int = int.Parse(s1Text);
            int s2Int = int.Parse(s2Text);
            int s3Int = int.Parse(s3Text);

            long Max = s1Int;
            if (s2Int > Max) Max = s2Int;
            else if (s3Int > Max) Max = s3Int;

            textBox5.Text = Max.ToString();

            long Min = s1Int;
            if (s2Int < Min) Min = s2Int;
            else if (s3Int < Max) Min = s3Int;

            textBox4.Text = Min.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sothunhat.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }
    }
}
