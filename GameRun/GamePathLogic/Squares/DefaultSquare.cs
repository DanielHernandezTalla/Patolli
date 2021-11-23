using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Actions;

namespace GameRun.GamePathLogic.Squares
{
    class DefaultSquare : Square
    {
        public DefaultSquare(Receiver receiver)
        {
            AddAction(new MoveBackAction(receiver));

            Type = SquareType.Default;
        }
    }
}
