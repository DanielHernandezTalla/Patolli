using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.User;
using Presentacion.Forms;

namespace Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Exception exit = new Exception("");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try 
            {
                Session.MyUser = new Entidades.Connection.User();
                Session.FormsController = new Controller.FormsController();

                // Autentificación.

                Application.Run(new AuthForm());

                if (Session.MyUser.Name == null)
                    throw exit;

                // Seleccionar Rol de usuario.

                Application.Run(new ClientServerForm());

                if (Session.Role == Session.SessionRole.NoInitialized)
                    throw exit;

                // Crear o Conectarse al ser servidor.

                ConnectionForm Connection = new ConnectionForm();
                Session.FormsController.SetConnectionForm(Connection);

                RoomForm Room = new RoomForm();
                Session.FormsController.SetRoomForm(Room);

                Application.Run(Connection);

                if (!Session.Connected)
                    throw exit;

                // Entrar al lobby de la partida.

                PlayerGameForm Game = new PlayerGameForm();
                Session.FormsController.SetGameForm(Game);

                Application.Run(Room);

                if (!Session.GameReady)
                    throw exit;

                // Entrar a la partida.

                Application.Run(Game);



                // Mostrar resultado.



            }
            catch(Exception e)
            {
                MessageBox.Show("El programa finalizó. " + e.Message);

                CloseThreads();
            }

        }

        static void CloseThreads()
        {
            if (Session.Server != null)
                Session.Server.Close();

            if (Session.Client != null)
                Session.Client.Close();

            Session.ThreadServer = null;
            Session.ThreadClient = null;
        }
    }
}
