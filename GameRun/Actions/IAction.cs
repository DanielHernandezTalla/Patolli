using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Actions
{
    interface IAction
    {
        bool Execute(GamePathLogic.Squares.ISquareState squareState);
    }
}
