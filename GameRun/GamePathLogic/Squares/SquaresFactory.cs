using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GamePathLogic.Squares
{
    abstract class SquaresFactory
    {
        protected Actions.Receiver receiver;

        public void SetReceiver(Actions.Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract Square[] FactoryMethod();
    }
}
