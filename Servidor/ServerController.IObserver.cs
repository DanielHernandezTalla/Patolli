using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    partial class ServerController : Eventos.ISubject
    {
        public void Update(Eventos.Event gameEvent)
        {
            // Transforma el objeto evento en una entidad evento.
            Entidades.Events.Event response = new Entidades.Events.Event();
            response.Fill(gameEvent);

            // Envia el evento respuesta hacia el servidor para que lo envie a todos los clientes.
            server.Send(response);
        }
    }
}
