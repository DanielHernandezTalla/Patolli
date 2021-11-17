using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocketsForms.Client
{
    public class ClientRouter
    {


        //public static void Routes(SocketRequest socketRequest, ClientController controller, frmIpPort _frmIpPort, frmRoom _frmRoom)
        //{
        //    //ClientController controller = new ClientController(_socket, _user);

        //    if (socketRequest.Url.Equals("InitRes"))
        //        controller.InitRes(socketRequest, _frmIpPort, _frmRoom);

        //    else if (socketRequest.Url.Equals("TestRoutesClient"))
        //        controller.TestRoutesClient(socketRequest);

        //    else if (socketRequest.Url.Equals("AddNewUser"))
        //        controller.AddNewUser(socketRequest, _frmIpPort, _frmRoom);


        //    else
        //        //controller
        //        controller.NotFound();
        //}

        public static void Routes(SocketRequest socketRequest, ClientController controller)
        {
            //ClientController controller = new ClientController(_socket, _user);

            if (socketRequest.Url.Equals("InitRes"))
                controller.InitRes(socketRequest);

            else if (socketRequest.Url.Equals("AddNewUser"))
                controller.AddNewUser(socketRequest);

            else
                //controller
                controller.NotFound();
        }
    }
}
