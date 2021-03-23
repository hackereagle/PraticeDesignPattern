using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Wheel : ICloneable
    {
        public Wheel()
        {
            Console.WriteLine("Wheel initialize!");
        }

        public object Clone()
        {
            Console.WriteLine("Copy wheel....");
            return this.MemberwiseClone();
        }
    }

    public class Car : ICloneable
    {
        public Car()
        { 
        }

        private Wheel[] wheels = { new Wheel(), new Wheel(), new Wheel(), new Wheel()};

        public object Clone()
        {
            Console.WriteLine("\n\nCoyp car");
            Car copy = (Car)this.MemberwiseClone();
            copy.wheels = (Wheel[])this.wheels.Clone();
            for (int i = 0; i < this.wheels.Length; i++)
            {
                copy.wheels[i] = this.wheels[i].Clone() as Wheel;
            }

            return copy;
        }
    }

    public class Cars
    {
        public Cars()
        { 
        }

        private Dictionary<string, Car> mPrototype = new Dictionary<string, Car>();
        public void AddPrototype(string brand, Car prototype)
        {
            mPrototype.Add(brand, prototype);
        }

        public Car GetPrototype(string brand)
        {
            return mPrototype[brand].Clone() as Car;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car bmw = new Car();
            Car benz = new Car();

            Cars cars = new Cars();
            cars.AddPrototype("BMW", bmw);
            cars.AddPrototype("BENS", benz);

            Car bmwPrototype = cars.GetPrototype("BMW");

            Console.ReadLine();
        }
    }
}
