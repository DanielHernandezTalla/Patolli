using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.UserEvents
{
    class ThrownCañasEvent : Eventos.Event
    {
        private bool[] cañas;

        public override object Data { get => cañas; }

        public ThrownCañasEvent(bool[] cañas) : base("ThrownCanas")
        {
            this.cañas = cañas;
        }
    }
}
