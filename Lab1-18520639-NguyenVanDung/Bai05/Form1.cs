using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string temp;
        double a, b;

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += button4.Text;
            label1.Text += button4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += button1.Text;
            label1.Text += button1.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += button10.Text;
            label1.Text = button10.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += button2.Text;
            label1.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += button3.Text;
            label1.Text += button3.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += button5.Text;
            label1.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += button6.Text;
            label1.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;
            label1.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
            label1.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += button9.Text;
            label1.Text += button9.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);// Convert.Todouble() == double.Prase()
            temp = "+";
            label1.Text += "+";
            textBox1.Text = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);// Convert.Todouble() == double.Prase()
            temp = "-";
            label1.Text += "-";
            textBox1.Text = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text); // Convert.Todouble() == double.Prase()
            temp = "*";
            label1.Text += "*";
            textBox1.Text = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);// Convert.Todouble() == double.Prase()
            temp = "/";
            label1.Text += "/";
            textBox1.Text = null;
        }

        private void button11_Click(object sender, EventArgs e) 
        {
            textBox1.Text += button11.Text;
            label1.Text += button11.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label1.Text = null;
            textBox1.Text = null;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            temp = "^2";
            label1.Text += button17.Text;
            textBox1.Text = null;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            temp = "cos";
            label1.Text += button23.Text;
            textBox1.Text = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            b = double.Parse(textBox1.Text);
            label1.Text += "=";
            switch(temp)
            {
                case "+": a = a + b;
                    break;
                case "-": a = a - b;
                    break;
                case "/":a = a / b;
                    break;
                case "*":a = a * b;
                    break;
                case "^2": a *= a;
                    break;
                case "cos":a = Math.Cos(b);
                    break;

            }
            textBox1.Text = a.ToString();
            label1.Text += a.ToString();
            ///////label1.Text.Split('=');
        }
    }
}
