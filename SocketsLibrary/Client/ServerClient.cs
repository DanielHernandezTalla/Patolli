using Newtonsoft.Json;
using SocketsLibrary.Models;
using SocketsLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Client
{
    public class ServerClient
    {
        // Variable para iniciar con la conexion
        Socket socketClient;
        IPEndPoint endPoint = null;

        // Variables de configuracion
        //public User user { get; set; }


        public ServerClient(string ip, int port)
        {
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

        //public void ConfigureClient(String nombre)
        //{
        //    // Creando configuracion de datos iniciales
        //    user = new User();
        //    user.Name = nombre;
        //}

        public void Start()
        {

            try
            {
                // Conectandonos al servidor
                socketClient.Connect(endPoint);

                // Ponemos a la escucha el cliente
                //while (true)
                //{
                //    byte[] buffer = new byte[1024];

                //    socketClient.Receive(buffer);

                //    SocketRequest sr = Serialize.ByteToObject(buffer);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Send(User user, string url, Object body)
        {
            // Para enviar mensajes al servidor
            byte[] byteMensaje = Serialize.ObjectToByte(user, url, body);
            socketClient.Send(byteMensaje);
        }

        public SocketRequest Receive()
        {
            // Para recivir mensajes del servidor
            byte[] buffer = new byte[1024];

            socketClient.Receive(buffer);

            return Serialize.ByteToObject(buffer);
        }

        public void Close()
        {
            socketClient.Close();
            endPoint = null;
        }
    }
}
