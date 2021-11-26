using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Presentacion.User;


namespace Presentacion.Forms
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text.Trim();

            if (!name.Equals(""))
            {
                Session.MyUser.Name = name;
                this.Close();
            }
            else
                txtErrorNombre.Text = "El nombre no puede estar vacio.";
        }
    }
}
