using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Client
{
    public class ClientRouter
    {
        public static void Routes(SocketRequest socketRequest, ClientController controller)
        {
            if (socketRequest.Url.Equals("InitRes"))
                controller.InitRes(socketRequest);

            else if (socketRequest.Url.Equals("AddNewUser"))
                controller.AddNewUser(socketRequest);

            else if (socketRequest.Url.Equals("GameCreated"))
                controller.GameCreated(socketRequest);

            else
                controller.NotFound();
        }
    }
}
