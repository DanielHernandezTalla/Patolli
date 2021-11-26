using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos;
using LogicaDeNegocio.GameEvents;

namespace Presentacion.GameStatus
{
    class GameStatusObserver : IObserver
    {
        private readonly IGameEvents affected;

        public GameStatusObserver(IGameEvents affected)
        {
            this.affected = affected;
        }

        public void Update(Event subjectEvent)
        {
            string eventType = subjectEvent.EventType;

            if (eventType.Equals("GameCreated"))
                affected.GameCreated((GameCreatedEvent)subjectEvent);

            else if (eventType.Equals("TurnChanged"))
                affected.TurnChanged((TurnChangedEvent)subjectEvent);

            else if (eventType.Equals("PieceMoved"))
                affected.PieceMoved((PieceMovedEvent)subjectEvent);

            return;



        }


    }
}
