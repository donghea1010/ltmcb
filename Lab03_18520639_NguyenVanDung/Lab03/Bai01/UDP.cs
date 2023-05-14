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
    public partial class UDP : Form
    {
        public UDP()
        {
            InitializeComponent();
        }

        private void Sever_start_Click(object sender, EventArgs e)
        {
            var sever = new UDPsever();
            sever.Show();
        }

        private void Client_start_Click(object sender, EventArgs e)
        {
            var client = new UDPcLient();
            client.Show();
        }
    }
}
