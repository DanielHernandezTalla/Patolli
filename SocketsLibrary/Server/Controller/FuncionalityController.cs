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
        /// <summary>
        /// Metodo que notifica que tienes acceso al server
        /// </summary>
        public void Init(SocketRequest socketRequest)
        {
            MyUser = socketRequest.User;
            Users[0].User = MyUser;

            byte[] response = Serialize.ObjectToByte("Init", true);
            MySocket.Send(response);
        }

        public void AddNewUser()
        {
            byte[] response = new byte[16384];
            List<User> usuarios = new List<User>();
            foreach (var user in Users)
            {
                if(user.User != MyUser)
                    usuarios.Add(user.User);
            }
            response = Serialize.ObjectToByte("AddNewUser", 200, usuarios);
            MySocket.Send(response);
        }

        public void TestRoutes()
        {
            byte[] response = Serialize.ObjectToByte("TestRoutes", 200, "TestRoutes al 100");
            MySocket.Send(response);
        }

        public void Login(SocketRequest socketRequest)
        {
            byte[] response;

            User newUser = JsonConvert.DeserializeObject<User>(socketRequest.Body.ToString());

            if (newUser.Name.Equals("Admin") && newUser.Password.Equals("Admin"))
            {
                MyUser = newUser;
                MyUser.Access = true;

                response = Serialize.ObjectToByte(MyUser, "Login");

                MySocket.Send(response);
            }
            else
            {
                response = Serialize.ObjectToByte(MyUser, "Login");
                MySocket.Send(response);
            }
        }

        public void StartGame()
        {
            // El objeto game se supone que esta creado antes y ya configurado
            if (Game == null)
                Game = new LogicaDeNegocio.Game();

            //----------
            if(!Game.IsCreated && !Game.IsStarted)
            {
                // Esto va en la config

                Game.BladeSize = 7;

                // añadir observadores

                // --------------------


                Game.Create();
                Game.Start();

                // Esta respuesta es temporal. Lo correcto seria que el propio Game se comunique con el controlador
                // para que él avise de los eventos de juego.
                byte[] response = new byte[16384];
                response = Serialize.ObjectToByte("GameCreated", 200, Game.TESTGetGamePath());
                MySocket.Send(response);
            }
        }
    }
}
