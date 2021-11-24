using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Events
{
    public class Event
    {
        public string EventType { get; set; }
        public string Description { get; set; }
        public object Data { get; set; }

        public object Sender { get; set; }

        public void Fill(Eventos.Event e)
        {
            EventType = e.EventType;
            Description = e.Description;
            Data = e.Data;
        }

        public Eventos.Event MakeCopy()
        {
            Eventos.Event e = new Eventos.Event(EventType)
            {
                Description = Description,
                Data = Data
            };

            return e;
        }
    }
}
