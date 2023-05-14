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

namespace Bai01
{
    public partial class UDPcLient : Form
    {
        public UDPcLient()
        {
            InitializeComponent();
        }

        private void UDPcLient_Load(object sender, EventArgs e)
        {

        }

        private void Send_button_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
           
            
            byte[] sendBytes = Encoding.UTF8.GetBytes(Content_txt.Text);

            udpClient.Send(sendBytes, sendBytes.Length, IP_txt.Text, int.Parse(Port_txt.Text));
        }
    }
}
