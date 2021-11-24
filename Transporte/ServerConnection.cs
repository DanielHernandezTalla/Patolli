using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transporte
{
    public class ServerConnection : Connection
    {
        private Queue<Socket> clientSockets;

        public ServerConnection(string ip, int port) : base(ip, port) 
        {
            clientSockets = new Queue<Socket>();
        }

        public void Bind()
        {
            socket.Bind(endPoint);
        }

        public void Listen()
        {
            
            socket.Listen(10);
        }

        public bool AcceptClient()
        {
            // Esperamos a que un cliente se conecte
            Socket socketClient = socket.Accept();

            clientSockets.Enqueue(socketClient);

            return true;
        }

        public bool PendingClientSocketExists()
        {
            if (clientSockets.Count > 0)
                return true;
            else
                return false;
        }

        public Socket DequeueClientSocket()
        {
            if (PendingClientSocketExists())
                return clientSockets.Dequeue();
            else
                throw new Exception("No hay conexiones de clientes pendientes.");
        }

    }
}
