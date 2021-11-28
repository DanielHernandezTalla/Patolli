using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.ServerEvents
{
    class YourNumberAssignedEvent : Eventos.Event
    {
        private int number;

        public override object Data { get => number; }

        public YourNumberAssignedEvent(int number) : base("YourNumberAssigned", "Se te asigno tu numero identificador de usuario.")
        {
            this.number = number;
        }
    }
}
