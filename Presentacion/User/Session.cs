using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Cliente;
using Servidor;
using Entidades.Connection;
using Presentacion.Controller;

namespace Presentacion.User
{
    public class Session
    {
        // Propiedades del Servidor

        public static Server Server { get; set; }

        public static Thread ThreadServer { get; set; }

        // Propiedades del Cliente

        public static Client Client { get; set; }

        public static Thread ThreadClient { get; set; }

        // Propiedades generales

        public static Entidades.Connection.User MyUser { get; set; } 

        public static List<Entidades.Connection.User> Users { get; set; }

        public static SessionRole Role { get; set; }

        public static string Ip { get; set; }

        public static string Port { get; set; }

        // Banderas

        public static bool Connected { get; set; }

        public static bool GameReady { get; set; }

        // Control de los forms

        internal static FormsController FormsController { get; set; }
        
        // Datos de la partida

        public static int PlayerQuantity { get; set; }
        public static int PieceQuantity { get; set; }

        public enum SessionRole
        {
            NoInitialized,
            Server,
            Client
        }
    }
}
