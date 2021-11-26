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
        
        public User User { get; private set; }

        public ServerController(Server server)
        {
            this.server = server;

            gameManager = new GameManagement.GameManager();

            gameManager.Subscribe(this);
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

            if (eventType.Equals("UserIdentify"))
                UserIdentify(eventRequest);

            else
                throw new Exception("No se reconocio el evento que llego al ServerController.");

        }

        // Si fue un evento para el propio server, ya que se procese, se le tonifica a la parte del server encargada de responder.
        private void NotifyResponse(Eventos.Event eventRequest)
        {
            this.Update(eventRequest);
        }

        


        // --------Eventos que procesa el servidor----------

        private void UserIdentify(Eventos.Event eventRequest)
        {
            // El evento esta deserializado, pero falta deserializar el contenido Data.
            eventRequest.Data = Transporte.Serialization.Serialize.JobjToObject<User>(eventRequest.Data);

            // Ejecutar solicitud
            if(User == null)
                User = (User)eventRequest.Data;

            Server.UsersConnected.Add(User);

            // Respuesta
            List<User> users = server.Users;
            Eventos.Event eventResponse = new ServerEvents.UserIdentifiedEvent(users);

            NotifyResponse(eventResponse);
        }
    }
}
