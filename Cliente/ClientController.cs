using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    partial class ClientController
    {

        public ClientController()
        {

        }

        public void ProcessResponse(Entidades.Events.Event response)
        {
            // Convierte la entidad event a un objeto event.
            Eventos.Event eventResponse = response.MakeCopy();

            // Envia el evento a los observadores. (Al form del jugador)
            NotifyObservers(eventResponse);
        }
    }
}
