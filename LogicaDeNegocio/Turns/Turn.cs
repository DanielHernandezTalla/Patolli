using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Turns
{
    public abstract class Turn // TEST es internal?
    {
        internal Turn next;
        internal Turn prior;
        
        public bool IsTemporal { get; internal set; }
        public bool IsReady { get; internal set; }
    }
}
