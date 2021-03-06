using Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public partial class ClientController : Eventos.ISubject
    {
        private List<Eventos.IObserver> observers;

        public void NotifyObservers(Event clientEvent)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(clientEvent);
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
