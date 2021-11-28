using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.ServerEvents
{
    class NumbersAssignedEvent : Eventos.Event
    {
        private List<Entidades.Connection.User> users;

        public override object Data { get => users; }

        public NumbersAssignedEvent(List<Entidades.Connection.User> users) : base("NumbersAssigned", "Se asignaron los numeros identificadores de los usuarios.")
        {
            this.users = users;
        }
    }
}
