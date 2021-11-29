using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GameEvents
{
    public class PieceMovedEvent : Eventos.Event
    {
        private List<Elements.PieceMovement> movements;

        public override object Data { get => movements; }

        public PieceMovedEvent(List<Elements.PieceMovement> movements, int player, int piece) : base("PieceMoved", "Una ficha se ha movido.")
        {
            this.movements = movements;
            this.PlayerNumber = player;
            this.PieceNumber = player;
        }
    }
}
