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
        public void Update(Event responseEvent)
        {
            string eventType = responseEvent.EventType;

            if (eventType.Equals("UserIdentified"))
            {
                connectionForm.UserIdentified(responseEvent);
                roomForm.UserIdentified(responseEvent);
            }

            else if (eventType.Equals("NumbersAssigned"))
                gameForm.NumbersAssigned(responseEvent);

            else if (eventType.Equals("GameCreated"))
            {
                roomForm.GameCreated(responseEvent);
                gameForm.GameCreated(responseEvent);
            }

            else if (eventType.Equals("TurnChanged"))
                gameForm.TurnChanged(responseEvent);


            else if (eventType.Equals("ThrownCanas"))
                gameForm.ThrownCañas(responseEvent);

            else if (eventType.Equals("PieceStarted"))
                gameForm.PieceStarted(responseEvent);

            else if (eventType.Equals("PieceMoved"))
                return;

            else
                throw new Exception("No se indentificó el evento que llegó al FormsController.");
        }
    }
}
