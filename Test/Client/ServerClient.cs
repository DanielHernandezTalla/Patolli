using SocketsLibrary.Client;
using SocketsLibrary.Client.Controller;
using SocketsLibrary.Models;
using SocketsLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Test;

namespace SocketsForms.Client
{
    public class ServerClient
    {
        // Variable para iniciar con la conexion
        Socket socketClient;
        IPEndPoint endPoint = null;

        // Forms
        public frmIpPort frmIpPort { get; set; }
        public frmRoom frmRoom { get; set; }

        //public ServerClient(string ip, int port, frmIpPort _frmIpPort, frmRoom _frmRoom)
        public ServerClient(string ip, int port, frmIpPort _frmIpPort, frmRoom _frmRoom)
        {
            this.frmIpPort = _frmIpPort;
            this.frmRoom = _frmRoom;

            try
            {
                // Creando conexion 
                IPHostEntry host = Dns.GetHostEntry(ip);
                IPAddress address = host.AddressList[0];
                endPoint = new IPEndPoint(address, port);
                //endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                socketClient = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Start()
        {
            // Conectandonos al servidor
            socketClient.Connect(endPoint);

            while (true)
            {
                try
                {
                    // Cada ves que llega algo del cliente, el servidor lo escucha y lo procesa, dependiendo de la ruta
                    byte[] buffer = new byte[1024];

                    socketClient.Receive(buffer);

                    SocketRequest socketRequest = Serialize.ByteToObject(buffer);

                    ClientRouter.Routes(socketRequest, Session.Controller);

                }
                catch (Exception )
                {
                    socketClient.Close();
                    endPoint = null;
                }
            }

        }

        public void Send(User user, string url, Object body)
        {
            // Para enviar mensajes al servidor
            byte[] byteMensaje = Serialize.ObjectToByte(user, url, body);
            socketClient.Send(byteMensaje);
        }

        public void Close()
        {
            socketClient.Close();
            endPoint = null;

            //frmIpPort = null;
            //frmRoom = null;
        }
    }
}
