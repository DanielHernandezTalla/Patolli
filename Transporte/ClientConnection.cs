using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Entidades.Connection;
using Transporte.Serialization;
using Entidades.Events;

namespace Transporte
{
    public class ClientConnection : Connection
    {
        private Queue<string> messageQueue = new Queue<string>();

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

        public void Send(Entidades.Events.Event eventMessage)
        {
            byte[] message = Serialize.ObjectToByte(eventMessage);

            socket.Send(message);
        }

        public Entidades.Events.Event Receive()
        {
            byte[] buffer = new byte[BUFFER_SIZE];

            // Se queda esperando a que reciva algo...
            socket.Receive(buffer);

            Queue<string> pendingMessages = Serialize.ByteToString(buffer);

            if(pendingMessages != null && pendingMessages.Count > 0)
            {
                for (int i = 0; i < pendingMessages.Count; i++)
                {
                    messageQueue.Enqueue(pendingMessages.Dequeue());
                }
            }

            Event eventMessage = Serialize.StringToObject(messageQueue.Dequeue());

            return eventMessage;
        }
    }
}
