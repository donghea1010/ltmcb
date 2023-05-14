using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01_TCP
{
    public partial class Dashbroad : Form
    {
        public Dashbroad()
        {
            InitializeComponent();
        }

        private void TCPsever_btn_Click(object sender, EventArgs e)
        {
            TCPsever sever = new TCPsever();
            sever.Show();
        }

        private void TCPclient_btn_Click(object sender, EventArgs e)
        {
            TCPclient client = new TCPclient();
            client.Show();
        }
    }
}
