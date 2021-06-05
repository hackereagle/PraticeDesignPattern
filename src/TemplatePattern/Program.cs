using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    public abstract class GuessGame
    {
        private Random mRandom;
        public GuessGame()
        {
            mRandom = new Random();
        }

        protected string mWelcome;
        protected string mPrompt;
        protected string mCorrect;
        protected string mBigger;
        protected string mSmaller;
        public void Go()
        {
            Message(mWelcome);

            int number = mRandom.Next(1, 10);
            int guess = 0;
            do
            {
                Message(mPrompt);
                guess = Guess();
                if (guess > number)
                {
                    Message(mBigger);
                }
                else if (guess < number)
                {
                    Message(mSmaller);
                }
            }
            while (guess != number);

            Message(mCorrect);
        }
        protected abstract void Message(string message);
        protected abstract int Guess();
    }

    public class ConsoleGame : GuessGame
    {
        public ConsoleGame()
        {
            base.mWelcome = "Welcom this game~";
            base.mPrompt = "Please type a number between 0~10";
            base.mCorrect = "You are correct!";
            base.mBigger = "The number is too big!";
            base.mSmaller = "The number is too small!";
        }

        protected override void Message(string message)
        {
            Console.WriteLine(message);
        }

        protected override int Guess()
        {
            string line = Console.ReadLine();
            int ret;
            ret = int.Parse(line);
            return ret;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GuessGame game = new ConsoleGame();
            game.Go();
            Console.ReadLine();
        }
    }
}
