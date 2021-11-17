using Newtonsoft.Json;
using SocketsLibrary.Models;
using SocketsLibrary.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Server.Controller
{
    public partial class SocketController
    {
        #region Objetos principales que guardan la conexion y tu usuario
        // Objetos principales que guardan la conexion y tu usuario
        public Socket MySocket { get; set; }
        public User MyUser { get; set; }
        public List<UserAndSocket> Users { get; set; }

        #endregion

        // Objetos del Juego
        private LogicaDeNegocio.Game Game;

        #region Contructor 
        // Creando las instancias de los objetos principales
        public SocketController(Socket _MySocket, User _MyUser, List<UserAndSocket> _users)
        {
            MySocket = _MySocket;
            MyUser = _MyUser;
            Users = _users; 
        }

        #endregion

        // Solo esta parte se debe de modificar
        #region Rutas generales de proyecto
        // Los metodos generales se escribiran en un archivo parcial aparte
        #endregion

        #region Ruta NotFound

        // Para Cuando se manda una ruta erronea
        public void NotFound()
        {
            byte[] response = Serialize.ObjectToByte("NotFound", 404, "Recurso no encontrado.");
            MySocket.Send(response);
        }

        #endregion
    }
}
