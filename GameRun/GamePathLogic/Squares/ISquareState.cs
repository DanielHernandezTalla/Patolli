using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GamePathLogic.Squares
{
    interface ISquareState
    {
        bool IsOccupied { get; }
        Elements.Point PlayerPiece { get; }
        string Name { get; }
        Square.SquareType Type { get; }
    }
}
