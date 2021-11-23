using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Actions;

namespace GameRun.GamePathLogic.Squares
{
    class GoalSquare : Square
    {
        public GoalSquare(Receiver receiver)
        {
            // añadir acciones del GoalSquare.

            Type = SquareType.Goal;
        }
    }
}
