using Test.Client;
using SocketsLibrary.Models;
using SocketsLibrary.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test
{
    public static class Session
    {
        // Para cuando es server
        public static Server Server { get; set; }

        public static Thread ThreadServer { get; set; }

        // Propiedades generales
        public static User User{ get; set; }

        public static SessionRole Role { get; set; }

        public static string IP { get; set; }

        public static int Port { get; set; }

        public static ServerClient ServerClient { get; set; }

        public static ClientController Controller { get; set; }

        public static Thread ThreadClient { get; set; }

        public static bool GameStarted { get; set; }

        

        public enum SessionRole
        {
            NoInitialized,
            Server, 
            Client
        }
    }
}
