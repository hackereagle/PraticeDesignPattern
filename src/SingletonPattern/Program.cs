using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton
    {
        private static Singleton instance = null;

        private Singleton()
        {
            System.Console.WriteLine("constructor new");
        }

        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("\nGet instance");
                if (instance == null)
                {
                    Console.WriteLine("new one");
                    instance = new Singleton();
                }

                return instance;
            }
        }

        public void doSomething()
        {
            Console.WriteLine("Do something~");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Console.WriteLine("s1: " + s1.GetHashCode() + ", s2: " + s2.GetHashCode());
            s1.doSomething();
            s2.doSomething();


            //Console.WriteLine("\n\nTesting Singleton Pattern use multiple threading.");
            Console.ReadLine();
        }
    }
}
