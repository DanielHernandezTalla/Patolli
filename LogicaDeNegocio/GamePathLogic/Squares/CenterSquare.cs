using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Actions;

namespace LogicaDeNegocio.GamePathLogic.Squares
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
