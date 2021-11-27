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

            else if (eventType.Equals("GameCreated"))
            {
                gameForm.GameCreated(responseEvent);
                roomForm.GameCreated(responseEvent);
            }

            else if (eventType.Equals("GameStarted"))
                return;

            else if (eventType.Equals("TurnChanged"))
                gameForm.TurnChanged(responseEvent);

            else if (eventType.Equals("PieceMoved"))
                return;

            else
                throw new Exception("No se indentificó el evento que llegó al FormsController.");
        }
    }
}
