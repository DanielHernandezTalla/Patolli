using SocketsForms.Client;
using SocketsLibrary.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    public partial class frmIpPort : Form
    {
        frmRoom frmRoom;
        public frmIpPort(frmRoom _frmRoom)
        {
            InitializeComponent();
            this.frmRoom = _frmRoom;
        }

        private void btnUnirsePartida_Click(object sender, EventArgs e)
        {
            #region Validacion del Ip y Puerto
            txtErrorIp.Text = "";
            txtErrorPuerto.Text= "";

            string ip = txtIp.Text.Trim();
            int puerto = -1;

            bool flat = true; 

            if (ip.Equals(""))
            {
                txtErrorIp.Text = "El ip no puede estar vacia!";
                flat = false;
            }

            if (!int.TryParse(txtPuerto.Text.Trim(), out puerto))
            {
                txtErrorPuerto.Text = "El puerto debe ser un numero";
                flat = false;
            }

            #endregion

            #region Creando Cliente y Servidor
            
            if (flat)
            {
                if (Session.Role == Session.SessionRole.Server)
                {
                    StartServer(ip, puerto);

                    Thread.Sleep(1000);

                    StartClient(ip, puerto);
                }
                else
                {
                    StartClient(ip, puerto);
                }
                Session.IP = ip;
                Session.Port = puerto;
            }
            #endregion
        }

        #region Iniciar server y serverClient

        private void StartServer(string ip, int puerto)
        {
            try
            {
                // Creamos el servidor 
                Session.Server = new Server(ip, puerto);

                // Le asignamos un hilo al servidor y lo corremos 
                Session.ThreadServer = new Thread(Session.Server.Start);
                Session.ThreadServer.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void StartClient(string ip, int puerto)
        {
            try
            {
                // Inicializamos el forms en esta parte, para evitar poner 
                // las variables de ip y puerto como variables generales
                //form = new frmRoom(ip, puerto);

                // Creando la instancia del servidor cliente
                Session.ServerClient = new ServerClient(ip, puerto, this, frmRoom);

                // Iniciando servidor
                Session.ThreadClient = new Thread(Session.ServerClient.Start);
                Session.ThreadClient.Start();

                // Creando controlador
                // frmRoom.myUser = new User(); // Esta instancia esta en el primer form  
                Session.Controller = new ClientController(Session.ServerClient, Session.User);

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar al servidor!!");
            }
        }

        #endregion

        #region Delegado y siguiente forms

        public delegate void UpdateDelegate();

        public void newUpdate()
        {
            if (this.InvokeRequired)
            {
                UpdateDelegate delegado = new UpdateDelegate(nextForms);
                this.Invoke(delegado);
            }
            else
                nextForms();
        }

        private void nextForms()
        {
            this.Close();
        }

        #endregion
    }
}
