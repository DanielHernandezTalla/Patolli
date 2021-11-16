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

namespace SocketsForms
{
    public partial class frmIpPort : Form
    {
        public static bool IsServer { get; set; }
        Server server;
        Thread thread;

        Form form;

        public frmIpPort()
        {
            InitializeComponent();
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
                if (IsServer)
                {
                    StartServer(ip, puerto);

                    Thread.Sleep(1000);

                    StartClient(ip, puerto);
                }
                else
                {
                    StartClient(ip, puerto);
                }

            #endregion
        }

        #region Iniciar server y serverClient

        private void StartServer(string ip, int puerto)
        {
            try
            {
                // Creamos el servidor 
                server = new Server(ip, puerto);

                // Le asignamos un hilo al servidor y lo corremos 
                thread = new Thread(server.Start);
                thread.Start();
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
                form = new frmRoom(ip, puerto);

                // Creando la instancia del servidor cliente
                frmRoom.serverClient = new ServerClient(ip, puerto, this, (frmRoom)form);

                // Iniciando servidor
                frmRoom.threadClient = new Thread(frmRoom.serverClient.Start);
                frmRoom.threadClient.Start();

                // Creando controlador
                // frmRoom.myUser = new User(); // Esta instancia esta en el primer form  
                frmRoom.controller = new ClientController(frmRoom.serverClient, frmRoom.myUser);

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
            this.Hide();
            form.Show();
        }

        #endregion

        #region Cerrar el form
        private void frmIpPort_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cerramos el server, el thread y la applicacion
            if (frmRoom.serverClient != null)
            {
                frmRoom.serverClient.Close();
                frmRoom.myUser = null;
                frmRoom.controller = null;
                frmRoom.threadClient = null;
            }

            if (IsServer && server != null)
            {
                server.Close();
                thread = null;
            }
            
            Application.Exit();
        }
        #endregion
    }
}
