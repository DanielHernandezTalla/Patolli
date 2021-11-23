﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Entidades.Connection;
using Transporte.Serialization;

namespace Transporte
{
    public class ClientConnection : Connection
    {
        private bool IsReference;

        /// <summary>
        /// Constructor para crear desde cero un socket de conexión de un cliente.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public ClientConnection(string ip, int port) : base(ip, port) { }

        /// <summary>
        /// Constructor para crear una conexión a partir de una referencia de un socket de un cliente existente.
        /// </summary>
        /// <param name="socket"></param>
        public ClientConnection(Socket socket) : base("", 0)
        {
            this.socket = socket; 
            IsReference = true;
        }

        public void Connect()
        {
            if(!IsReference)
                socket.Connect(endPoint);
        }

        public void Send()
        {

        }

        public SocketRequest Receive()
        {
            byte[] buffer = new byte[BUFFER_SIZE];

            SocketRequest request = Serialize.ByteToObject(buffer);

            return null;
        }
    }
}
