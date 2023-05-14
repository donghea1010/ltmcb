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
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        private void sever_btn_Click(object sender, EventArgs e)
        {
            var sever = new TCPsever();
            sever.Show();
        }

        private void client_btn_Click(object sender, EventArgs e)
        {
            var client = new TCPclient();
            client.Show();
        }
    }
}
