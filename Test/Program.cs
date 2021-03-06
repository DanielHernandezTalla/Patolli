using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Session.User = new User();

            Application.Run(new frmAuth());

            if (Session.User.Name == null)
                return;
            
            Application.Run(new frmClientServer());

            if (Session.Role == Session.SessionRole.NoInitialized)
                return;

            frmRoom frmRoom = new frmRoom();

            Application.Run(new frmIpPort(frmRoom));

            if (Session.ServerClient == null)
                return;

            Main.PlayerGame game = new Main.PlayerGame();
            Session.Controller.GameForm = game;

            Application.Run(frmRoom);

            if (!Session.GameStarted)
                return;
            
            Application.Run(game);

            closeThreads();
        }

        static void closeThreads()
        {
            if (Session.Server != null)
                Session.Server.Close();

            if (Session.ServerClient != null)
                Session.ServerClient.Close();

            Session.ThreadServer = null;
            Session.ThreadClient = null;
            Session.Controller = null;
        }
    }
}
