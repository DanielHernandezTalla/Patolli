using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Client
{
    public class ClientReference
    {
        public Entidades.Connection.User User { get; set; }

        public Transporte.ClientConnection ClientConnection { get; set; }

        public ClientReference(Transporte.ClientConnection clientConnection, Entidades.Connection.User user)
        {
            ClientConnection = clientConnection;
            User = user;
        }
    }
}
