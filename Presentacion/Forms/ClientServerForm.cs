using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.User;

namespace Presentacion.Forms
{
    public partial class ClientServerForm : Form
    {
        public ClientServerForm()
        {
            InitializeComponent();
        }

        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            Session.Role = Session.SessionRole.Server;
            this.Close();
        }

        private void btnUnirse_Click(object sender, EventArgs e)
        {
            Session.Role = Session.SessionRole.Client;
            this.Close();
        }
    }
}
