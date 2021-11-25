using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    partial class ServerController
    {
        private readonly Server server;
        private readonly GameController gameController;

        public ServerController(Server server)
        {
            this.server = server;
        }


        public void ProcessRequest(Entidades.Events.Event request)
        {
            // Convierte la entidad event a un objeto event.
            Eventos.Event eventRequest = request.MakeCopy();

            // Envia el evento al juego. (Al Game)
            NotifyGame(eventRequest);
        }

        public void NotifyGame(Eventos.Event eventRequest)
        {
            // Enviar el evento al encargado directo de modificar el juego.
            gameController.Update(eventRequest);
        }
    }
}
