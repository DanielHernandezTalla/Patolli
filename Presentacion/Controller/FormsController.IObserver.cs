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
        public void Update(Event subjectEvent)
        {
            string eventType = subjectEvent.EventType;

            if (eventType.Equals("UserIdentified"))
            {
                connectionForm.UserIdentified(subjectEvent);
                roomForm.UserIdentified(subjectEvent);
            }
                
            else if (eventType.Equals("GameCreated"))
            {
                gameForm.GameCreated(subjectEvent);
                roomForm.GameCreated(subjectEvent);
            }

            else if (eventType.Equals("GameStarted"))
                return;

            else if (eventType.Equals("TurnChanged"))
                return;

            else if (eventType.Equals("PieceMoved"))
                return;

            else
                throw new Exception("No se indentificó el evento que llegó al FormsController.");
        }
    }
}
