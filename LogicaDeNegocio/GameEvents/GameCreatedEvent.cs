using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GameEvents
{
    public class GameCreatedEvent : Eventos.Event
    {
        private GamePathLogic.Squares.SerializableSquare[] gamePath;

        public override object Data { get => gamePath; }

        public GameCreatedEvent(GamePathLogic.Squares.SerializableSquare[] gamePath) : base("GameCreated", "La partida ha sido creada.")
        {
            this.gamePath = gamePath;
        }
    }
}
