using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Actions
{
    class MoveBackAction : IAction
    {
        private readonly Receiver receiver;

        public MoveBackAction(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public bool Execute(GamePathLogic.Squares.ISquareState squareState)
        {
            return receiver.MoveBack(squareState);
        }
    }
}
