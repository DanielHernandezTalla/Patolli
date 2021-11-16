using Newtonsoft.Json;
using SocketsLibrary.Models;
using SocketsLibrary.Server.Controller;
using SocketsLibrary.Server.Routers;
using SocketsLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketsLibrary.Server
{
    public class Server
    {
        List<UserAndSocket> Users { get; set; }

        #region Configuracion del servidor
        public Socket socket;

        private string ip { get; set; }
        private int port { get; set; }
        #endregion

        #region Constructor
        public Server(string _ip, int _port)
        {
            this.ip = _ip;
            this.port = _port;

            Users = new List<UserAndSocket>();
        }
        #endregion

        // Cuando se inicia el servidor
        public void Start()
        {
            try
            {
                // Creando las variables iniciales para la conexion
                IPHostEntry host = Dns.GetHostEntry(ip);
                IPAddress address = host.AddressList[0];
                IPEndPoint endPoint = new IPEndPoint(address, port);

                // Creando el sockets 
                socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(endPoint);
                socket.Listen(10);

                // Variables para poder aceptar mas de un cliente
                Socket socketClient;
                Thread thread;
                while (true)
                {
                    // Esperando conexiones 
                    Console.Write("Esperando conexiones...");

                    // Se acepta la conexion
                    socketClient = socket.Accept();

                    // Creamos el hilo para este nuevo cliete
                    thread = new Thread(ClienteConnection);
                    thread.Start(socketClient);
                    Console.WriteLine("Se ha conectado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Cuando el cliente se conecta y obtiene su hilo
        public void ClienteConnection(object s)
        {
            // Obtenemos el socket personal
            Socket mySocket = (Socket)s;
            User myUser = new User();

            // Recivimos el nombre del nuevo usuario y lo agregamos a la lista
            byte[] buffer = new byte[1024];
            mySocket.Receive(buffer);

            SocketRequest socketRequest = Serialize.ByteToObject(buffer);

            myUser = socketRequest.User;

            // Agregamos nuestro usuario al la lista de usuarios
            UserAndSocket US = new UserAndSocket()
            {
                User = myUser,
                Socket = mySocket
            };

            Users.Add(US);

            // Respondemos que se tiene conexion con el servidor 
            byte[] response = Serialize.ObjectToByte("InitRes", true);
            mySocket.Send(response);

            // Creamos nuestro controller y le pasamos nuestro socket
            SocketController controller = new SocketController(mySocket, myUser, Users);

            controller.AddNewUser();

            notificar(myUser);

            try
            {
                while (true)
                {
                    // Cada ves que llega algo del cliente, el servidor lo escucha y lo procesa, dependiendo de la ruta
                    buffer = new byte[1024];
                    mySocket.Receive(buffer);

                    socketRequest = Serialize.ByteToObject(buffer);

                    if (socketRequest == null)
                    {
                        mySocket.Close();
                        break;
                    }
                    else
                        // Aqui se procesan las rutas
                        Router.Routes(socketRequest, controller);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha desconectado un cliente" + e.Message);
            }
        }

        void notificar(User myUser)
        {
            byte[] response = new byte[1024];
            List<User> usuarios = new List<User>();

            usuarios.Add(myUser);
            
            response = Serialize.ObjectToByte("AddNewUser", 200, usuarios);
            
            foreach (var user in Users)
            {
                if(user.User != myUser)
                    user.Socket.Send(response);
            }
        }

        public void Close()
        {
            //if(socket != null)
                socket.Close();
        }
    }
}
