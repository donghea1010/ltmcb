using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;

namespace ChatServer
{
    public class StatusChangedEventArgs : EventArgs
    {
        private string EventMsg;

        //các thuộc tính để truy xuất và thiết lập sự kiện
        public string EventMessage
        {
            get
            {
                return EventMsg;
            }
            set
            {
                EventMsg = value;
            }
        }

        // Constructor for setting the event message
        public StatusChangedEventArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }
    }


    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    class ChatServer
    {
        // bảng băm lưu trữ nhiều người dùng, tối đa 30 ng cùng 1 luc
        public static Hashtable htUsers = new Hashtable(30);
        public static Hashtable htConnections = new Hashtable(30);
        //lưu lại địa chỉ IP mà Client chuyền qua
        private IPAddress ipAddress;
        private TcpClient tcpClient;
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;
        public ChatServer(IPAddress address)
        {
            ipAddress = address;
        }
        private Thread thrListener;

        // Listen sẽ lắng nghe các kết nối 
        private TcpListener tlsClient;
        bool ServRunning = false;

        //thêm người dùng 
        public static void AddUser(TcpClient tcpUser, string strUsername)
        {
            // trước tiên thêm tên người dùng 
            ChatServer.htUsers.Add(strUsername, tcpUser);
            ChatServer.htConnections.Add(tcpUser, strUsername);

            //giới thiệu cho Server và các Client khác biết đó là user nào
            SendAdminMessage(htConnections[tcpUser] + " đã tham gia ");
        }

        //xóa User
        public static void RemoveUser(TcpClient tcpUser)
        {
            if (htConnections[tcpUser] != null)
            {
                //thông báo cho mọi người biết user nào đã ngắt kết nối
                SendAdminMessage(htConnections[tcpUser] + " đã rời khỏi room");
                ChatServer.htUsers.Remove(ChatServer.htConnections[tcpUser]);
                ChatServer.htConnections.Remove(tcpUser);
            }
        }

        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            StatusChangedEventHandler statusHandler = StatusChanged;
            if (statusHandler != null)
            {
                statusHandler(null, e);
            }
        }

        public static void SendAdminMessage(string Message)
        {
            StreamWriter swSenderSender;

            // cho biết ai đang nói chuyện
            e = new StatusChangedEventArgs("user: " + Message);
            OnStatusChanged(e);

            //tạo 1 mảng các Client bao gồm kích thước , số lượng user
            TcpClient[] tcpClients = new TcpClient[ChatServer.htUsers.Count];
            //copy các Client vào mảng
            ChatServer.htUsers.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < tcpClients.Length; i++)
            {
                //gửi tin nhắn cho từng user
                try
                {
                    // nếu không có tin nhắn hãy thoát ra
                    if (Message.Trim() == "" || tcpClients[i] == null)
                    {
                        continue;
                    }
                    //gửi tin nhắn cho user đang trong vòng lập
                    swSenderSender = new StreamWriter(tcpClients[i].GetStream());
                    swSenderSender.WriteLine("user: " + Message);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch //xóa user đã thoát ra
                {
                    RemoveUser(tcpClients[i]);
                }
            }
        }

        // gửi tin nhắn từ 1 người cho tất cả mọi ng
        public static void SendMessage(string From, string Message)
        {
            StreamWriter swSenderSender;
            // hiển thị xem ai đang nói gì
            e = new StatusChangedEventArgs(From + " nói: " + Message);
            OnStatusChanged(e);
            TcpClient[] tcpClients = new TcpClient[ChatServer.htUsers.Count];
            ChatServer.htUsers.Values.CopyTo(tcpClients, 0);
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    if (Message.Trim() == "" || tcpClients[i] == null)
                    {
                        continue;
                    }
                    swSenderSender = new StreamWriter(tcpClients[i].GetStream());
                    swSenderSender.WriteLine(From + " says: " + Message);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    RemoveUser(tcpClients[i]);
                }
            }
        }

        public void StartListening()
        {
            //nhập ip 
            IPAddress ipaLocal = ipAddress;
            //kết nối tới port đã được chỉ định
            tlsClient = new TcpListener(8080);
            tlsClient.Start();
            ServRunning = true;
            thrListener = new Thread(KeepListening);
            thrListener.Start();
        }

        private void KeepListening()
        {
            //trong khi server đang chạy
            while (ServRunning == true)
            {
                //chấp nhận các kết nối từ CLient
                tcpClient = tlsClient.AcceptTcpClient();
                //tạo 1 Client mới
                Connection newConnection = new Connection(tcpClient);
            }
        }
    }


    class Connection
    {
        TcpClient tcpClient;
        private Thread thrSender;
        private StreamReader srReceiver;
        private StreamWriter swSender;
        private string currUser;
        private string strResponse;
        public Connection(TcpClient tcpCon)
        {
            tcpClient = tcpCon;
            // chấp nhận các client 
            thrSender = new Thread(AcceptClient);
            // The thread calls the AcceptClient() method
            thrSender.Start();
        }

        private void CloseConnection()
        {
            //đóng các đối tượng
            tcpClient.Close();
            srReceiver.Close();
            swSender.Close();
        }


        private void AcceptClient()
        {
            srReceiver = new System.IO.StreamReader(tcpClient.GetStream());
            swSender = new System.IO.StreamWriter(tcpClient.GetStream());

            //đọc thông tin từ user
            currUser = srReceiver.ReadLine();
            if (currUser != "")
            {
                //lưu tên user
                if (ChatServer.htUsers.Contains(currUser) == true)
                {
                    //0 có nghĩa là được kết nối
                    swSender.WriteLine("0|Tên người dùng này đã tồn tại.");
                    swSender.Flush();
                    CloseConnection();
                    return;
                }
                else if (currUser == "user")
                {
                    // 0 means not connected
                    swSender.WriteLine("0|Tên người dùng này đã được lưu.");
                    swSender.Flush();
                    CloseConnection();
                    return;
                }
                else
                {
                    // 1 là kết nối thành công
                    swSender.WriteLine("1");
                    swSender.Flush();
                    ChatServer.AddUser(tcpClient, currUser);
                }
            }
            else
            {
                CloseConnection();
                return;
            }

            try
            {

                while ((strResponse = srReceiver.ReadLine()) != "")
                {
                    //nếu user không hợp lệ thì xóa user
                    if (strResponse == null)
                    {
                        ChatServer.RemoveUser(tcpClient);
                    }
                    else
                    {
                        ChatServer.SendMessage(currUser, strResponse);
                    }
                }
            }
            catch
            {
                ChatServer.RemoveUser(tcpClient);
            }
        }
    }
}
