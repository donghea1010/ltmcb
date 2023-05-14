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
using ChatServer;

namespace ChatServer
{
    public partial class Bai04sever : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);
        public Bai04sever()
        {
            InitializeComponent();
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            //Parse địa chỉ IP của serever ra khỏi textbox
            IPAddress ipAddr = IPAddress.Parse(txtIp.Text);
            ChatServer mainServer = new ChatServer(ipAddr);
            // Nối trình xử lý sự kiện StatusChanged vào mainServer_StatusChanged
            ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
            // bắt đầu lắng nghe các Client
            mainServer.StartListening();
            //thông báo bắt đầu lắng nghe các Client
            message.AppendText("giám sát các kết nối...\r\n");
        }
        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {

            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }

        private void UpdateStatus(string strMessage)
        {

            message.AppendText(strMessage + "\r\n");
        }
    }
    
}
