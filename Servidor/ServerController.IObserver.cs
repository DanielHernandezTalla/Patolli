using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    partial class ServerController : Eventos.IObserver
    {
        public void Update(Eventos.Event gameEvent)
        {
            // Transforma el objeto evento en una entidad evento.
            Entidades.Events.Event response = new Entidades.Events.Event();
            response.Fill(gameEvent);

            // Envia el evento respuesta hacia el servidor para que lo envie a todos los clientes.
            server.Send(response);
        }

        // Este metodo se utiliza solo por el servidor para enviar especificamente eventos a usuarios especificos.
        public void Update(List<Eventos.Event> responseEvents, List<Client.ClientReference> clientReferences)
        {
            List<Entidades.Events.Event> responses = new List<Entidades.Events.Event>();

            foreach (var item in responseEvents)
            {
                // Transforma el objeto evento en una entidad evento.
                Entidades.Events.Event response = new Entidades.Events.Event();
                response.Fill(item);

                responses.Add(response);
            }

            // Envia el evento respuesta hacia el servidor para que este lo envie a su correspondiente cliente.
            server.Send(responses, clientReferences);
        }
    }
}
