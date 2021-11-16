using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos;
using LogicaDeNegocio.GameEvents;

namespace Presentacion.Pruebas
{
    class GameStatusObserver : IObserver
    {
        private readonly Test affected;

        public GameStatusObserver(System.Windows.Forms.Form affected)
        {
            this.affected = (Test)affected;
        }

        public void Update(Event subjectEvent)
        {
            string eventType = subjectEvent.EventType;

            if (eventType.Equals("GameCreated"))
                affected.GameCreated((GameCreatedEvent)subjectEvent);


        }


    }
}
