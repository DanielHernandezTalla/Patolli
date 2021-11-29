using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public class Event
    {
        public virtual string EventType { get; private set; }
        public virtual string Description { get; set; }
        public virtual object Data { get; set; }

        public bool ToGame { get; set; }

        public int PlayerNumber { get; set; }
        public int PieceNumber { get; set; }

        public Event(string eventType)
        {
            EventType = eventType;
        }

        public Event(string eventType, string description)
        {
            EventType = eventType;
            Description = description;
        }

    }
}
