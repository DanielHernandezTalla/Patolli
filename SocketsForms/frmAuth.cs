using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketsForms
{
    public partial class frmAuth : Form
    {
        Form form;
        public frmAuth()
        {
            InitializeComponent();

            form = new frmClientServer();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (!nombre.Equals(""))
            {
                frmRoom.myUser = new User();
                frmRoom.myUser.Name = nombre;

                this.Hide();
                form.Show();
            }
            else
                txtErrorNombre.Text = "El nombre no puede estar vacio.";
        }

        private void pnClientServer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
