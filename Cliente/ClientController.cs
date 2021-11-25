using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente;

namespace Cliente
{
    public partial class ClientController
    {
        private Client client;

        public ClientController(Client client)
        {
            this.client = client;
            observers = new List<Eventos.IObserver>();
        }

        public void ProcessResponse(Entidades.Events.Event response)
        {
            // Convierte la entidad event a un objeto event.
            Eventos.Event eventResponse = response.MakeCopy();

            // Envia el evento a los observadores. (Al form del jugador)
            NotifyObservers(eventResponse);
        }

        public void Update(Eventos.Event clientEvent)
        {
            // Transforma el objeto evento en una entidad evento.
            Entidades.Events.Event request = new Entidades.Events.Event();
            request.Fill(clientEvent);

            // Envia el evento solicitud hacia el hacia el servidor.
            client.Send(request);
        }
    }
}
