using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DaTa = int.Parse(Data.Text);

            switch(DaTa)
            {
                case 0: KetQua.Text = "Không";
                    break;
                case 1:
                    KetQua.Text = "Một";
                    break;
                case 2:
                    KetQua.Text = "Hai";
                    break;
                case 3:
                    KetQua.Text = "Ba";
                    break;
                case 4:
                    KetQua.Text = "Bốn";
                    break;
                case 5:
                    KetQua.Text = "Năm";
                    break;
                case 6:
                    KetQua.Text = "Sáu";
                    break;
                case 7:
                    KetQua.Text = "Bảy";
                    break;
                case 8:
                    KetQua.Text = "Tám";
                    break;
                case 9:
                    KetQua.Text = "Chín";
                    break;
            }    
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Data_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            Data.Text = null;
            KetQua.Text = null;
        }
    }
}
