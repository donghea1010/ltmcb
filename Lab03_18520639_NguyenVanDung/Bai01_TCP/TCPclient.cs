using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Bai01_TCP
{
    public partial class TCPclient : Form
    {
        public TCPclient()
        {
            InitializeComponent();
        }

        private void Send_button_Click(object sender, EventArgs e)
        {
            var ip = IPAddress.Parse(IP_txt.Text);
            
            var tcpclient = new TcpClient();
            tcpclient.Connect(ip, 8080);
            var stream = tcpclient.GetStream();
            var writer = new StreamWriter(stream) { AutoFlush = true };
            writer.WriteLine(Content_txt.Text);
            writer.Close();
            stream.Close();

            tcpclient.Close();

        }

        private void TCPclient_Load(object sender, EventArgs e)
        {

        }
    }
}
