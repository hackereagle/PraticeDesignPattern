using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Reactive;

// This code need ‘System.Threading.Tasks.Dataflow’ and ‘System.Reactive’ NuGet packages.
// This code refer to https://medium.com/@saurabh.singh0829/c-parallel-processing-part-2-async-pipeline-using-observer-design-pattern-fdf43e86ff5b
namespace AsyncObserverPattern
{
    public class FavouriteGame
    {
        public string UserID { get; set; }
        public string GameID { get; set; }
    }

    public class FavouriteGameProcessor
    {
        private readonly BufferBlock<FavouriteGame> _queue;
        private readonly IObservable<FavouriteGame> _games;
        private const int ParallelDegree = -1;

        public FavouriteGameProcessor()
        {
            _queue = new BufferBlock<FavouriteGame>(
                            new DataflowBlockOptions { BoundedCapacity = ParallelDegree});
            _games = _queue.AsObservable();
            _games.Subscribe(FavouriteEvent);
        }

        public void Publish(FavouriteGame e)
        {
            try
            {
                _queue.Post(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Publish have error: {ex.Message}");
            }
        }

        void FavouriteEvent(FavouriteGame e)
        {
            try
            {
                Console.WriteLine($"Thread:{System.Threading.Thread.CurrentThread.ManagedThreadId}, Add to Recent games: ID:{e.UserID}, Game:{e.GameID}");
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"FavouriteEvent have error: {ex.Message}");
            }
        }
    }

    class Program
    {
        private static FavouriteGameProcessor _favouriteGameProcessor = new FavouriteGameProcessor();
        public static void OpenGame(string userID, string gameID)
        {
            _favouriteGameProcessor.Publish(
                new FavouriteGame()
                {
                    GameID = gameID,
                    UserID = userID
                }); ;
        }

        private static FavouriteGameProcessorUseISubject mUsingSubject = new FavouriteGameProcessorUseISubject();
        public static void OpenGame2(string userID, string gameID)
        {
            mUsingSubject.Publish(
                new FavouriteGame()
                {
                    GameID = gameID,
                    UserID = userID
                }); ;

        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            OpenGame("123", "FGO");
            OpenGame("456", "PAD");

            //OpenGame2("123", "FGO");
            //OpenGame2("456", "PAD");

            Console.ReadLine();
        }
    }
}
