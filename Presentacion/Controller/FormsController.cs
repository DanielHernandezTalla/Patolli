using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente;
using Presentacion.Forms;

namespace Presentacion.Controller
{
    partial class FormsController
    {
        private ClientController clientController;

        private ConnectionForm connectionForm;
        private RoomForm roomForm;
        private PlayerGameForm gameForm;

        public FormsController()
        {

        }

        public void SetClientController(ClientController controller)
        {
            clientController = controller;
        }

        public void SetConnectionForm(ConnectionForm connectionForm)
        {
            this.connectionForm = connectionForm;
        }
        public void SetRoomForm(RoomForm roomForm)
        {
            this.roomForm = roomForm;
        }
        public void SetGameForm(PlayerGameForm gameForm)
        {
            this.gameForm = gameForm;
        }

        public void NotifyClient(Eventos.Event clientEvent)
        {
            clientController.Update(clientEvent);
        }
    }
}
