using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Connection;

namespace Servidor
{
    /// <summary>
    /// Representa el objeto que controla la referencia hacia un cliente en el servidor.
    /// </summary>
    partial class ServerController
    {
        private readonly Server server;
        private readonly GameManagement.GameManager gameManager;

        public ServerController(Server server)
        {
            this.server = server;

            gameManager = new GameManagement.GameManager(server);

            gameManager.Subscribe(this);
        }

        public User ProcessIdentifyRequest(Entidades.Events.Event identifyRequest)
        {
            Eventos.Event eventRequest = identifyRequest.MakeCopy();

            if (eventRequest.EventType.Equals("UserIdentify"))
                return UserIdentify(eventRequest);
            else
                throw new Exception("Se esperaba que el primer evento en llegar sea la identificacion del usuario.");
        }

        public void ProcessRequest(Entidades.Events.Event request)
        {
            // Convierte la entidad event a un objeto event.
            Eventos.Event eventRequest = request.MakeCopy();

            // ¿Donde se procesara el evento?
            if(eventRequest.ToGame)
                // Envia el evento al juego. (Al Game controller)
                NotifyGame(eventRequest);
            else
                // Se procesa el evento aquí. (En el Server controller)
                Process(eventRequest);
        }

        // Si es un evento para el juego se le tonifica al controlador del Game para que lo procese.
        private void NotifyGame(Eventos.Event eventRequest)
        {
            gameManager.Update(eventRequest);
        }

        // Si es un evento para el propio servidor se procesa aquí.
        private void Process(Eventos.Event eventRequest)
        {
            string eventType = eventRequest.EventType;

            if (eventType.Equals("ThrownCanas"))
                ThrownCañas(eventRequest);

            else
                throw new Exception("No se reconocio el evento que llego al ServerController.");

        }

        // Si fue un evento para el propio server, ya que se procese, se le tonifica a la parte del server encargada de responder.
        private void NotifyResponse(Eventos.Event eventRequest)
        {
            this.Update(eventRequest);
        }

        


        // --------Eventos que procesa el servidor----------

        private User UserIdentify(Eventos.Event eventRequest)
        {
            // El evento esta deserializado, pero falta deserializar el contenido Data.
            eventRequest.Data = Transporte.Serialization.Serialize.JobjToObject<User>(eventRequest.Data);

            // Ejecutar solicitud
            User user = (User)eventRequest.Data;

            Server.UsersConnected.Add(user);

            return user;
        }

        // Cuando se retire un usario aqui iria?

        private void ThrownCañas(Eventos.Event eventRequest)
        {
            eventRequest.Data = Transporte.Serialization.Serialize.JobjToObject<bool[]>(eventRequest.Data);

            // El evento del estado de las cañas no se procesa, se manda de vuelta a todos los usuarios.
            NotifyResponse(eventRequest);
        }

    }
}
