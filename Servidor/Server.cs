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

        public bool Listening { get; set; }

        public Server(string ip, int port)
        {
            connection = new ServerConnection(ip, port);
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
            if(connection.PendingConnectionExists())
            {
                ClientConnection connection_clientReference = new ClientConnection(connection.GetPendingClientSocket());

                try
                {
                    while (true)
                    {
                        // Receive
                        SocketRequest request = connection_clientReference.Receive();

                        

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
    }
}
