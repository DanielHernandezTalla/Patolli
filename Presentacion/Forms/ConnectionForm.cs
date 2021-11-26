using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Presentacion.User;
using Presentacion.Controller;
using Eventos;

namespace Presentacion.Forms
{
    public partial class ConnectionForm : Form
    {
        private FormsController controller;
        private bool IsClosed;

        public ConnectionForm()
        {
            InitializeComponent();

            controller = Session.FormsController;
        }

        private void Connect()
        {
            string ip = txtIp.Text.Trim();
            string port = txtPuerto.Text.Trim();

            if (CheckInput(ip, port, out int portNum))
            {
                // Creando Cliente y Servidor

                if (Session.Role == Session.SessionRole.Server)
                {
                    StartServer(ip, portNum);

                    Thread.Sleep(3000);

                    StartClient(ip, portNum);
                }
                else if (Session.Role == Session.SessionRole.Client)
                {
                    StartClient(ip, portNum);
                }

                Session.Ip = ip;
                Session.Port = port;

                Thread.Sleep(1000);

                Identify();
            }
        }
        private bool CheckInput(string ip, string port, out int portNum)
        {
            txtErrorIp.Text = "";
            txtErrorPuerto.Text = "";

            bool flat = true;

            if (ip.Equals(""))
            {
                txtErrorIp.Text = "El ip no puede estar vacia!";
                flat = false;
            }

            if (!int.TryParse(port, out portNum))
            {
                txtErrorPuerto.Text = "El puerto debe ser un numero";
                flat = false;
            }

            return flat;
        }

        private void StartServer(string ip, int puerto)
        {
            try
            {
                // Creamos la instancia del servidor 
                Session.Server = new Servidor.Server(ip, puerto);

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
                // Creando la instancia del servidor cliente
                Session.Client = new Cliente.Client(ip, puerto);

                // Subscribimos el controlador de forms al cliente. Para cuando suceda algo en el cliente, este le notifique a los forms.
                Session.Client.Subscribe(Session.FormsController);

                // Tambien el contralador de form tendra acceso al controlador del cliente. Para cuando suceda algo en los forms, este le notifique al cliente.
                Session.FormsController.SetClientController(Session.Client.GetController());

                // Iniciando servidor
                Session.ThreadClient = new Thread(Session.Client.Start);
                Session.ThreadClient.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void NextForm()
        {
            Session.Connected = true;
            IsClosed = true;
            this.Close();
        }

        // Eventos a lanzar.

        private void Identify()
        {
            // Lanzar evento hacia el objeto Client y que este se lo envie al Servidor y asi poder indentificarse.
            Event clientEvent = new UserEvents.UserIdentifyEvent(Session.MyUser);

            controller.NotifyClient(clientEvent);
        }

        // Eventos recibidos.

        public void UserIdentified(Eventos.Event e)
        {
            if(!IsClosed)
            {
                if (this.InvokeRequired)
                {
                    UpdateDelegate delegado = new UpdateDelegate(NextForm);
                    this.Invoke(delegado);
                }
                else
                    NextForm();
            }

            
        }
        public delegate void UpdateDelegate();

        // Eventos del Form

        private void btnUnirsePartida_Click(object sender, EventArgs e)
        {
            Connect();
        }
    }
}
