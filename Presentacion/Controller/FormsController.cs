using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente;

namespace Presentacion.Controller
{
    partial class FormsController
    {
        private ClientController clientController;

        public void NotifyClient(Eventos.Event clientEvent)
        {
            clientController.Update(clientEvent);
        }
        
    }
}
