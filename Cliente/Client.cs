using Entidades.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transporte;

namespace Cliente
{
    public class Client
    {
        private ClientConnection connection;

        public Client(string ip, int port)
        {
            connection = new ClientConnection(ip, port);
        }

        public void Start()
        {
            ClientController controller = new ClientController(this);

            try
            {
                connection.Create();
                connection.Connect();

                while(true)
                {
                    // Send

                    // Receive
                    Entidades.Events.Event response = connection.Receive();

                    controller.ProcessResponse(response);
                }

            }
            catch (Exception e)
            {
                connection.Close();
                throw new Exception("Algo falló en el thread de la conexión del cliente.\n" + e.Message);
            }
        } 

        public void Send(Entidades.Events.Event request)
        {
            connection.Send(request);
        }
        
    }
}
