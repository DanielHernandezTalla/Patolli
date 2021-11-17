using Newtonsoft.Json;
using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Test.Client
{
    public class ClientController
    {
        public ServerClient MySocket { get; set; }
        public User MyUser { get; set; }
        public Main.PlayerGame GameForm { get; set; }

        public ClientController(ServerClient _socket, User _user)
        {
            MySocket = _socket;
            MyUser = _user;
                        
            Init();
        }

        public void Init()
        {
            MySocket.Send(MyUser, "Init", false);
        }

        public void InitRes(SocketRequest socketRequest)
        {
            MySocket.frmIpPort.newUpdate();
        }

        public void AddNewUser(SocketRequest socketRequest)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(socketRequest.Body.ToString());

            foreach (var user in users)
            {
                MySocket.frmRoom.newUpdate(user);
            }
        }
        
        public void GetGame()
        {
            MySocket.Send(MyUser, "GetGame", false);
        }

        public void GameCreated(SocketRequest socketRequest)
        {
            // Se esta mandando el evento de la creacion del juego manualmente. Debe cambiar.

            LogicaDeNegocio.GamePathLogic.Squares.SerializableSquare[] GamePath = JsonConvert.DeserializeObject<LogicaDeNegocio.GamePathLogic.Squares.SerializableSquare[]>(socketRequest.Body.ToString());

            LogicaDeNegocio.GameEvents.GameCreatedEvent e = new LogicaDeNegocio.GameEvents.GameCreatedEvent(GamePath);

            GameForm.GameCreated(e);
        }

        public void NotFound()
        {

        }
    }
}
