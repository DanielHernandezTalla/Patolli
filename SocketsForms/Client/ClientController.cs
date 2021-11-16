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

        private void Init()
        {
            MySocket.Send(MyUser, "Init", false);
        }

        public void InitRes(SocketRequest socketRequest, frmIpPort _frmIpPort, frmRoom _frmRoom)
        {
            //cMessageBox.Show(socketRequest.Body.ToString());
            _frmIpPort.newUpdate();
        }

        public void TestRoutesClient(SocketRequest socketRequest)
        {
            MessageBox.Show(socketRequest.Body.ToString() + " TEST ROUTES CLIENT");
        }

        public void AddNewUser(SocketRequest socketRequest, frmIpPort _frmIpPort, frmRoom _frmRoom)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(socketRequest.Body.ToString());

            foreach(var user in users)
            {
                _frmRoom.newUpdate(user);
            }
        }

        public void NotFound()
        {

        }
    }
}
