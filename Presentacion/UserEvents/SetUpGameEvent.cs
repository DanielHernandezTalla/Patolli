using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.UserEvents
{
    class SetUpGameEvent : Eventos.Event
    {
        private Entidades.Game.GameSettings settings;

        public override object Data { get => settings;  }

        public SetUpGameEvent(Entidades.Game.GameSettings settings) : base("SetUpGame")
        {
            this.settings = settings;
            ToGame = true;
        }
    }
}
