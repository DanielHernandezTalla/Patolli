using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.UserEvents
{
    class StartGameEvent : Eventos.Event
    {
        public StartGameEvent() : base("StartGame")
        {
            ToGame = true;
        }
    }
}
