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


namespace Bai03
{
    public partial class TCPclient : Form
    {
        public TCPclient()
        {
            InitializeComponent();
        }

        private void Send_button_Click(object sender, EventArgs e)
        {
            var ip = IPAddress.Parse("127.0.0.1");

            var tcpclient = new TcpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(ip, 8080);
            tcpclient.Connect(iPEndPoint);
            NetworkStream ns = tcpclient.GetStream();
            Byte[] Data = System.Text.Encoding.UTF8.GetBytes("Hello sever\n");
            ns.Write(Data, 0, Data.Length);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tcpclient = new TcpClient();
            NetworkStream ns = tcpclient.GetStream();
            Byte[] data = System.Text.Encoding.UTF8.GetBytes("quit\n");
            ns.Write(data, 0, data.Length);
            ns.Close();
            tcpclient.Close();
        }
    }
}
