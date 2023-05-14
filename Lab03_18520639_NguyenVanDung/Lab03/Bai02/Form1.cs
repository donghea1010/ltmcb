using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Listen_btn_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread severthread = new Thread(new ThreadStart(StartUnsafeThread));
            severthread.Start();
            Listen_btn.Enabled = false;
        }
        void StartUnsafeThread()
        {
            int bytesRecived = 0;
            byte[] recv = new byte[1];
            Socket clientSocket;
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipepSever = new IPEndPoint(IPAddress.Parse("192.168.56.1"), 8080);
            listenerSocket.Bind(ipepSever);
            listenerSocket.Listen(-1);
            clientSocket = listenerSocket.Accept();
            listViewCommand.Items.Add(new ListViewItem("New client connected"));
            while(clientSocket.Connected)
            {
                string text = "";
                do
                {
                    bytesRecived = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                } while (text[text.Length-1]!='\n');
                listViewCommand.Items.Add(new ListViewItem(text));
            }
            listenerSocket.Close();
        }
       
    }
}
