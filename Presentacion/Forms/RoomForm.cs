using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Presentacion.User;
using Entidades.Connection;
using Presentacion.Controller;

namespace Presentacion.Forms
{
    public partial class RoomForm : Form
    {
        private FormsController controller;

        public RoomForm()
        {
            InitializeComponent();

            btnJugar.Location = new Point(btnJugar.Location.X, 70);

            loadPanel();

            controller = Session.FormsController;
        }
        

        public delegate void UpdateDelegate(Entidades.Connection.User user);
        public delegate void CloseFormDelegate();
        public delegate void DeleteUsersDelegate();

        public void newUpdate(Entidades.Connection.User user)
        {
            if (this.InvokeRequired)
            {
                UpdateDelegate delegado = new UpdateDelegate(addUser);
                this.Invoke(delegado, user);
            }
            else
                addUser(user);
        }

        public void closeFrmRoom()
        {
            if (this.InvokeRequired)
            {
                CloseFormDelegate closeF = new CloseFormDelegate(NextForm);
                this.Invoke(closeF);
            }
            else NextForm();
        }

        public void newDelete()
        {
            if (this.InvokeRequired)
            {
                DeleteUsersDelegate delete = new DeleteUsersDelegate(deleteUsers);
                this.Invoke(delete);
            }
        }

        #region Cargar Panel y Agregar Users

        private Panel pnl;
        private int Y = 10;

        private void loadPanel()
        {
            pnl = new Panel();
            pnl.SuspendLayout();
            pnl.Location = new Point(32, 32);
            pnl.Name = "pnUser";
            pnl.Size = new Size(220, 750);
            pnl.BorderStyle = BorderStyle.None;
            pnl.BackColor = Color.White;

            Label lbl = new Label();
            lbl.Location = new Point(0, 0);
            lbl.Name = "lblTitleUser";
            lbl.Size = new Size(220, 40);
            lbl.Text = "Usuarios"; 
            lbl.Font = fontBold();
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.FromArgb(252, 75, 8);

            pnl.Controls.Add(lbl);
            pnl.ResumeLayout(false);

            this.Controls.Add(pnl);
        }

        private void addUser(Entidades.Connection.User user)
        {
            Y = Y + 40;

            Label NewlblImg = new Label();
            NewlblImg.Location = new Point(10, Y);
            NewlblImg.Name = user.Name + "Img";
            NewlblImg.Size = new Size(32, 40);
            NewlblImg.TextAlign = ContentAlignment.MiddleLeft;
            NewlblImg.BackColor = Color.Transparent;
           // NewlblImg.Image = Image.FromFile("C:\\Users\\Daniel\\source\\repos\\Sockets.Client\\SocketsForms\\Source\\Images\\Icons\\user32x32.png");

            Label Newlbl = new Label();
            Newlbl.Location = new Point(50, Y);
            Newlbl.Name = user.Name;
            Newlbl.Size = new Size(160, 40);
            Newlbl.Text = user.Name;
            Newlbl.Font = fontRegular();
            Newlbl.TextAlign = ContentAlignment.BottomLeft;
            Newlbl.ForeColor = Color.FromArgb(10, 10, 10);
            Newlbl.BackColor = Color.White;

            pnl.Controls.Add(NewlblImg);
            pnl.Controls.Add(Newlbl);
        }

        private void deleteUsers()
        {
            pnl.Controls.Clear();

            Label lbl = new Label();
            lbl.Location = new Point(0, 0);
            lbl.Name = "lblTitleUser";
            lbl.Size = new Size(220, 40);
            lbl.Text = "Usuarios";
            lbl.Font = fontBold();
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.FromArgb(252, 75, 8);

            pnl.Controls.Add(lbl);

            Y = 10;
        }

        private Font fontRegular()
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font fontRegular = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            return fontRegular;
        }

        private Font fontBold()
        {
            // Dubai
            FontFamily fontFamily = new FontFamily("Arial");
            

            Font fontBold = new Font(
               fontFamily,
               20,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            return fontBold;
        }

        #endregion

        

        private void NextForm()
        {
            Session.GameReady = true;
            this.Close();
        }

        // Eventos a lanzar

        private void SetUpGame()
        {
            // Añadir configuracion de juego.

            Entidades.Game.GameSettings settings = new Entidades.Game.GameSettings
            {
                PiecesQuantity = 2,
                BladeSize = 7,
                Users = Session.Users
            };

            Eventos.Event clientEvent = new UserEvents.SetUpGameEvent(settings);

            controller.NotifyClient(clientEvent);
        }

        private void StartGame()
        {

        }


        // Eventos recibidos

        public void UserIdentified(Eventos.Event e)
        {
            List<Entidades.Connection.User> users = Transporte.Serialization.Serialize.JobjToObject<List<Entidades.Connection.User>>(e.Data);

            Session.Users = users;

            newDelete();
            foreach (var item in users)
                newUpdate(item);
        }

        public void GameCreated(Eventos.Event e)
        {
            closeFrmRoom();
        }

        // Eventos del Form

        private void frmRoom_Load(object sender, EventArgs e)
        {
            if (Session.Role == Session.SessionRole.Server)
                this.Text = "RoomForm (Server)";

            txtIp.Text = Session.Ip;
            txtPuerto.Text = Session.Port;
            txtNombre.Text = Session.MyUser.Name;
        }
        private void btnJugar_Click(object sender, EventArgs e)
        {
            SetUpGame();
        }
        private void frmRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Session.GameReady)
            {
                // Evento para salirse aqui?...

                Environment.Exit(Environment.ExitCode);
            }
        }
    }
}
