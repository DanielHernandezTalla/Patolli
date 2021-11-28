using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GameEvents
{
    class PieceStartedEvent : Eventos.Event
    {
        private Elements.GamePiece piece;

        public override object Data { get => piece; }

        public PieceStartedEvent(Elements.GamePiece piece) : base("PieceStarted", "Una ficha se inicializó.")
        {
            this.piece = piece;
        }
    }
}
