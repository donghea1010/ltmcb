using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Udp Client"; 
            Console.Write("Server IP: ");
            //var ipString = Console.ReadLine();
            var ipString = "127.0.0.1";
            var serverIp = IPAddress.Parse(ipString);

            Console.Write("Server port: ");
            //var portString = Console.ReadLine();
            var portString = "1308";
            var serverPort = int.Parse(portString);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("# COMMAND>>>");
                Console.ResetColor();

                var text = Console.ReadLine();

                var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

                var sendEndPoint = new IPEndPoint(serverIp, serverPort);
                var sendBuffer = Encoding.ASCII.GetBytes(text);
                socket.SendTo(sendBuffer, sendEndPoint);

                var size = 1024;
                var receiveBuffer = new byte[size];
                EndPoint dummyEndpoint = new IPEndPoint(IPAddress.Any, 0); //23.00
                var length = socket.ReceiveFrom(receiveBuffer, ref dummyEndpoint);

                var result = Encoding.ASCII.GetString(receiveBuffer, 0, length); // goi phuong thuc getstring thong qua ascii
                socket.Close();
                Console.WriteLine($">>> { result}");
            }
        }
    }
}
