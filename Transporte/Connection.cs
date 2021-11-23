using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Entidades.Connection;

namespace Transporte
{
    public class Connection
    {
        protected int BUFFER_SIZE = 16384;

        protected Socket socket;

        private readonly string ip;
        private readonly int port;

        // Variables de la conexión
        protected IPHostEntry host;
        protected IPAddress address;
        protected IPEndPoint endPoint;

        public Connection(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public void Create()
        {
            host = Dns.GetHostEntry(ip);
            address = host.AddressList[0];
            endPoint = new IPEndPoint(address, port);

            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Close()
        {
            socket.Close();
        }

    }
}
