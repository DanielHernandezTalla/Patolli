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
        private readonly List<ISubject> observers;

        public GameStatus()
        {
            observers = new List<ISubject>();
        }

        public void NotifyObservers(Event gameEvent)
        {
            foreach (ISubject observer in observers)
            {
                observer.Update(gameEvent);
            }
        }

        public void Subscribe(ISubject observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(ISubject observer)
        {
            observers.Remove(observer);
        }
    }
}
