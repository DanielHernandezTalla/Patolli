using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Client
{
    class ClientReference
    {
        public ServerController ServerController { get; set; }

        public Transporte.ClientConnection ClientConnection { get; set; }

        public string Name { get => ServerController.User.Name; }

        public ClientReference(Transporte.ClientConnection clientConnection, ServerController serverController)
        {
            ClientConnection = clientConnection;
            ServerController = serverController;
        }
    }
}
