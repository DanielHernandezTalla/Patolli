using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun;
using Eventos;
using Entidades.Game;
using Entidades.Connection;

namespace Servidor.GameManagement
{
    class GameManager
    {
        private Game Game;
        private readonly List<IObserver> observers;
        private readonly Server server;

        public GameManager(Server server)
        {
            observers = new List<IObserver>();
            this.server = server;
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Update(Event e)
        {
            string type = e.EventType;

            if (type.Equals("SetUpGame"))
                SetUp(e);

            else if (type.Equals("StartGame"))
                Start(e);

            else if (type.Equals("ExecuteTurn"))
                ExecuteTurn(e);

            else if (type.Equals("otro"))
                Start(e);

            else
                throw new Exception("No se reconocio el evento que llego al GameController.");

        }

        public void SetUp(Event e)
        {
            if (Game == null)
            {
                
                GameSettings settings = Transporte.Serialization.Serialize.JobjToObject<GameSettings>(e.Data);

                //... Configuracion ...

                List<User> sentUsers = settings.Users;

                // Prueba
                if (sentUsers.Count == 1)
                    Game = new Game(2, settings.PiecesQuantity);
                else
                    Game = new Game(sentUsers.Count, settings.PiecesQuantity);

                if(EqualLists(sentUsers, out string[] players))
                {
                    // Asignar identificador de jugador

                    for (int i = 0; i < server.ClientReferences.Count; i++)
                    {
                        server.ClientReferences[i].ServerController.User.Number = i;
                    }
                }

                // Prueba ...
                
                if(players.Length == 1)
                {
                    players = new string[] { players[0], "Prueba" };
                }
                
                Game.PlayerNames = players;

                Game.BladeSize = settings.BladeSize;

                // Observadores

                foreach (IObserver observer in observers)
                {
                    Game.AddGameObserver(observer);
                }

                //.....................

                Game.Create();
            }
        }
        private bool EqualLists(List<User> sentUsers, out string[] names)
        {
            bool IsCorrect = true;
            int PlayersQuantity = sentUsers.Count;

            names = new string[PlayersQuantity];

            if (PlayersQuantity == server.ClientReferences.Count)
            {
                for (int i = 0; i < sentUsers.Count; i++)
                {
                    if (!sentUsers[i].Name.Equals(server.ClientReferences[i].Name))
                        IsCorrect = false;

                    names[i] = sentUsers[i].Name;
                }
            }
            else IsCorrect = false;

            if (!IsCorrect) throw new Exception("La lista de usuarios no es igual a la del servidor. Implementar solucion.");

            return IsCorrect;
        }

        public void Start(Event e)
        {
            Game.Start();
        }

        public void ExecuteTurn(Event e)
        {

        }
    }
}
