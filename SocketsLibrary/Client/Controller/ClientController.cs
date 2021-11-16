using Newtonsoft.Json;
using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Client.Controller
{
    public class ClientController
    {
        public ServerClient MySocket { get; set; }
        public User MyUser { get; set; }
        public ClientController(ServerClient _socket, User _user)
        {
            MySocket = _socket;
            MyUser = _user;
        }

        public Object Init()
        {
            MySocket.Send(MyUser, "Init", false);
            SocketRequest serverMessage = MySocket.Receive();
            return serverMessage.Body;
            //Console.WriteLine("User: " + serverMessage.User + ", Mensaje: " + serverMessage.Body.ToString());
        }

        public Object AddNewUser()
        {
            SocketRequest serverMessage = MySocket.Receive();

            return JsonConvert.DeserializeObject<User>(serverMessage.Body.ToString());
        }

        public void Login()
        {
            Console.Write("Ingresa el Admin: ");
            MyUser.Name = Console.ReadLine();

            Console.Write("Ingresa el password: ");
            MyUser.Password = Console.ReadLine();

            //MySocket.Send(MyUser, "Login");

            SocketRequest repuesta = MySocket.Receive();

            if (repuesta.User.Access)
            {
                MyUser = repuesta.User;
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failled");
            }
        }
    }
}
