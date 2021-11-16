using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GameEvents
{
    public class GameCreatedEvent : Eventos.Event
    {
        private GamePathLogic.Squares.Square[] gamePath;

        public override object Data { get => gamePath; }

        public GameCreatedEvent(GamePathLogic.Squares.Square[] gamePath) : base("GameCreated", "La partida ha sido creada.")
        {
            this.gamePath = gamePath;
        }
    }
}
