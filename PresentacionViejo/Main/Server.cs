using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio;

namespace Presentacion.Main
{
    public class Server
    {
        private Game Game;

        public Server(Game game)
        {
            if (game.IsCreated || game.IsStarted)
                throw new Exception("Se debe asignar un Juego que no este inicializado.");

            Game = game;
        }

        /// <summary>
        /// Inicializar el juego. Crea la partida con las configuraciones que fueron especificadas
        /// y lo empieza para que este listo para jugarse.
        /// </summary>
        public void Initialize()
        {
            Game.Create();
            Game.Start();
        }
    }
}
