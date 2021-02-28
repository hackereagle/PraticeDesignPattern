using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace AsyncObserverPattern
{
    class FavouriteGameProcessorUseISubject
    {
        ISubject<FavouriteGame> mQueue = new Subject<FavouriteGame>();
        IObservable<FavouriteGame> mGame;

        public FavouriteGameProcessorUseISubject()
        {
            mGame = mQueue.AsQbservable();
            mGame.Subscribe(FavouriteEvent);
        }

        public void Publish(FavouriteGame e)
        {
            try
            {
                mQueue.OnNext(e);
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
}
