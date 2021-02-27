using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This exercise refer to book 《七天學會計模式》
namespace SimpleFactory
{
    public interface Adventurer
    {
        string getType();
    }

    public class Archer : Adventurer
    {
        public string getType()
        {
            Console.WriteLine("I am Archer");
            return "Archer";
        }
    }

    public class Warrior : Adventurer
    {
        public string getType()
        {
            Console.WriteLine("I am Warrior");
            return "Warrior";
        }
    }

    public class TrainingCamp
    {
        public static Adventurer trainAdventurer(string type)
        {
            switch (type)
            {
                case "archer":
                    Console.WriteLine("Training a archer");
                    return new Archer();
                case "warrior":
                    Console.WriteLine("Training a warrior");
                    return new Warrior();
                default:
                    return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adventurer memberA = TrainingCamp.trainAdventurer("archer");
            Adventurer memberB = TrainingCamp.trainAdventurer("warrior");
            Console.ReadLine();
        }
    }
}
