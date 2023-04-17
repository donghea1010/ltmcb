using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double DaTa = double.Parse(Data.Text);

            switch(comboBox1.SelectedItem.ToString())
            {
                case "USD (Đô la Mĩ)": DaTa=DaTa * 22.772;
                    label3.Text = "1 USD = 22,772 VND";
                    break;
                case "EUR (Euro)": DaTa = DaTa * 28.132;
                    label3.Text = "1 EUR = 28,132 VND";
                    break;
                case "GBP  (Bảng Anh)": DaTa = DaTa * 31.538;
                    label3.Text = "1 GBP = 31,538 VND";
                    break;
                case "SGD (Đô la Singapore)": DaTa = DaTa * 17.286;
                    label3.Text = "1 SGD = 17,286 VND";
                    break;
                case "JPY (Yên Nhật)": DaTa = DaTa * 21.400;
                    label3.Text = "1 JPY = 21,400 VND";
                    break;
                case "VND (Việt Nam Đồng)": DaTa = DaTa ;
                    label3.Text = "1 VND = 1 VND";
                    break;
            }
            KetQua.Text = DaTa.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
