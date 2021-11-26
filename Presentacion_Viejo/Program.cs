using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Main;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // CONFIGURACION DE PARTIDA: 

            // Form de la partida local. En este caso el Host.
            PlayerGame frmHost = new PlayerGame();


            // Se crean los observadores para los interesados.
            GameStatus.GameStatusObserver observer = new GameStatus.GameStatusObserver(frmHost);

            // Se crea la instancia de la partida y se añaden los obeservadores.
            LogicaDeNegocio.Game game = new LogicaDeNegocio.Game
            {
                BladeSize = 7
            };
            game.AddGameObserver(observer);

            // Se crea el host y empieza la partida.
            Server server = new Server(game);
            server.Initialize();

            // Se lanza la visualizacion de la interfaz para el jugador.
            Application.Run(frmHost);


        }
    }
}
