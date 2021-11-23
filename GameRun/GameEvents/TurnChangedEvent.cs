using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GameEvents
{
    public class TurnChangedEvent : Eventos.Event
    {
        private Elements.Player player;

        public override object Data { get => player; }

        public TurnChangedEvent(Elements.Player player) : base("TurnChanged", "El turno ha cambiado.")
        {
            this.player = player;
        }
    }
}
