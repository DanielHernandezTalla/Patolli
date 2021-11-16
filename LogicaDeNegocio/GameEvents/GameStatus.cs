using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos;

namespace LogicaDeNegocio.GameEvents
{
    public class GameStatus : ISubject
    {
        private readonly List<IObserver> observers;

        public GameStatus()
        {
            observers = new List<IObserver>();
        }

        public void NotifyObservers(Event gameEvent)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(gameEvent);
            }
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
