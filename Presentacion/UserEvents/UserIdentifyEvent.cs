using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos;
using Entidades;

namespace Presentacion.UserEvents
{
    class UserIdentifyEvent : Eventos.Event
    {
        private Entidades.Connection.User user;

        public override object Data { get => user; }

        public UserIdentifyEvent(Entidades.Connection.User user) : base("UserIdentify")
        {
            this.user = user;
        }
    }
}
