using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class Message
    {
        public Message()
        { 
        }

        public void PeekMessage()
        { 
        }
    }
    class MessageFactory
    {
        public MessageFactory()
        { 
        }

        public Message CreateMessage()
        {
            Message msg = new Message();
            return msg;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
