using Eventos;
using SocketsLibrary.Models;
using SocketsLibrary.Server.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Server.Routers
{
    public static class Router
    {
        public static void Routes(SocketRequest socketRequest, SocketController controller)
        {
            //SocketController controller = new SocketController(socketC, myUser, users);

            if (socketRequest.Url.Equals("Init"))
                controller.Init(socketRequest);

            else if (socketRequest.Url.Equals("GetOut"))
                controller.GetOut(socketRequest);

            else if (socketRequest.Url.Equals("GetGame"))
                controller.GetGame();
            
            else
                //controller
                controller.NotFound();
        }

    }
}
