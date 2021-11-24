using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos;

namespace Servidor
{
    partial class ServerController
    {
        private readonly Server server;

        public ServerController(Server server)
        {
            this.server = server;

            observers = new List<IObserver>();
        }


        public void ProcessRequest(Entidades.Events.Event request)
        {
            // Convierte la entidad event a un objeto event.
            Eventos.Event eventRequest = request.MakeCopy();

            // Enviar los eventos al juego? o que el servidor modifique el juego?

            // Envia el evento a los observadores. (Al Game)
            NotifyObservers(eventRequest);
        }
    }
}
