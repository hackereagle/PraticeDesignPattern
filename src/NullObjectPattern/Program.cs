using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    class Player
    {
        public Player()
        {
        }

        public void Jump()
        {
            Console.WriteLine("Player jump!");
        }

        public void Dash()
        {
            Console.WriteLine("Player runing forward.");
        }
    }

    interface IPlayerController
    {
        void OnKeyDown(string key);
    }

    class PlayerControllerImp : IPlayerController
    {
        private Player mPlayer;
        public PlayerControllerImp(Player player)
        {
            mPlayer = player;
        }

        public void OnKeyDown(string key)
        {
            if ("A" == key)
            {
                mPlayer.Jump();
            }
            else if ("B" == key)
            {
                mPlayer.Dash();
            }
        }
    }

    class NullPlayerController : IPlayerController
    {
        public void OnKeyDown(string key)
        {
            Console.WriteLine("// In NullPlayerController, do not do anything!");
        }
    }

    class Game
    {
        private IPlayerController mPlayerController;
        private Player mPlayer;
        public Game()
        {
            mPlayer = new Player();
        }

        public enum GameStatus
        { 
            GameOver,
            Progress,
        }

        public void OnUpdateGameStatus(GameStatus status)
        {
            if (GameStatus.GameOver == status)
            {
                mPlayerController = new NullPlayerController();
            }
            else
            {
                mPlayerController = new PlayerControllerImp(mPlayer);
            }
        }

        public void OnKeyDown(string key)
        {
            mPlayerController.OnKeyDown(key);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Console.WriteLine("=== Testing normally story ===");
            game.OnUpdateGameStatus(Game.GameStatus.Progress);
            Console.WriteLine("Press \"A\" key");
            game.OnKeyDown("A");
            Console.WriteLine("Press \"B\" key");
            game.OnKeyDown("B");

            Console.WriteLine("\n=== Testing game over story and null object ===");
            game.OnUpdateGameStatus(Game.GameStatus.GameOver);
            Console.WriteLine("Press \"A\" key");
            game.OnKeyDown("A");
            Console.WriteLine("Press \"B\" key");
            game.OnKeyDown("B");

            Console.ReadLine();
        }
    }
}
