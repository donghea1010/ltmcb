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
using System.Threading;

namespace Bai01
{
    public partial class UDPsever : Form
    {
        public UDPsever()
        {
            InitializeComponent();
        }
        private void InfoMessage(string content)
        {
            if (this.ContentRC_listview.InvokeRequired)
            {
                ContentRC_listview.Invoke(new MethodInvoker(delegate
                {
                    ContentRC_listview.Items.Add(content);
                }));
            }
            else ContentRC_listview.Items.Add(content);
            
        }
        private void serverThread()
        {
            UdpClient udpClient = new UdpClient(int.Parse(Port_txt.Text));
            while (true)
            {
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string content = remoteIpEndPoint.Address.ToString() + ": " + returnData;
                InfoMessage(content);
            }
        }
        private void Listen_btn_Click(object sender, EventArgs e)
        {
            Thread udpServerStart = new Thread(new ThreadStart(serverThread));
            udpServerStart.Start();
            Listen_btn.Enabled = false;
        }
    }
}
