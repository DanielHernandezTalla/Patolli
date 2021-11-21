using Newtonsoft.Json;
using SocketsLibrary.Models;
using SocketsLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Server.Controller
{
    public partial class SocketController
    {
        public void Connected()
        {
            // Respondemos que se tiene conexion con el servidor 
            byte[] response = Serialize.ObjectToByte("InitRes", true);
            MySocket.Send(response);
        }

        public void Init(SocketRequest socketRequest)
        {
            // Notifico que se puede iniciar
            MyUser = socketRequest.User;
            Users[0].User = MyUser;

            byte[] response = Serialize.ObjectToByte("Init", true);
            MySocket.Send(response);
        }

        public void GetUsers()
        {
            // Obtengo los usuarios que estan en el server
            byte[] response = new byte[16384];
            List<User> usuarios = new List<User>();
            
            foreach (var user in Users)
                if(user.User != MyUser)
                    usuarios.Add(user.User);

            response = Serialize.ObjectToByte("AddNewUser", 200, usuarios);
            MySocket.Send(response);

            // Notifico a los usuarios del server que me he conectado
            usuarios = new List<User>();
            usuarios.Add(MyUser);

            Notify(MyUser, "AddNewUser", usuarios);
        }

        public void GetOut(SocketRequest socketRequest)
        {
            //Elimino el users de la lista de usuarios
            foreach (var user in Users)
                if (user.User.Name == socketRequest.User.Name)
                {
                    Users.Remove(user);
                    break;
                }

            List<User> usuarios = new List<User>();

            foreach (var user in Users)
            {
                usuarios.Clear();

                foreach (var user2 in Users)
                    if (user != user2)
                        usuarios.Add(user2.User);

                byte[] response = Serialize.ObjectToByte("GetOutUser", 200, usuarios);
                user.Socket.Send(response);
            }
        }

        public void GetGame()
        {
            // El objeto game se supone que esta creado antes y ya configurado
            if (Game == null)
                Game = new LogicaDeNegocio.Game();

            //----------
            if(!Game.IsCreated && !Game.IsStarted)
            {
                // Esto va en la config

                // añadir observadores

                // --------------------


                Game.Create();
                Game.Start();

                // Esta respuesta es temporal. Lo correcto seria que el propio Game se comunique con el controlador
                // para que él avise de los eventos de juego.
                NotifyAll("GameCreated", Game.TESTGetGamePath());
                //byte[] response = new byte[16384];
                //response = Serialize.ObjectToByte("GameCreated", 200, Game.TESTGetGamePath());
                //MySocket.Send(response);
            }
        }
    }
}
