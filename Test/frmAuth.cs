using SocketsLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class frmAuth : Form
    {
        public frmAuth()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text.Trim();

            if (!name.Equals(""))
            {
                Session.User.Name = name;
                this.Close();
            }
            else
                txtErrorNombre.Text = "El nombre no puede estar vacio.";
        }
    }
}
