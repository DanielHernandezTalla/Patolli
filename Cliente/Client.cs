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
        private readonly ClientConnection connection;
        private readonly ClientController controller;

        public Client(string ip, int port)
        {
            connection = new ClientConnection(ip, port);
            controller = new ClientController(this);
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
        
        public void Subscribe(Eventos.IObserver observer)
        {
            controller.Subscribe(observer);
        }

        public ClientController GetController()
        {
            return controller;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
