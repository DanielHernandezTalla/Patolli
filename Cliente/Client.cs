using Entidades.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transporte;

namespace Cliente
{
    class Client
    {
        private ClientConnection connection;

        public Client(string ip, int port)
        {
            connection = new ClientConnection(ip, port);
        }

        public void Start()
        {
            try
            {
                connection.Create();
                connection.Connect();

                while(true)
                {
                    // Send

                    // Receive
                    SocketRequest request = connection.Receive();
                }

            }
            catch (Exception e)
            {
                connection.Close();
                throw new Exception("Algo falló en el thread de la conexión del cliente.\n" + e.Message);
            }
        }

        
    }
}
