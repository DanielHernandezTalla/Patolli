using Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Controller
{
    partial class FormsController : Eventos.IObserver
    {
        private readonly Eventos.Game.IGameable affected;

        public FormsController(Eventos.Game.IGameable affected)
        {
            this.affected = affected;
        }

        public void Update(Event subjectEvent)
        {
            string eventType = subjectEvent.EventType;

            if (eventType.Equals("GameCreated"))
                affected.GameCreated(subjectEvent);

            else if (eventType.Equals("TurnChanged"))
                affected.TurnChanged(subjectEvent);

            else if (eventType.Equals("PieceMoved"))
                affected.PieceMoved(subjectEvent);

            return;
        }
    }
}
