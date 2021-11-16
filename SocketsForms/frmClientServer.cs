using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketsForms
{
    public partial class frmClientServer : Form
    {
        Form form;
        public frmClientServer()
        {
            InitializeComponent();

            form = new frmIpPort();
        }

        private void btnCrearPartida_Click(object sender, EventArgs e)
        {
            frmIpPort.IsServer = true;
            this.Hide();
            form.Show();
        }

        private void btnUnirse_Click(object sender, EventArgs e)
        {
            frmIpPort.IsServer = false;
            this.Hide();
            form.Show();
        }

        private void frmClientServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
