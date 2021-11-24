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
    class Server
    {
        private ServerConnection connection;
        private List<ClientConnection> clientConnections;

        public bool Listening { get; set; }

        public Server(string ip, int port)
        {
            connection = new ServerConnection(ip, port);
            clientConnections = new List<ClientConnection>();
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

                clientConnections.Add(connection_clientReference);

                ServerController controller = new ServerController(this);

                try
                {
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
            foreach (ClientConnection connection in clientConnections)
            {
                connection.Send(response);
            }
        }
    }
}
