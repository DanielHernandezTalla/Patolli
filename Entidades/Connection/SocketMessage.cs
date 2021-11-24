using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Connection
{
    public class SocketMessage
    {
        public User User { get; set; }

        public string Url { get; set; }

        public int Status { get; set; }

        public object Body { get; set; }
    }
}
