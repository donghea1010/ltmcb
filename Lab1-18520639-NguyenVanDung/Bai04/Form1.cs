using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double S1 = double.Parse(textBox1.Text.Trim());
            double S2 = double.Parse(textBox2.Text.Trim());
            double GiaiThuaS1 = 1, GiaiThuaS2 = 1;
            for(int i=1; i<=S1; i++)
            {
                GiaiThuaS1 = GiaiThuaS1 * i;
            }
            for (int i = 1; i <= S2; i++)
            {
                GiaiThuaS2 = GiaiThuaS2 * i;
            }
            textBox3.Text = "A! = " + GiaiThuaS1.ToString();
            textBox4.Text = "B! = " + GiaiThuaS2.ToString();

            double s1 = 0, s2 = 0, s3 = 0;
            for (int i = 1; i <= S1; i++)
                s1 += i;
            for (int i = 1; i <= S2; i++)
                s2 += i;
            textBox5.Text = "S1 = " + s1.ToString();
            textBox6.Text = "S2 = " + s2.ToString();
            double temp = 1;
            for (int i = 1; i <= S2; i++)
            {
                temp = temp * S1;
                s3 += temp;
            }
            double s= s3;
            textBox7.Text = "S3 = " + s3.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
