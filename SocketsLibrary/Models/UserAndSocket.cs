using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsLibrary.Models
{
    public class UserAndSocket
    {
        public User User { get; set; }

        public Socket Socket { get; set; }
    }
}
