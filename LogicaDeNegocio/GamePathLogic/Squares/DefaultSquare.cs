using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Actions;

namespace LogicaDeNegocio.GamePathLogic.Squares
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
