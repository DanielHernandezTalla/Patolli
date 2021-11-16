using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Actions;

namespace LogicaDeNegocio.GamePathLogic.Squares
{
    class CornerSquare : Square
    {
        public CornerSquare(Receiver receiver)
        {
            AddAction(new MoveBackAction(receiver));
            AddAction(new RollAgainAction(receiver));

            Type = SquareType.Corner;
        }
    }
}
