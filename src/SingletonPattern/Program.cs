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

    class SingletonThreadSafe
    {
       private static SingletonThreadSafe instance = null;
        private static readonly object padlock = new object();

        private SingletonThreadSafe()
        {
            System.Console.WriteLine("constructor new");
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                // if no lock, instance would be new twice.
                // It is going to cause difference hash code between s12 and s22.
                lock (padlock)
                {
                    Console.WriteLine("\nGet instance");
                    if (instance == null)
                    {
                        Console.WriteLine("new one");
                        instance = new SingletonThreadSafe();
                    }

                    return instance;
                }
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


            Console.WriteLine("\n\nTesting Singleton Pattern use multiple threading.");
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                SingletonThreadSafe s12 = SingletonThreadSafe.Instance;
                Console.WriteLine($"first: {s12.GetHashCode()}");
                s12.doSomething();
            });
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                SingletonThreadSafe s12 = SingletonThreadSafe.Instance;
                Console.WriteLine($"second: {s12.GetHashCode()}");
                s12.doSomething();
            });
            Console.ReadLine();
        }
    }
}
