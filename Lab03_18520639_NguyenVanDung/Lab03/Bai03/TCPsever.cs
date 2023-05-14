using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Bai03
{
    public partial class TCPsever : Form
    {
        public TCPsever()
        {
            InitializeComponent();
        }

        private void Listen_button_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thdTCPsever = new Thread(new ThreadStart(severThread));
            thdTCPsever.Start();
            Listen_button.Enabled = false;
        }
        public void severThread()
        {
            var Listener = new TcpListener(IPAddress.Any, 8080);
            Listener.Start(10);
            ContentReceived_View.Items.Add("New client connected");
            while (true)
            {
                var tcpclient = Listener.AcceptTcpClient();
               
                var stream = tcpclient.GetStream();

                var reader = new StreamReader(stream);
                //var write = new StreamWriter(stream);

                var text = reader.ReadLine();
                ContentReceived_View.Items.Add(new ListViewItem(text));

                reader.Close();
                stream.Close();

                tcpclient.Close();
            }
        }
        private void ContentReceived_View_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
