using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Actions;

namespace LogicaDeNegocio.GamePathLogic.Squares
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
