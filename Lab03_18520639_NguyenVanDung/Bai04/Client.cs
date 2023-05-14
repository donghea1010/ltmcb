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
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Bai04
{
    public partial class Client : Form
    {
        private string UserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        //update tin nhắn ở trong các form
        private delegate void UpdateLogCallback(string strMessage);
        //"disconnected" 1 form từ 1 thread khác
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;
        
        public Client()
        {
            InitializeComponent();
            // ngắt kết nối khi tắt
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                // đóng các kết nối, thread ....
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
        }
        private void InitializeConnection()
        {
            // phân tích địa chỉ IP trong khung textbox (IPServer)
            ipAddr = IPAddress.Parse(IPServer.Text);
            // kết nối Client với Server
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddr, 8080);


            //kiểm tra(theo dõi) xem có kết nối được hay k
            Connected = true;
            //gán userNam =NameClient
            UserName = NameClient.Text;

            // Vô hiệu hóa IPServer, NameClient , kích hoạt VanBan, Send 
            IPServer.Enabled = false;
            NameClient.Enabled = false;
            VanBan.Enabled = true;
            btnSend.Enabled = true;
            btnConnect.Text = "Disconnect";

            // gửi tên người dùng đến Server
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(NameClient.Text);
            swSender.Flush();

            // nhận tin nhắn từ các Thread
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }
        private void ReceiveMessages()
        {
            // nhận phản hồi từ máy chủ
            srReceiver = new StreamReader(tcpServer.GetStream());
            // thông báo kết nối thành công nếu ký tự đầu tiên là 1
            string ConResponse = srReceiver.ReadLine();
            if (ConResponse[0] == '1')
            {
                // Update lại form để biết đã kết nối
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Đã kết nối thành công!" });
            }
            else // nếu ký tự đầu tiên không phải là 1 thì kết nối k thành công
            {
                string Reason = "Không thể kết nối: ";
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                // thoát khỏi chuowgn trình
                return;
            }
            // trong khi vẫn còn kết nối thì gửi thông báo đến Server
            while (Connected)
            {
                //hiển thị các thông báo trong textbox
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
            }
        }
        //Update lại textbox từ các thread khác
        private void UpdateLog(string strMessage)
        {
            //xuống dòng sau mỗi textbox 
            message.AppendText(strMessage + "\r\n");

        }
        private void CloseConnection(string Reason)
        {
            message.AppendText(Reason + "\r\n");
            IPServer.Enabled = true;
            NameClient.Enabled = true;
            VanBan.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Text = "Connect";

            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }

        //gửi tin nhắn đến Server
        private void SendMessage()
        {
            if (VanBan.Lines.Length >= 1)
            {
                swSender.WriteLine(VanBan.Text);
                swSender.Flush();
                VanBan.Lines = null;
            }
            VanBan.Text = "";
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Connected == false)
            {
                //khởi tạo kết nối
                InitializeConnection();
            }
            else
            {
                CloseConnection("ngắt kết nối theo yều cầu của User.");
            }
        }
    }
}
