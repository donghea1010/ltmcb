using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week4SampleCode
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        private Thread listenThread;
        private TcpListener tcpListener;
        private bool stopChatServer = true;
        private readonly int _serverPort = 8080;
        private Dictionary<string, TcpClient> dict = new Dictionary<string, TcpClient>();

        public void Listen()
        {
            try
            {
                // 1. new and start a tcpListener
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); // Replace with your desired IP address
                tcpListener = new TcpListener(ipAddress, _serverPort);
                tcpListener.Start();

                while (!stopChatServer)
                {
                    // 1.1. create a TcpClient = tcpListener.AcceptTcpClient()
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    // 2. create a streamReader and StreamWriter; getStream from tcpClient in step 1
                    NetworkStream clientStream = tcpClient.GetStream();
                    StreamReader sReader = new StreamReader(clientStream);
                    StreamWriter sWriter = new StreamWriter(clientStream);
                    sWriter.AutoFlush = true;

                    // 3. Using streamreader read stream to get username which is sent by client.
                    string username = sReader.ReadLine();

                    // 4. check if username exists by dictionary.containskey(username)
                    if (dict.ContainsKey(username))
                    {
                        // 4.1 if username exists using streamwriter to write message username already exists to client.
                        sWriter.WriteLine("Username already exists.");
                    }
                    else
                    {
                        // 4.2 if username not exists: add username into dictionary (dict variable)
                        dict.Add(username, tcpClient);

                        // then create and start a thread to handle client receive data
                        Thread clientThread = new Thread(() => ClientRecv(username, tcpClient));
                        clientThread.Start();
                    }
                }
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message);
            }
        }

        public void ClientRecv(string username, TcpClient tcpClient)
        {
            // 5. create a streamReader and getstream from tcpClient
            NetworkStream clientStream = tcpClient.GetStream();
            StreamReader sReader = new StreamReader(clientStream);

            while (!stopChatServer)
            {
                // 6. using ReadLine() from streamReader to read content of stream
                string receivedData = sReader.ReadLine();

                foreach (TcpClient otherClient in dict.Values)
                {
                    // 7. using streamwriter to send data to other clients
                    NetworkStream otherClientStream = otherClient.GetStream();
                    StreamWriter otherClientWriter = new StreamWriter(otherClientStream);
                    otherClientWriter.AutoFlush = true;
                    otherClientWriter.WriteLine(username + ": " + receivedData);
                }

                // 8. call UpdateChatHistorySafeCall function to update UI with the msg
                UpdateChatHistorySafeCall(username + ": " + receivedData);
            }
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            if (stopChatServer)
            {
                stopChatServer = false;
                listenThread = new Thread(new ThreadStart(Listen));
                listenThread.Start();
                MessageBox.Show("Listening...");

                listenButton.Text = "Stop";
            }
            else
            {
                stopChatServer = true;

                tcpListener.Stop();
                listenThread = null;
                listenButton.Text = "Listen";
            }
        }


    }
}

        private void listenButton_Click(object sender, EventArgs e)
        {
            if (stopChatServer)
            {
                stopChatServer = false;
                //0. create a listerThread
                //listenThread = new Thread(new ThreadStart(Listen));
                //listenThread.Start();
                //MessageBox.Show("Listening...");

                listenButton.Text = @"Stop";
            }
            else
            {
                stopChatServer = true;

                tcpListener.Stop();
                listenThread = null;
                listenButton.Text = @"Listen";
            }
        }
    }
}

