using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Udp Server";

            var localIp = IPAddress.Any;
            var localPort = 1308;
            var localEndPoint = new IPEndPoint(localIp, localPort);

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//khoi tao loai giao thuc va ...
            //addfamily.internetwork: so do danh dia chi ip v4, dia chi cua cac may dau cuoi

            socket.Bind(localEndPoint); //chiem dung cong, khi lenh bind phat ra, ctrinh se hoi hdh cong nay da duoc chiem hay chua, neu 
            //no da dc sd thi c.trinh se dung.
            //endPoint: dia chi cua tien trinh, gom ip va port

            Console.WriteLine($"Local socket dind to {localEndPoint}. Waiting for request...");
            var size = 1024;
            var receiveBuffer = new byte[size];
            while (true)// sever Allway on
            {
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                var length = socket.ReceiveFrom(receiveBuffer, ref remoteEndPoint);
                //ref truyen tham so kieu tham bien, nguyen ly hoat dong cua udp khong tao lien ket giua 2 server, khi do ta can
                //luu lai 1 bien de luu lai dia chi cua tien trinh khach dang nois chuyen voi no phuc vu phan hoi ve sau
                //26:41

                var request = Encoding.ASCII.GetString(receiveBuffer, 0, length);

                Console.WriteLine($"Receive from {remoteEndPoint}: {request}");

                int khoangTrang = request.IndexOf(' ');
                string requestName = string.Empty;
                if (khoangTrang != -1)
                {
                    requestName = request.Substring(0, khoangTrang);
                }

                // xoá requestName + khoảng trắng tiếp theo
                string requestParameter = request.Replace($"{requestName} ", "");

                var response = string.Empty;

                switch (requestName.ToUpper())
                {
                    case "UPPER":
                        response = requestParameter.ToUpper().ToString();
                        break;

                    case "LOWER":
                        response = requestParameter.ToLower().ToString();
                        break;

                    case "LENGTH":
                        response = requestParameter.Length.ToString();
                        break;

                    default:
                        response = "UNKNOWN COMMAND";
                        break;
                }

                var sendBuffer = Encoding.ASCII.GetBytes(response);
                socket.SendTo(sendBuffer, remoteEndPoint);

                Array.Clear(receiveBuffer, 0, size);
            }
        }
    }
}
