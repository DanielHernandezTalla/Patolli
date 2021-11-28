using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Transporte;
using Entidades.Connection;

namespace Servidor
{
    public class Server
    {
        public static List<User> UsersConnected = new List<User>();

        private readonly ServerController controller;
        private readonly ServerConnection connection;

        internal List<Servidor.Client.ClientReference> ClientReferences { get; private set; }

        internal List<User> Users
        {
            get
            {
                List<User> users = new List<User>();

                foreach (var reference in ClientReferences)
                {
                    users.Add(reference.User);
                }

                return users;
            }
        }

        public bool Listening { get; set; }

        public Server(string ip, int port)
        {
            connection = new ServerConnection(ip, port);
            controller = new ServerController(this);

            ClientReferences = new List<Servidor.Client.ClientReference>();
        }

        public void Start()
        {
            Listening = true;

            try 
            {
                connection.Create();
                connection.Bind();
                connection.Listen();

                while(Listening)
                {
                    if (connection.AcceptClient())
                    {
                        Fork();
                    }
                }

            }
            catch(Exception e)
            {
                connection.Close();
                throw new Exception("Algo falló en el thread de la conexión del servidor.\n" + e.Message);
            }
        }

        private void Fork()
        {
            Thread clientThread = new Thread(StartClientConnection);
            clientThread.Start();
        }

        private void StartClientConnection()
        {
            // Si existen conexiones de clientes pendientes...
            if(connection.PendingClientSocketExists())
            {
                ClientConnection connection_clientReference = new ClientConnection(connection.DequeueClientSocket());

                try
                {
                    // Esperar la identificación del usuario.
                    Entidades.Events.Event identifyRequest = connection_clientReference.Receive();
                    User user = controller.ProcessIdentifyRequest(identifyRequest);

                    // Se añade a la lista: la conexion y el usuario.
                    ClientReferences.Add(new Client.ClientReference(connection_clientReference, user));

                    // Se lanza el evento de respuesta.
                    controller.Update(new ServerEvents.UserIdentifiedEvent(Users));

                    // Apartir de aqui el hilo se queda escuchando solicitudes.
                    while (true)
                    {
                        // Receive
                        Entidades.Events.Event request = connection_clientReference.Receive();

                        controller.ProcessRequest(request);

                        // Send
                    }
                }
                catch(Exception e)
                {
                    connection_clientReference.Close();
                    throw new Exception("Algo falló en el thread de la conexión de la referencia del cliente.\n" + e.Message);
                }
            }
        }

        public void Send(Entidades.Events.Event response)
        {
            foreach (var reference in ClientReferences)
            {
                reference.ClientConnection.Send(response);
            }
        }

        /// <summary>
        /// Metodo que inicia el evento que indica que los usuarios fueron asignados con su numero identificador.
        /// </summary>
        public void NumbersAssigned()
        {
            controller.Update(new ServerEvents.NumbersAssignedEvent(Users));
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
