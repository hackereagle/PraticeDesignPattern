using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RORZE
{
    class ServerForTesting
    {
        private System.Net.Sockets.Socket mSocket;
        private string mIp;
        private int mPort;
        public ServerForTesting( string ip, int port)
        {
            mIp = ip;
            mPort = port;
        }

        public string IpAndPort
        { 
            get 
            {
                return $"{mIp}:{mPort}"; 
            } 
        }

        private bool mIsCotinuousConnection = true;
        public void StartListening()
        {
            System.Threading.Thread ListeningThread = new System.Threading.Thread(() =>
            {
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(mIp);
                System.Net.IPEndPoint localEndPoint = new System.Net.IPEndPoint(ip, mPort);

                System.Net.Sockets.Socket lister = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);

                try
                {
                    lister.Bind(localEndPoint);
                    lister.Listen(10);

                    while (mIsCotinuousConnection)
                    {
                        Console.WriteLine("Waiting for a connection......");
                        mSocket = lister.Accept();
                        Console.WriteLine("Connection sucess");

                        //byte[] data = new byte[2448 * 2048 + 100];
                        byte[] data = new byte[50];
                        string recStr = null;
                        while (mSocket.Connected)
                        {
                            int len = mSocket.Receive(data);
                            recStr += Encoding.ASCII.GetString(data, 0, len);

                            Console.WriteLine(recStr);

                            recStr = null;
                        }

                        if (mSocket.Connected == false)
                        {
                            Console.WriteLine($"Server {IpAndPort} lose connection.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Occure problem: " + ex.Message);
                }
            });
            ListeningThread.Start();
        }

        public int Send(string msg)
        {
            return mSocket.Send(System.Text.Encoding.ASCII.GetBytes(msg));
        }
    }
}
