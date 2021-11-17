using Newtonsoft.Json;
using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SocketsForms.Client
{
    public class ClientController
    {
        public ServerClient MySocket { get; set; }
        public User MyUser { get; set; }


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

        public void NotFound()
        {

        }
    }
}
