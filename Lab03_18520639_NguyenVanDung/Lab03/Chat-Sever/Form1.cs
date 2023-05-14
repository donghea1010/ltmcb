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
using Chat_Sever;
namespace Chat_Sever
{
    public partial class Form1 : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);
        public Form1()
        {
            InitializeComponent();
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            //Parse địa chỉ IP của serever ra khỏi textbox
            IPAddress ipAddr = IPAddress.Parse(txtIp.Text);
            ChatSever mainServer = new ChatSever(ipAddr);
            // Nối trình xử lý sự kiện StatusChanged vào mainServer_StatusChanged
            ChatSever.StatusChanged += new StatusChangedEventHandler(mainSever_StatusChanged);
            // bắt đầu lắng nghe các Client
            mainServer.StartListening();
            //thông báo bắt đầu lắng nghe các Client
            message.AppendText("giám sát các kết nối...\r\n");
        }
        public void mainSever_StatusChanged(object sender, StatusChangedEventArgs e)
        {

            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }

        private void UpdateStatus(string strMessage)
        {

            message.AppendText(strMessage + "\r\n");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void message_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
