using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Actions;

namespace GameRun.GamePathLogic.Squares
{
    class CenterSquare : Square
    {
        public CenterSquare(Receiver receiver)
        {
            AddAction(new EatPieceAction(receiver));

            Type = SquareType.Center;

            // La casilla de centro es cuadrada.
            Width = WIDTH;
            Height = WIDTH;
        }
    }
}
