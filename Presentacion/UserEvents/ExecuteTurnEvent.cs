using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.UserEvents
{
    class ExecuteTurnEvent : Eventos.Event
    {
        private int result;

        public override object Data { get => result; }

        public ExecuteTurnEvent(int result) : base("ExecuteTurn")
        {
            this.result = result;
            ToGame = true;
        }
    }
}
