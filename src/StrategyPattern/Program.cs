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

        }
    }

    public class Server
    {
        private Socket mServer;
        private IService mService;
        public Server(int port, IService service)
        {
        }

        public void Start()
        { 

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
