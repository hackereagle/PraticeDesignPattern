using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class ClientForTesting
    {
        private System.Net.Sockets.Socket mSocket;
        public ClientForTesting()
        {
            mSocket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
        }

        public bool ConnectServer(string ip, string port)
        {
            bool connectResult = false;
            try
            {
                mSocket.Connect(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), Convert.ToInt32(port)));
                Console.WriteLine("Socket connected to -> {0}", mSocket.RemoteEndPoint.ToString());

                System.Threading.Thread receiveDataThread = new System.Threading.Thread(ReceiveData);
                receiveDataThread.Start();

                connectResult = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Occuring problem when connect server: " + ex.Message + "\n" + ex.StackTrace);
                connectResult = false;
            }

            return connectResult;
        }

        public string IpAndPort
        { 
            get 
            {
                System.Net.IPEndPoint ed = mSocket.LocalEndPoint as System.Net.IPEndPoint;
                return $"{ed.Address}:{ed.Port}"; 
            } 
        }

        public delegate void ReceiveMessage(string msg);
        public event ReceiveMessage ReceiveMessageEvent;
        private void ReceiveData()
        {
            try
            {
                while (mSocket.Connected)
                {
                    if (HaveMsg())
                    { 
                        var package = new List<byte>();

                        while (mSocket.Available > 0)
                        { 
                            byte[] buffer = new byte[1];
                            var recv = mSocket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.None);

                            if(recv == 1)
                                package.Add(buffer[0]);
                        }

                        var msg = System.Text.Encoding.Default.GetString(package.ToArray());
                        Console.WriteLine($"Client receive command {msg}");
                        if (ReceiveMessageEvent != null)
                            ReceiveMessageEvent(msg);
                        package.Clear();
                    }
                }

                Console.WriteLine("Connection was broken.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Occuring problem when ReceiveData: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private bool HaveMsg()
        {
            byte[] buffer = new byte[10];
            var len = mSocket.Receive(buffer, buffer.Length, System.Net.Sockets.SocketFlags.Peek);
            if (len > 0)
                return true;
            else
                return false;
        }

        public void SendData(byte[] msg)
        {
            mSocket.Send(msg);
        }
    }
}
