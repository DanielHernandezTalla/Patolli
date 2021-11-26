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
        private List<IObserver> observers;

        public GameManager()
        {
            observers = new List<IObserver>();
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

            else if (type.Equals("otro"))
                Start(e);

            else if (type.Equals("StartGame"))
                Start(e);

            else if (type.Equals("ExecuteTurn"))
                ExecuteTurn(e);

            else
                throw new Exception("No se reconocio el evento que llego al GameController.");

        }

        public void SetUp(Event e)
        {
            if (Game == null)
            {
                
                GameSettings settings = Transporte.Serialization.Serialize.JobjToObject<GameSettings>(e.Data);

                //... Configuracion ...

                int PlayersQuantity = settings.Users.Count;

                Game = new Game(2, settings.PiecesQuantity);

                Game.BladeSize = settings.BladeSize;

                List<User> UserListInClient = settings.Users;
                List<User> UserListInServer = Server.UsersConnected;

                bool IsCorrect = true;

                string[] players = new string[PlayersQuantity];
                if (PlayersQuantity == UserListInServer.Count)
                {
                    for (int i = 0; i < UserListInClient.Count; i++)
                    {
                        if (!UserListInClient[i].Name.Equals(UserListInServer[i].Name))
                            IsCorrect = false;

                        players[i] = UserListInClient[i].Name;
                    }
                }
                else IsCorrect = false;

                if (!IsCorrect) throw new Exception("La lista de usuarios no es igual a la del servidor. Implementar solucion.");

                // Prueba ...
                players = new string[]{ players[0], "Prueba" };

                Game.PlayerNames = players;

                // Observadores

                foreach (IObserver observer in observers)
                {
                    Game.AddGameObserver(observer);
                }

                //.....................

                Game.Create();
            }
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
