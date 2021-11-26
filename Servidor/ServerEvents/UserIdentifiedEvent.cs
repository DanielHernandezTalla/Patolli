using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.ServerEvents
{
    class UserIdentifiedEvent : Eventos.Event
    {
        private List<Entidades.Connection.User> users;

        public override object Data { get => users; }

        public UserIdentifiedEvent(List<Entidades.Connection.User> users) : base("UserIdentified", "Se identificó el usuario correctamente.")
        {
            this.users = users;
        }
    }
}
