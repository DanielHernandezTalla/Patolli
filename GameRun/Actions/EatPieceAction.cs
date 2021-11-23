using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Actions
{
    class EatPieceAction : IAction
    {
        private readonly Receiver receiver;

        public EatPieceAction(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public bool Execute(GamePathLogic.Squares.ISquareState squareState)
        {
            return receiver.EatPiece(squareState);
        }
    }
}
