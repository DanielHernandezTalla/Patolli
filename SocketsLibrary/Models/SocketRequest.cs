using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Models
{
    public class SocketRequest
    {
        public User User { get; set; }

        public string Url { get; set; }

        public int Status { get; set; }

        public object Body { get; set; }
    }
}
