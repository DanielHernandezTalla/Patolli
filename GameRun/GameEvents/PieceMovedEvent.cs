using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GameEvents
{
    public class PieceMovedEvent : Eventos.Event
    {
        private Elements.PieceMovement movement;

        public override object Data { get => movement; }

        public PieceMovedEvent(Elements.PieceMovement movement) : base("PieceMoved", "Una ficha se ha movido.")
        {
            this.movement = movement;
        }
    }
}
