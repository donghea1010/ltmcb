using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_04
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai01 bai01 = new Bai01();
            bai01.Show();
        }

        private void Bai02_btn_Click(object sender, EventArgs e)
        {
            Bai02 bai02 = new Bai02();
            bai02.Show();
        }

        private void Bai03_btn_Click(object sender, EventArgs e)
        {
            Bai03 bai03 = new Bai03();
            bai03.Show();
        }

        private void Bai04_btn_Click(object sender, EventArgs e)
        {
            var bai04 = new Bai04();
            bai04.Show();
        }
    }
}
