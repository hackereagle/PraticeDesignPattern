using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace StrategyPattern
{
    public interface IService
    {
        void DoService(Socket client);
    }

    public class EchoService : IService
    {
        public void DoService(Socket client)
        {
            System.Threading.Thread serviceThread = new System.Threading.Thread(() =>
            { 
                byte[] data = new byte[1024];
                string recStr = null;
                while (client.Connected)
                {
                    int len = client.Receive(data);
                    recStr += Encoding.ASCII.GetString(data, 0, len);

                    Console.WriteLine($"Thread[{System.Threading.Thread.CurrentThread.ManagedThreadId}] Service get {recStr}");

                    recStr = null;
                }

                if (client.Connected == false)
                {
                    string ipAndPort = client.RemoteEndPoint.ToString();
                    Console.WriteLine($"Thread[{System.Threading.Thread.CurrentThread.ManagedThreadId}] Service: {ipAndPort} lose connection.");
                }
            });
            serviceThread.Start();
        }
    }

    public class Server
    {
        private Socket mListener;
        private IPEndPoint mListeningPoint;
        private Socket mConnection;
        private IService mService;
        public Server(int port, IService service)
        {
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            mListeningPoint = new IPEndPoint(ip, port);
            mListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            mService = service;
        }

        public void Start()
        {
            System.Threading.Thread listeningThread = new System.Threading.Thread(() =>
            {
                mListener.Bind(mListeningPoint);
                mListener.Listen(10);

                try
                {
                    Console.WriteLine($"Thread[{System.Threading.Thread.CurrentThread.ManagedThreadId}] Sever: Waiting for a connection......");
                    mConnection = mListener.Accept();
                    Console.WriteLine($"Thread[{System.Threading.Thread.CurrentThread.ManagedThreadId}] Server: Connection sucess");

                    mService.DoService(mConnection);
                    Console.WriteLine($"Thread[{System.Threading.Thread.CurrentThread.ManagedThreadId}] Server: Assigned socket to IService.DoService");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Thread[{System.Threading.Thread.CurrentThread.ManagedThreadId}] Occure problem: {ex.Message}");
                }
            });
            listeningThread.Start();
        }
    }

    class Program
    {
        static private bool mIsContinuousTest = true;
        static void Main(string[] args)
        {
            IService service = new EchoService();
            int port = 10000;
            Server server = new Server(port, service);
            server.Start();


            // Create testing client
            ClientForTesting client = new ClientForTesting();
            client.ConnectServer("127.0.0.1", port.ToString());
            System.Threading.Thread.Sleep(500);
            while (mIsContinuousTest)
            {
                Console.WriteLine("\nPlease type message for server:");
                string command = Console.ReadLine();
                if ("Exit" == command)
                {
                    mIsContinuousTest = false;
                }
                else
                {
                    client.SendData(System.Text.Encoding.ASCII.GetBytes(command));
                }
            }
        }
    }
}
